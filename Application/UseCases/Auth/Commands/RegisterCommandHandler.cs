using Application.Abstractions.Interfaces;
using Application.Models.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth.Commands
{
    public class RegisterCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        IHashService hashService,
        ICurrentUserService currentUserService
        ) : IRequestHandler<RegisterCommand, UserViewModel>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IHashService _hashService = hashService;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        public async Task<UserViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users
                                            .Include(x => x.Organization).ThenInclude(x => x.Address)
                                                                         .ThenInclude(x => x.Street)
                                                                         .ThenInclude(x => x.District)
                                                                         .ThenInclude(x => x.Region)
                                                                         .ThenInclude(x => x.Country)
                                            .Include(x => x.Role)
                                            .FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                            ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);
            var admin = await _context.Roles.FirstOrDefaultAsync(x => x.NameUz == "Admin" && x.NameEn == "Admin" && x.NameRu == "Админ", cancellationToken);

            if(superAdmin == null ||  admin == null)
            {
                throw new Exception("Role not found");
            }

            if (currentUser.RoleId == superAdmin.Id) {
            } 
            if (currentUser.RoleId == admin.Id) {
                if (request.OrganizationId != currentUser.OrganizationId) {
                    throw new Exception("Access denied");
                }
            }
            else {
                throw new Exception("Access denied");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == request.Phone && x.Email == request.Email, cancellationToken);
            if (user != null)
            {
                throw new AlreadyExistsException();
            }

            user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Gender = request.Gender,
                RoleId = request.RoleId,
                PasswordHash = _hashService.GetHash(request.Password),
                OrganizationId = request.OrganizationId
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}

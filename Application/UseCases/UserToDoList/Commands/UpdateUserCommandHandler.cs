using Application.Abstractions.Interfaces;
using Application.Models.ViewModels;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.UserToDoList.Commands
{
    public class UpdateUserCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        ICurrentUserService currentUserService,
        IHashService hashService
        ) : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IHashService _hashService = hashService;

        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);
            var admin = await _context.Roles.FirstOrDefaultAsync(x => x.NameUz == "Admin" && x.NameEn == "Admin" && x.NameRu == "Админ", cancellationToken);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new NotFoundException();

            if ((request.FirstName != null ||  request.LastName != null || request.Phone != null || request.Email != null)
                && (currentUser.Id != user.Id && currentUser.RoleId != superAdmin!.Id
                    && (currentUser.RoleId != admin!.Id || currentUser.OrganizationId != user.OrganizationId))
                )
            {
                throw new Exception("Access denied");
            }

            if ((request.OrganizationId != null || request.RoleId != null) && currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            if (request.NewPassword != null && request.NewPassword != request.ConfirmPassword
                && (request.OldPassword != null && !_hashService.VerifyHash(request.OldPassword, user.PasswordHash)))
            {
                throw new ArgumentException("Password incorrect");
            }
            else if(request.NewPassword != null)
            {
                user.PasswordHash = _hashService.GetHash(request.NewPassword);
            }

            user.FirstName = request.FirstName ?? user.FirstName;
            user.LastName = request.LastName ?? user.LastName;
            user.Phone = request.Phone ?? user.Phone;
            user.Email = request.Email ?? user.Email;
            user.RoleId = request.RoleId ?? user.RoleId;
            user.OrganizationId = request.OrganizationId ?? user.OrganizationId;
            user.Gender = request.Gender ?? user.Gender;

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserViewModel>(user);
        }
    }
}

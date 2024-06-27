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
        IHashService hashService
        ) : IRequestHandler<RegisterCommand, UserViewModel>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IHashService _hashService = hashService;
        public async Task<UserViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
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
                PasswordHash = _hashService.GetHash(request.Password)
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}

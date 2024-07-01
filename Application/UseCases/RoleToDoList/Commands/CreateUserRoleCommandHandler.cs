using Application.Abstractions.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RoleToDoList.Commands
{
    public class CreateUserRoleCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateUserRoleCommand, UserRole>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<UserRole> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var userRole = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == request.NameEn
                                                                      && x.NameRu == request.NameRu
                                                                      && x.NameUz == request.NameUz, cancellationToken);

            if (userRole != null)
            {
                throw new AlreadyExistsException();
            }

            userRole = new UserRole()
            {
                NameEn = request.NameEn,
                NameRu = request.NameRu,
                NameUz = request.NameUz,
                DescriptionEn = request.DescriptionEn,
                DescriptionRu = request.DescriptionRu,
                DescriptionUz = request.DescriptionUz
            };

            await _context.Roles.AddAsync(userRole, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return userRole;
        }
    }
}

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
    public class UpdateUserRoleCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<UpdateUserRoleCommand, UserRole>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<UserRole> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var userRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                               ?? throw new NotFoundException();

            userRole.NameUz = request.NameUz ?? userRole.NameUz;
            userRole.NameEn = request.NameEn ?? userRole.NameEn;
            userRole.NameRu = request.NameRu ?? userRole.NameRu;
            userRole.DescriptionEn = request.DescriptionEn ?? userRole.DescriptionEn;
            userRole.DescriptionRu = request.DescriptionRu ?? userRole.DescriptionRu;
            userRole.DescriptionUz = request.DescriptionUz ?? userRole.DescriptionUz;

            await _context.SaveChangesAsync(cancellationToken);
            return userRole;
        }
    }
}

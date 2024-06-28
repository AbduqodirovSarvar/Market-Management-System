using Application.Abstractions.Interfaces;
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
    public class DeleteUserCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);
            var admin = await _context.Roles.FirstOrDefaultAsync(x => x.NameUz == "Admin" && x.NameEn == "Admin" && x.NameRu == "Админ", cancellationToken);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new NotFoundException();

            if (currentUser.RoleId != superAdmin!.Id &&
                (currentUser.Id != request.Id &&
                    (currentUser.RoleId != admin!.Id || currentUser.OrganizationId != user.OrganizationId)))
            {
                throw new Exception("Access denied");
            }

            user.IsDeleted = true;
            user.DeletedTime = DateTime.UtcNow;
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

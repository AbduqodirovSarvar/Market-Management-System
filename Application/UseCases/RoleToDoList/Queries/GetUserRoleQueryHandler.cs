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

namespace Application.UseCases.RoleToDoList.Queries
{
    public class GetUserRoleQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetUserRoleQuery, UserRole>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<UserRole> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var userRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                               ?? throw new NotFoundException();

            return userRole;
        }
    }
}

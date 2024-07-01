using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RoleToDoList.Queries
{
    public class GetAllUserRoleQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllUserRoleQuery, List<UserRole>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<UserRole>> Handle(GetAllUserRoleQuery request, CancellationToken cancellationToken)
        {
            List<UserRole> result = [];

            if (request.SearchText != null)
            {
                result = await _context.Roles.Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                      || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                      || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                               .ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Roles.ToListAsync(cancellationToken);
            return result;
        }
    }
}

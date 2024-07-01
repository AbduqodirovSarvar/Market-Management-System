using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrganizationToDoList.Queries
{
    public class GetAllOrganizationQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllOrganizationQuery, List<Organization>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<Organization>> Handle(GetAllOrganizationQuery request, CancellationToken cancellationToken)
        {
            List<Organization> result = [];

            if (request.SearchText != null)
            {
                result = await _context.Organizations.Include(x => x.Address).ThenInclude(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                    .ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Organizations.Include(x => x.Address).ThenInclude(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country).ToListAsync(cancellationToken);
            return result;
        }
    }
}

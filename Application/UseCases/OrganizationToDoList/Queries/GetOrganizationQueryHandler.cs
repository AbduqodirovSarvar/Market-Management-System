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

namespace Application.UseCases.OrganizationToDoList.Queries
{
    public class GetOrganizationQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetOrganizationQuery, Organization>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Organization> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            var organization = await _context.Organizations.Include(x => x.Address).ThenInclude(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                                           .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                           ?? throw new NotFoundException();
            return organization;
        }
    }
}

using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AddressToDoList.Queries
{
    public class GetAllAddressQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllAddressQuery, List<Address>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<Address>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            List<Address> result = [];

            if (request.SearchText != null && request.StreetId != null)
            {
                result = await _context.Addresses.Include(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => (x.AddressLine.ToLower().Contains(request.SearchText.ToLower())
                                                                        || x.Home.ToLower().Contains(request.SearchText.ToLower())
                                                                        && x.StreetId == request.StreetId))
                                                .ToListAsync(cancellationToken);
                return result;
            }

            if (request.SearchText != null)
            {
                result = await _context.Addresses.Include(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => x.AddressLine.ToLower().Contains(request.SearchText.ToLower())
                                                                        || x.Home.ToLower().Contains(request.SearchText.ToLower()))
                                               .ToListAsync(cancellationToken);
                return result;
            }

            if (request.StreetId != null)
            {
                result = await _context.Addresses.Include(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                               .Where(x => x.StreetId == request.StreetId).ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Addresses.Include(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                             .ToListAsync(cancellationToken);
            return result;
        }
    }
}

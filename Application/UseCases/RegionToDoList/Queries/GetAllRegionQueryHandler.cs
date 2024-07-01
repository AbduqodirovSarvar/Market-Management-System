using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RegionToDoList.Queries
{
    public class GetAllRegionQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllRegionQuery, List<Region>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<Region>> Handle(GetAllRegionQuery request, CancellationToken cancellationToken)
        {
            List<Region> result = [];

            if(request.SearchText != null && request.CountryId != null)
            {
                result = await _context.Regions.Include(x => x.Country).Where(x => (x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                                                && x.CountryId == request.CountryId)
                                               .ToListAsync(cancellationToken);
                return result;
            }

            if (request.SearchText != null)
            {
                result = await _context.Regions.Include(x => x.Country).Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                               .ToListAsync(cancellationToken);
                return result;
            }

            if (request.CountryId != null)
            {
                result = await _context.Regions.Include(x => x.Country).Where(x => x.CountryId == request.CountryId).ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Regions.Include(x => x.Country).ToListAsync(cancellationToken);
            return result;
        }
    }
}

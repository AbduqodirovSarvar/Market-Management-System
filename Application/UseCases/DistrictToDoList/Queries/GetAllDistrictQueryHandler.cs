using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DistrictToDoList.Queries
{
    public class GetAllDistrictQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllDistrictQuery, List<District>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<District>> Handle(GetAllDistrictQuery request, CancellationToken cancellationToken)
        {
            List<District> result = [];

            if (request.SearchText != null && request.RegionId != null)
            {
                result = await _context.Districts.Include(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => (x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                                                && x.RegionId == request.RegionId)
                                                 .ToListAsync(cancellationToken);
                return result;
            }

            if (request.SearchText != null)
            {
                result = await _context.Districts.Include(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                 .ToListAsync(cancellationToken);
                return result;
            }

            if (request.RegionId != null)
            {
                result = await _context.Districts.Include(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => x.RegionId == request.RegionId).ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Districts.Include(x => x.Region).ThenInclude(x => x.Country).ToListAsync(cancellationToken);
            return result;
        }
    }
}

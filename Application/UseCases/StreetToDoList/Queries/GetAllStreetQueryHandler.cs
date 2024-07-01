using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.StreetToDoList.Queries
{
    public class GetAllStreetQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllStreetQuery, List<Street>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<Street>> Handle(GetAllStreetQuery request, CancellationToken cancellationToken)
        {
            List<Street> result = [];

            if (request.SearchText != null && request.DistrictId != null)
            {
                result = await _context.Streets.Include(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => (x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                                                && x.DistrictId == request.DistrictId)
                                               .ToListAsync(cancellationToken);
                return result;
            }

            if (request.SearchText != null)
            {
                result = await _context.Streets.Include(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                                                        .Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                               .ToListAsync(cancellationToken);
                return result;
            }

            if (request.DistrictId != null)
            {
                result = await _context.Streets.Include(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                               .Where(x => x.DistrictId == request.DistrictId).ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Streets.Include(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country).ToListAsync(cancellationToken);
            return result;
        }
    }
}

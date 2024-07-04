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

namespace Application.UseCases.RegionToDoList.Queries
{
    public class GetRegionQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetRegionQuery, Region>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Region> Handle(GetRegionQuery request, CancellationToken cancellationToken)
        {
            var region = await _context.Regions.Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                               ?? throw new NotFoundException();

            return region;
        }
    }
}

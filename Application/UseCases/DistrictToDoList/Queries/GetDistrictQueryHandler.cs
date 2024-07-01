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

namespace Application.UseCases.DistrictToDoList.Queries
{
    public class GetDistrictQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetDistrictQuery, District>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<District> Handle(GetDistrictQuery request, CancellationToken cancellationToken)
        {
            var district = await _context.Districts.Include(x => x.Region).ThenInclude(x => x.Country)
                                                   .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                   ?? throw new NotFoundException();

            return district;
        }
    }
}

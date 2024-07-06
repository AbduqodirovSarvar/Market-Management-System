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

namespace Application.UseCases.OutComeToDoList.Queries
{
    public class GetOutComeQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetOutComeQuery, OutCome>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<OutCome> Handle(GetOutComeQuery request, CancellationToken cancellationToken)
        {
            var outCome = await _context.Outcomes.Include(x => x.Product)
                                                    .ThenInclude(x => x.ProductType)
                                                    .ThenInclude(x => x.MeasureOfType)
                                                .Include(x => x.Organization)
                                                    .ThenInclude(x => x.Address)
                                                    .ThenInclude(x => x.Street)
                                                    .ThenInclude(x => x.District)
                                                    .ThenInclude(x => x.Region)
                                                    .ThenInclude(x => x.Country)
                                                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                ?? throw new NotFoundException();

            return outCome;
        }
    }
}

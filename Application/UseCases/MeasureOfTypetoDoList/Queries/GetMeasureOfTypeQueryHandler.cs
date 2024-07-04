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

namespace Application.UseCases.MeasureOfTypetoDoList.Queries
{
    public class GetMeasureOfTypeQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetMeasureOfTypeQuery, MeasureOfType>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<MeasureOfType> Handle(GetMeasureOfTypeQuery request, CancellationToken cancellationToken)
        {
            var measureOfType = await _context.MeasureOfTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                             ?? throw new NotFoundException();
            
            return measureOfType;
        }
    }
}

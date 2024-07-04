using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MeasureOfTypetoDoList.Queries
{
    public class GetAllMeasureOfTypeQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllMeasureOfTypeQuery, List<MeasureOfType>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<MeasureOfType>> Handle(GetAllMeasureOfTypeQuery request, CancellationToken cancellationToken)
        {
            List<MeasureOfType> result = [];
            if(request.SearchText != null)
            {
                result = await _context.MeasureOfTypes.Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                                                || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                       .ToListAsync(cancellationToken);
                return result;
            }
            result = await _context.MeasureOfTypes.ToListAsync(cancellationToken);
            return result;
        }
    }
}

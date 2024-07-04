using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductTypeToDoList.Queries
{
    public class GetAllProductTypeQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllProductTypeQuery, List<ProductType>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<ProductType>> Handle(GetAllProductTypeQuery request, CancellationToken cancellationToken)
        {
            List<ProductType> result = [];
            if (request.MeasureOfTypeId != null && request.SearchText != null)
            {
                result = await _context.ProductTypes.Include(x => x.MeasureOfType)
                                                .Where(x => x.MeasureOfTypeId == request.MeasureOfTypeId
                                                         && (x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameUz.ToLower().Contains(request.SearchText.ToLower())))
                                                    .ToListAsync(cancellationToken);
                return result;
            }

            if (request.MeasureOfTypeId != null)
            {
                result = await _context.ProductTypes.Include(x => x.MeasureOfType)
                                                .Where(x => x.MeasureOfTypeId == request.MeasureOfTypeId)
                                                    .ToListAsync(cancellationToken);
                return result;
            }

            if (request.SearchText != null)
            {
                result = await _context.ProductTypes.Include(x => x.MeasureOfType)
                                                .Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                    .ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.ProductTypes.Include(x => x.MeasureOfType).ToListAsync(cancellationToken);
            return result;
        }
    }
}

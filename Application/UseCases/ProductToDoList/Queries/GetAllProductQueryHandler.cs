using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductToDoList.Queries
{
    public class GetAllProductQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> result = [];
            if(request.ProductTypeId != null && request.SearchText != null)
            {
                result = await _context.Products.Include(x => x.ProductType).ThenInclude(x => x.MeasureOfType)
                                                .Where(x => x.ProductTypeId == request.ProductTypeId
                                                         && (x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameUz.ToLower().Contains(request.SearchText.ToLower())))
                                                    .ToListAsync(cancellationToken);
                return result;
            }

            if(request.ProductTypeId != null)
            {
                result = await _context.Products.Include(x => x.ProductType).ThenInclude(x => x.MeasureOfType)
                                                .Where(x => x.ProductTypeId == request.ProductTypeId)
                                                    .ToListAsync(cancellationToken);
                return result;
            }

            if(request.SearchText != null)
            {
                result = await _context.Products.Include(x => x.ProductType).ThenInclude(x => x.MeasureOfType)
                                                .Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                            || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                                    .ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Products.Include(x => x.ProductType).ThenInclude(x => x.MeasureOfType).ToListAsync(cancellationToken);
            return result;
        }
    }
}

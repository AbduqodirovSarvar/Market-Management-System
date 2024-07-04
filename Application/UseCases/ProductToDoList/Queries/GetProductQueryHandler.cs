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

namespace Application.UseCases.ProductToDoList.Queries
{
    public class GetProductQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.ProductType).ThenInclude(x => x.MeasureOfType)
                                   .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                   ?? throw new NotFoundException();
            return product;
        }
    }
}

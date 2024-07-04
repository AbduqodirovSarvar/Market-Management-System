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

namespace Application.UseCases.ProductTypeToDoList.Queries
{
    public class GetProductTypeQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetProductTypeQuery, ProductType>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<ProductType> Handle(GetProductTypeQuery request, CancellationToken cancellationToken)
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                         ?? throw new NotFoundException();
            return productType;
        }
    }
}

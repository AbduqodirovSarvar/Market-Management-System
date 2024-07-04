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

namespace Application.UseCases.ProductToDoList.Commands
{
    public class UpdateProductCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                 ?? throw new NotFoundException();


            if(request.ProductTypeId != null)
            {
                var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Id == request.ProductTypeId, cancellationToken)
                        ?? throw new NotFoundException();
                product.ProductTypeId = productType.Id;
            }

            product.NameRu = request.NameRu ?? product.NameRu;
            product.NameEn = request.NameEn ?? product.NameEn;
            product.NameUz = request.NameUz ?? product.NameUz;
            product.DescriptionUz = request.DescriptionUz ?? product.DescriptionUz;
            product.DescriptionRu = request.DescriptionRu ?? product.DescriptionRu;
            product.DescriptionEn = request.DescriptionEn ?? product.DescriptionEn;

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}

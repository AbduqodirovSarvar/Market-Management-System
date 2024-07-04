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
    public class CreateProductCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductTypeId == request.ProductTypeId
                                                                        && x.NameEn == request.NameEn
                                                                        && x.NameRu == request.NameRu
                                                                        && x.NameUz == request.NameUz, cancellationToken);

            if(product != null)
            {
                throw new AlreadyExistsException();
            }

            var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Id == request.ProductTypeId, cancellationToken)
                                                         ?? throw new NotFoundException();

            product = new Product()
            {
                ProductTypeId = productType.Id,
                NameEn = request.NameEn,
                NameRu = request.NameRu,
                NameUz = request.NameUz,
                DescriptionEn = request.DescriptionEn,
                DescriptionRu = request.DescriptionRu,
                DescriptionUz = request.DescriptionUz,
            };

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}

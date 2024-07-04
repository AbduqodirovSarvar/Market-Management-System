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

namespace Application.UseCases.ProductTypeToDoList.Commands
{
    public class CreateProductTypeCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<CreateProductTypeCommand, ProductType>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<ProductType> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.NameEn == request.NameEn
                                                                                 && x.NameRu == request.NameRu
                                                                                 && x.NameUz == request.NameUz, cancellationToken);

            if (productType != null)
            {
                throw new AlreadyExistsException();
            }

            var measureOfType = await _context.MeasureOfTypes.FirstOrDefaultAsync(x => x.Id == request.MeasureOfTypeId, cancellationToken)
                                           ?? throw new NotFoundException();

            productType = new ProductType()
            {
                MeasureOfTypeId = measureOfType.Id,
                NameEn = request.NameEn,
                NameRu = request.NameRu,
                NameUz = request.NameUz,
                DescriptionEn = request.DescriptionEn,
                DescriptionRu = request.DescriptionRu,
                DescriptionUz = request.DescriptionUz
            };

            await _context.ProductTypes.AddAsync(productType, cancellationToken);
            return productType;
        }
    }
}

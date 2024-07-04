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
    public class UpdateProductTypeCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<UpdateProductTypeCommand, ProductType>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<ProductType> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                            ?? throw new NotFoundException();

            if(request.MeasureOfTypeId != null)
            {
                var measureOfType = await _context.MeasureOfTypes.FirstOrDefaultAsync(x => x.Id == request.MeasureOfTypeId, cancellationToken)
                                                    ?? throw new NotFoundException();
                productType.MeasureOfTypeId = measureOfType.Id;
            }

            productType.NameRu = request.NameRu ?? productType.NameRu;
            productType.NameEn = request.NameEn ?? productType.NameEn;
            productType.NameUz = request.NameUz ?? productType.NameUz;
            productType.DescriptionEn = request.DescriptionEn ?? productType.DescriptionEn;
            productType.DescriptionRu = request.DescriptionRu ?? productType.DescriptionRu;
            productType.DescriptionUz = request.DescriptionUz ?? productType.DescriptionUz;

            await _context.SaveChangesAsync(cancellationToken);

            return productType;
        }
    }
}

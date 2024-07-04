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
            var productTtype = await _context.ProductTypes.FirstOrDefaultAsync(x => x.NameEn == request.NameEn
                                                                                 && x.NameRu == request.NameRu
                                                                                 && x.NameUz == request.NameUz, cancellationToken);

            if (productTtype != null)
            {
                throw new AlreadyExistsException();
            }


            throw new NotImplementedException();
        }
    }
}

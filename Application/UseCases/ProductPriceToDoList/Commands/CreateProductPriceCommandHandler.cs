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

namespace Application.UseCases.ProductPriceToDoList.Commands
{
    public class CreateProductPriceCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateProductPriceCommand, ProductPrice>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<ProductPrice> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                   ?? throw new NotFoundException();

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                                                   ?? throw new NotFoundException();

            if(request.Price < 0)
            {
                throw new ArgumentException("Price does not be less than zero");
            }

            var productPrice = new ProductPrice()
            {
                OrganizationId = currentUser.OrganizationId,
                ProductId = product.Id,
                Price = request.Price,
            };

            await _context.Prices.AddAsync(productPrice, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return productPrice;
        }
    }
}

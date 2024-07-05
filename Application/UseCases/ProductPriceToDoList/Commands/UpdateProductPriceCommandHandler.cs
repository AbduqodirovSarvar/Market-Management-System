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
    public class UpdateProductPriceCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<UpdateProductPriceCommand, ProductPrice>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<ProductPrice> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new NotFoundException();

            var productPrice = await _context.Prices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) 
                                                   ?? throw new NotFoundException();

            if(currentUser.OrganizationId != productPrice.OrganizationId)
            {
                throw new Exception("Access denied");
            }

            if(request.ProductId != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                                                    ?? throw new NotFoundException();
                productPrice.ProductId = product.Id;
            }

            if(request.Price != null)
            {
                if(request.Price < 0)
                {
                    throw new ArgumentException("Price does not be less than zero");
                }
                productPrice.Price = (decimal)request.Price;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return productPrice;
        }
    }
}

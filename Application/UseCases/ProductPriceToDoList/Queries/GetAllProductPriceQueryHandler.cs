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

namespace Application.UseCases.ProductPriceToDoList.Queries
{
    public class GetAllProductPriceQueryHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<GetAllProductPriceQuery, List<ProductPrice>>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<List<ProductPrice>> Handle(GetAllProductPriceQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new NotFoundException();

            List<ProductPrice> result = await _context.Prices
                                                .Include(x => x.Product)
                                                    .ThenInclude(x => x.ProductType)
                                                    .ThenInclude(x => x.MeasureOfType)
                                                .Include(x => x.Organization)
                                                    .ThenInclude(x => x.Address)
                                                    .ThenInclude(x => x.Street)
                                                    .ThenInclude(x => x.District)
                                                    .ThenInclude(x => x.Region)
                                                    .ThenInclude(x => x.Country)
                                                .Where(x => x.OrganizationId == currentUser.OrganizationId)
                                                    .ToListAsync(cancellationToken);

            if(request.ProductId != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                                                    ?? throw new NotFoundException();
                result = result.Where(x => x.ProductId == product.Id).ToList();
            }

            return result;
        }
    }
}

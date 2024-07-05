using Application.Abstractions.Interfaces;
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
    public class DeleteProductPriceCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<DeleteProductPriceCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<bool> Handle(DeleteProductPriceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new NotFoundException();

            var productPrice = await _context.Prices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                   ?? throw new NotFoundException();

            if (currentUser.OrganizationId != productPrice.OrganizationId)
            {
                throw new Exception("Access denied");
            }

            _context.Prices.Remove(productPrice);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

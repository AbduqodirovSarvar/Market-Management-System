using Application.Abstractions.Interfaces;
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
    public class DeleteProductCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                 ?? throw new NotFoundException();

            _context.Products.Remove(product);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

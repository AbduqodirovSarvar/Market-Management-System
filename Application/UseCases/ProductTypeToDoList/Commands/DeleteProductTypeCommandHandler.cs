using Application.Abstractions.Interfaces;
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
    public class DeleteProductTypeCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteProductTypeCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<bool> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                            ?? throw new NotFoundException();

            _context.ProductTypes.Remove(productType);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

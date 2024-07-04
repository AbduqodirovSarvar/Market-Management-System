using Application.Abstractions.Interfaces;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MeasureOfTypetoDoList.Commands
{
    public class DeleteMeasureOfTypeCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteMeasureOfTypeCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<bool> Handle(DeleteMeasureOfTypeCommand request, CancellationToken cancellationToken)
        {
            var measureOfType = await _context.MeasureOfTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                             ?? throw new NotFoundException();
            _context.MeasureOfTypes.Remove(measureOfType);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

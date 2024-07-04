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

namespace Application.UseCases.MeasureOfTypetoDoList.Commands
{
    public class UpdateMeasureOfTypeCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<UpdateMeasureOfTypeCommand, MeasureOfType>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<MeasureOfType> Handle(UpdateMeasureOfTypeCommand request, CancellationToken cancellationToken)
        {
            var measureOfType = await _context.MeasureOfTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                             ?? throw new NotFoundException();

            measureOfType.NameEn = request.NameEn ?? measureOfType.NameEn;
            measureOfType.NameRu = request.NameRu ?? measureOfType.NameRu;
            measureOfType.NameUz = request.NameUz ?? measureOfType.NameUz;
            measureOfType.DescriptionEn = request.DescriptionEn ?? measureOfType.DescriptionEn;
            measureOfType.DescriptionRu = request.DescriptionRu ?? measureOfType.DescriptionRu;
            measureOfType.DescriptionUz = request.DescriptionUz ?? measureOfType.DescriptionUz;

            await _context.SaveChangesAsync(cancellationToken);
            return measureOfType;
        }
    }
}

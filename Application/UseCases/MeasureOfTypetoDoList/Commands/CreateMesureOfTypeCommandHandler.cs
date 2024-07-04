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
    public class CreateMesureOfTypeCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<CreateMesureOfTypeCommand, MeasureOfType>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<MeasureOfType> Handle(CreateMesureOfTypeCommand request, CancellationToken cancellationToken)
        {
            var measureOfType = await _context.MeasureOfTypes.FirstOrDefaultAsync(x => x.NameEn == request.NameEn 
                                                                                    && x.NameRu == request.NameRu 
                                                                                    && x.NameUz == request.NameUz, cancellationToken);
            if (measureOfType != null) 
            {
                throw new AlreadyExistsException();
            }

            measureOfType = new MeasureOfType()
            {
                NameUz = request.NameUz,
                NameEn = request.NameEn,
                NameRu = request.NameRu,
                DescriptionEn = request.DescriptionEn,
                DescriptionRu = request.DescriptionRu,
                DescriptionUz = request.DescriptionUz,
            };

            await _context.MeasureOfTypes.AddAsync(measureOfType, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return measureOfType;
        }
    }
}

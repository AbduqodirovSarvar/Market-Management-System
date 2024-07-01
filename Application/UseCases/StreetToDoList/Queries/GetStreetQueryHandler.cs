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

namespace Application.UseCases.StreetToDoList.Queries
{
    public class GetStreetQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetStreetQuery, Street>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Street> Handle(GetStreetQuery request, CancellationToken cancellationToken)
        {
            var street = await _context.Streets.Include(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                               .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                               ?? throw new NotFoundException();

            return street;
        }
    }
}

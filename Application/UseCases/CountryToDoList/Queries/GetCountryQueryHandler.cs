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

namespace Application.UseCases.CountryToDoList.Queries
{
    public class GetCountryQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetCountryQuery, Country>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Country> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                ?? throw new NotFoundException();
            return country;
        }
    }
}

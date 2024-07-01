using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CountryToDoList.Queries
{
    public class GetAllCountryQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllCountryQuery, List<Country>>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<List<Country>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            List<Country> result = [];
            if (request.SearchText == null)
            {
                result = await _context.Countries.ToListAsync(cancellationToken);
                return result;
            }

            result = await _context.Countries.Where(x => x.NameEn.ToLower().Contains(request.SearchText.ToLower())
                                                      || x.NameRu.ToLower().Contains(request.SearchText.ToLower())
                                                      || x.NameUz.ToLower().Contains(request.SearchText.ToLower()))
                                             .ToListAsync(cancellationToken);

            return result;
        }
    }
}

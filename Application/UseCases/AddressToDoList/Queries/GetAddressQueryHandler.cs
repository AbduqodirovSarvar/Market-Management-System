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

namespace Application.UseCases.AddressToDoList.Queries
{
    public class GetAddressQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAddressQuery, Address>
    {
        private readonly IAppDbContext _context = appDbContext;

        public async Task<Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses.Include(x => x.Street).ThenInclude(x => x.District).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                                               .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                               ?? throw new NotFoundException();

            return address;
        }
    }
}

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

namespace Application.UseCases.AddressToDoList.Commands
{
    public class CreateAddressCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateAddressCommand, Address>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var street = await _context.Streets.FirstOrDefaultAsync(x => x.Id == request.StreetId, cancellationToken)
                                                  ?? throw new NotFoundException();

            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetId == street.Id
                                                                      && x.Home == request.Home
                                                                      && x.AddressLine == request.AddressLine, cancellationToken);

            if (address != null)
            {
                throw new AlreadyExistsException();
            }

            address = new Address()
            {
                StreetId = street.Id,
                Home = request.Home,
                AddressLine = request.AddressLine,
            };

            await _context.Addresses.AddAsync(address, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return address;
        }
    }
}

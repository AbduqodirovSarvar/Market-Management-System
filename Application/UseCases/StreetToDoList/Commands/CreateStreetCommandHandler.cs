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

namespace Application.UseCases.StreetToDoList.Commands
{
    public class CreateStreetCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateStreetCommand, Street>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Street> Handle(CreateStreetCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var district = await _context.Countries.FirstOrDefaultAsync(x => x.Id == request.DistrictId, cancellationToken)
                                                  ?? throw new NotFoundException();

            var street = await _context.Streets.FirstOrDefaultAsync(x => x.DistrictId == district.Id
                                                                      && x.NameEn == request.NameEn
                                                                      && x.NameRu == request.NameRu
                                                                      && x.NameUz == request.NameUz, cancellationToken);

            if (street != null)
            {
                throw new AlreadyExistsException();
            }

            street = new Street()
            {
                DistrictId = district.Id,
                NameEn = request.NameEn,
                NameUz = request.NameUz,
                NameRu = request.NameRu
            };

            await _context.Streets.AddAsync(street, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return street;
        }
    }
}

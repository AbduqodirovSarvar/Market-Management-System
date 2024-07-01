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

namespace Application.UseCases.RegionToDoList.Commands
{
    public class CreateRegionCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateRegionCommand, Region>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Region> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var region = await _context.Regions.FirstOrDefaultAsync(x => x.CountryId == request.CountryId 
                                                                      && x.NameEn == request.NameEn
                                                                      && x.NameRu == request.NameRu 
                                                                      && x.NameUz == request.NameUz, cancellationToken);

            if (region != null)
            {
                throw new AlreadyExistsException();
            }

            region = new Region()
            {
                CountryId = request.CountryId,
                NameEn = request.NameEn,
                NameUz = request.NameUz,
                NameRu = request.NameRu
            };

            await _context.Regions.AddAsync(region, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return region;
        }
    }
}

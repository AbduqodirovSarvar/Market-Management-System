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

namespace Application.UseCases.DistrictToDoList.Commands
{
    public class CreateDistrictCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateDistrictCommand, District>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<District> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == request.RegionId, cancellationToken)
                                                  ?? throw new NotFoundException();

            var district = await _context.Districts.FirstOrDefaultAsync(x => x.RegionId == region.Id
                                                                      && x.NameEn == request.NameEn
                                                                      && x.NameRu == request.NameRu
                                                                      && x.NameUz == request.NameUz, cancellationToken);

            if (district != null)
            {
                throw new AlreadyExistsException();
            }

            district = new District()
            {
                RegionId = region.Id,
                NameEn = request.NameEn,
                NameUz = request.NameUz,
                NameRu = request.NameRu
            };

            await _context.Districts.AddAsync(district, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return district;
        }
    }
}

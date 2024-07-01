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
    public class UpdateDistrictCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<UpdateDistrictCommand, District>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<District> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var district = await _context.Districts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                  ?? throw new NotFoundException();

            if (request.RegionId != null)
            {
                var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                      ?? throw new NotFoundException();

                district.RegionId = region.Id;
            }

            district.NameRu = request.NameRu ?? district.NameRu;
            district.NameEn = request.NameEn ?? district.NameEn;
            district.NameUz = request.NameUz ?? district.NameUz;

            await _context.SaveChangesAsync(cancellationToken);
            
            return district;
        }
    }
}

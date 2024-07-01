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

namespace Application.UseCases.OrganizationToDoList.Commands
{
    public class UpdateOrganizationCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<UpdateOrganizationCommand, Organization>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Organization> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                  ?? throw new NotFoundException();

            if (request.AddressId != null)
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == request.AddressId, cancellationToken)
                                                      ?? throw new NotFoundException();

                organization.AddressId = address.Id;
            }

            organization.NameRu = request.NameRu ?? organization.NameRu;
            organization.NameEn = request.NameEn ?? organization.NameEn;
            organization.NameUz = request.NameUz ?? organization.NameUz;
            organization.DescriptionRu = request.DescriptionRu ?? organization.DescriptionRu;
            organization.DescriptionEn = request.DescriptionEn ?? organization.DescriptionEn;
            organization.DescriptionUz = request.DescriptionUz ?? organization.DescriptionUz;

            await _context.SaveChangesAsync(cancellationToken);

            return organization;
        }
    }
}

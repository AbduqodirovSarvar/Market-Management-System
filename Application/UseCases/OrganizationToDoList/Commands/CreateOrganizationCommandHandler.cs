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
    public class CreateOrganizationCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateOrganizationCommand, Organization>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Organization> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.AddressId == request.AddressId
                                                                                  && x.NameEn == request.NameEn
                                                                                  && x.NameRu == request.NameRu
                                                                                  && x.NameUz == request.NameUz, cancellationToken);

            if(organization != null)
            {
                throw new AlreadyExistsException();
            }

            organization = new Organization()
            {
                AddressId = request.AddressId,
                NameEn = request.NameEn,
                NameUz = request.NameUz,
                NameRu = request.NameRu,
                DescriptionEn = request.DescriptionEn,
                DescriptionRu = request.DescriptionRu,
                DescriptionUz = request.DescriptionUz,
            };

            await _context.Organizations.AddAsync(organization, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return organization;
        }
    }
}

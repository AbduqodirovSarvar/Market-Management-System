﻿using Application.Abstractions.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CountryToDoList.Commands
{
    public class CreateCountryCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var country = await _context.Countries.FirstOrDefaultAsync(x => x.NameEn == request.NameEn && x.NameRu == request.NameRu && x.NameUz == request.NameUz, cancellationToken);

            if(country != null)
            {
                throw new AlreadyExistsException();
            }

            country = new Country()
            {
                NameUz = request.NameUz,
                NameRu = request.NameRu,
                NameEn = request.NameEn,
            };

            await _context.Countries.AddAsync(country, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return country;
        }
    }
}

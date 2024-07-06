using Application.Abstractions.Interfaces;
using AutoMapper.Configuration.Annotations;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OutComeToDoList.Commands
{
    public class CreateOutComeCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<CreateOutComeCommand, OutCome>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<OutCome> Handle(CreateOutComeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                               ?? throw new NotFoundException();

            var inCome = await _context.Incomes.FirstOrDefaultAsync(x => x.Id == request.InComeId, cancellationToken)
                                               ?? throw new NotFoundException();

            if(currentUser.OrganizationId !=  inCome.OrganizationId)
            {
                throw new Exception("Access denied");
            }

            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == inCome.OrganizationId, cancellationToken)
                                                ?? throw new NotFoundException();

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == inCome.ProductId, cancellationToken)
                                               ?? throw new NotFoundException();

            var price = await _context.Prices.FirstOrDefaultAsync(x => x.OrganizationId == organization.Id && x.ProductId == product.Id, cancellationToken)
                                                ?? throw new NotFoundException();

            var outCome = new OutCome()
            {
                OrganizationId = organization.Id,
                ProductId = product.Id,
                Amount = inCome.Amount,
                Price = price.Price,
            };

            await _context.Outcomes.AddAsync(outCome, cancellationToken);
            inCome.Amount -= outCome.Amount;
            await _context.SaveChangesAsync(cancellationToken);
            return outCome;
        }
    }
}

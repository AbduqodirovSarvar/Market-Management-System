using Application.Abstractions.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.UseCases.InComeToDoList.Commands
{
    public class UpdateInComeCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService,
        IQrCodeService qrCodeService
        ) : IRequestHandler<UpdateInComeCommand, InCome>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IQrCodeService _qrCodeService = qrCodeService;

        public async Task<InCome> Handle(UpdateInComeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var inCome = await _context.Incomes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                ?? throw new NotFoundException();

            if(currentUser.OrganizationId != inCome.OrganizationId)
            {
                throw new Exception("Access denied");
            }

            inCome.ExpirationAt = request.ExpirationAt ?? inCome.ExpirationAt;
            inCome.Amount = request.Amount ?? inCome.Amount;
            inCome.Price = request.Price ?? inCome.Price;


            if (request.ProductId != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                                                 ?? throw new NotFoundException();

                inCome.ProductId = product.Id;
            }

            var obj = new
            {
                InComeId = inCome.Id,
                OrganizationId = inCome.OrganizationId,
                ProductId = inCome.ProductId,
                ExpirationAt = inCome.ExpirationAt,
                CreatedAt = inCome.CreatedAt,
            };

            var jsonData = JsonSerializer.Serialize(obj);
            inCome.QrCodeFileName = _qrCodeService.GenerateQrCode(jsonData);

            await _context.SaveChangesAsync(cancellationToken);
            return inCome;
        }
    }
}

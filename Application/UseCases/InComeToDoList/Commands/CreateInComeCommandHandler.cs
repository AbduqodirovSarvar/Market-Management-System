using Application.Abstractions.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.UseCases.InComeToDoList.Commands
{
    public class CreateInComeCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService,
        IQrCodeService qrCodeService
        ) : IRequestHandler<CreateInComeCommand, InCome>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IQrCodeService _qrCodeService = qrCodeService;

        public async Task<InCome> Handle(CreateInComeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.Include(x => x.Organization).FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                                                 ?? throw new NotFoundException();

            if (request.Amount < 0 || request.ExpirationAt < new DateOnly(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day)
                    || request.Price < 0)
            {
                throw new ArgumentException("Argument error");
            }
            
            var inCome = new InCome()
            {
                OrganizationId = currentUser.OrganizationId,
                ProductId = request.ProductId,
                Amount = request.Amount,
                InComeAmount = request.Amount,
                Price = request.Price,
                ExpirationAt = request.ExpirationAt,
            };

            var obj = new
            {
                inCome.Id,
                inCome.OrganizationId,
                inCome.ProductId,
                inCome.ExpirationAt,
                inCome.CreatedAt,
            };

            var jsonData = JsonSerializer.Serialize(obj);
            inCome.QrCodeFileName = _qrCodeService.GenerateQrCode(jsonData);

            await _context.Incomes.AddAsync(inCome, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return inCome;
        }
    }
}

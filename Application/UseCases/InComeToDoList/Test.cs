using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.UseCases.InComeToDoList
{
    public class Test : IRequest<string>
    {

    }

    public class TestHandler(
        IQrCodeService qrCodeService
        ) : IRequestHandler<Test, string>
    {
        private readonly IQrCodeService _qrCodeService = qrCodeService;

        public Task<string> Handle(Test request, CancellationToken cancellationToken)
        {
            var inCome = new InCome()
            {
                OrganizationId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Amount = 50,
                Price = (decimal)12000,
                ExpirationAt = new DateOnly(2020, 04, 1),
            };

            var jsonData = JsonSerializer.Serialize(inCome);

            var result = _qrCodeService.GenerateQrCode(jsonData);
            return Task.FromResult( result );
        }
    }
}

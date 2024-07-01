using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AddressToDoList.Queries
{
    public class GetAllAddressQuery : IRequest<List<Address>>
    {
        public string? SearchText { get; set; } = null;
        public Guid? StreetId { get; set; } = null;
    }
}

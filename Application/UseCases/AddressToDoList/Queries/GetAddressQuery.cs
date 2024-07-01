using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AddressToDoList.Queries
{
    public class GetAddressQuery : IRequest<Address>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

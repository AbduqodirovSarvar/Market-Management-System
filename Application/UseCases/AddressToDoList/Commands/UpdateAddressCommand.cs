using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AddressToDoList.Commands
{
    public class UpdateAddressCommand : IRequest<Address>
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? StreetId { get; set; } = null;
        public string? Home { get; set; } = null;
        public string? AddressLine { get; set; } = null;
    }
}

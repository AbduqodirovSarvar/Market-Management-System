using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.InComeToDoList.Commands
{
    public class UpdateInComeCommand : IRequest<InCome>
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; } = null;
        public int? InComeAmount { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public DateOnly? ExpirationAt { get; set; } = null;
    }
}

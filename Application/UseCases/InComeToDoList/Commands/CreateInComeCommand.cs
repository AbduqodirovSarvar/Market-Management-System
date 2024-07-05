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
    public class CreateInComeCommand : IRequest<InCome>
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateOnly ExpirationAt { get; set; }
        [Required]
        public int Percentage { get; set; }
    }
}

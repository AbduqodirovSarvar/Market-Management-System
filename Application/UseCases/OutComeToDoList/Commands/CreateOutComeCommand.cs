using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OutComeToDoList.Commands
{
    public class CreateOutComeCommand : IRequest<OutCome>
    {
        [Required]
        public Guid InComeId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}

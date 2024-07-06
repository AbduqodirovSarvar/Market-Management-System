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
    public class UpdateOutComeCommand : IRequest<OutCome>
    {
        [Required]
        public Guid Id { get; set; }
        public int? Amount { get; set; } = null;
    }
}

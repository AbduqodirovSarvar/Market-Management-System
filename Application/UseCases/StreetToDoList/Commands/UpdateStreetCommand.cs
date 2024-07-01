using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.StreetToDoList.Commands
{
    public class UpdateStreetCommand : IRequest<Street>
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? DistrictId { get; set; } = null;
        public string? NameUz { get; set; } = null;
        public string? NameEn { get; set; } = null;
        public string? NameRu { get; set; } = null;
    }
}

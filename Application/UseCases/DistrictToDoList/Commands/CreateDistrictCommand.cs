using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DistrictToDoList.Commands
{
    public class CreateDistrictCommand : IRequest<District>
    {
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public string NameUz { get; set; } = null!;
        [Required]
        public string NameEn { get; set; } = null!;
        [Required]
        public string NameRu { get; set; } = null!;
    }
}

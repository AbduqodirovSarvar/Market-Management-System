using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DistrictToDoList.Queries
{
    public class GetAllDistrictQuery : IRequest<List<District>>
    {
        public string? SearchText { get; set; } = null;
        public Guid? RegionId { get; set; } = null;
    }
}

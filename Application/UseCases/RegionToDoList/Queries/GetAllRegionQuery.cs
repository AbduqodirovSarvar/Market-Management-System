using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RegionToDoList.Queries
{
    public class GetAllRegionQuery : IRequest<List<Region>>
    {
        public string? SearchText { get; set; } = null;
        public Guid? CountryId { get; set; } = null;
    }
}

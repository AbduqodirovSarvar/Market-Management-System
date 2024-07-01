using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.StreetToDoList.Queries
{
    public class GetAllStreetQuery : IRequest<List<Street>>
    {
        public string? SearchText { get; set; } = null;
        public Guid? DistrictId { get; set; } = null;
    }
}

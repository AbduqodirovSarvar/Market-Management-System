using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MeasureOfTypetoDoList.Queries
{
    public class GetAllMeasureOfTypeQuery : IRequest<List<MeasureOfType>>
    {
        public string? SearchText { get; set; } = null;
    }
}

using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductTypeToDoList.Queries
{
    public class GetAllProductTypeQuery : IRequest<List<ProductType>>
    {
        public string? SearchText { get; set; } = null;
        public Guid? MeasureOfTypeId { get; set; } = null;
    }
}

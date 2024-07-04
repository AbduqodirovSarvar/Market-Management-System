using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductToDoList.Queries
{
    public class GetAllProductQuery : IRequest<List<Product>>
    {
        public Guid? ProductTypeId { get; set; } = null;
        public string? SearchText { get; set; } = null;
    }
}

using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductPriceToDoList.Queries
{
    public class GetAllProductPriceQuery : IRequest<List<ProductPrice>>
    {
        public Guid? ProductId { get; set; } = null;
    }
}

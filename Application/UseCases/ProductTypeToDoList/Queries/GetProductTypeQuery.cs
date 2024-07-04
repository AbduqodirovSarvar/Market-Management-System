using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductTypeToDoList.Queries
{
    public class GetProductTypeQuery : IRequest<ProductType>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

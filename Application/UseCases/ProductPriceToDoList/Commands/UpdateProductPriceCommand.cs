using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductPriceToDoList.Commands
{
    public class UpdateProductPriceCommand : IRequest<ProductPrice>
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; } = null;
        public decimal? Price { get; set; } = null;
    }
}

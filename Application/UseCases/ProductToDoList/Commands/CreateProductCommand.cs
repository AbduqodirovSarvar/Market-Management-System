﻿using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductToDoList.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string NameUz { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string NameRu { get; set; } = null!;
        public string DescriptionUz { get; set; } = null!;
        public string DescriptionEn { get; set; } = null!;
        public string DescriptionRu { get; set; } = null!; 
        public Guid ProductTypeId { get; set; }
        public IFormFile? Image { get; set; }
    }
}

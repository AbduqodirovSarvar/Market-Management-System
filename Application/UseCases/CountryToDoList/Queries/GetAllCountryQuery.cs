using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CountryToDoList.Queries
{
    public class GetAllCountryQuery : IRequest<List<Country>>
    {
        public string? SearchText { get; set; } = null;
    }
}

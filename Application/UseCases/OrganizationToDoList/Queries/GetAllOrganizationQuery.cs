using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OrganizationToDoList.Queries
{
    public class GetAllOrganizationQuery : IRequest<List<Organization>>
    {
        public string? SearchText { get; set; } = null;
    }
}

using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RoleToDoList.Queries
{
    public class GetAllUserRoleQuery : IRequest<List<UserRole>>
    {
        public string? SearchText { get; set; } = null;
    }
}

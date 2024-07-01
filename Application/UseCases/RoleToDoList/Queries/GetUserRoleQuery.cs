using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RoleToDoList.Queries
{
    public class GetUserRoleQuery : IRequest<UserRole>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

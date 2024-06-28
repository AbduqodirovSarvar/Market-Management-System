using Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.UserToDoList.Queries
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public string? Id { get; set; } = null;
        [EmailAddress]
        public string? Email { get; set; } = null;
        [Phone]
        public string? Phone {  get; set; } = null;
    }
}

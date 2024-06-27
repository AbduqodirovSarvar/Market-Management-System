using Application.Models.ViewModels;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth.Commands
{
    public class RegisterCommand : IRequest<UserViewModel>
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; } = null!;
        public Gender Gender { get; set; } = Gender.None;
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
        public Guid RoleId { get; set; }
    }
}

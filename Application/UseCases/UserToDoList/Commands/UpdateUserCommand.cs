using Application.Models.ViewModels;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.UserToDoList.Commands
{
    public class UpdateUserCommand : IRequest<UserViewModel>
    {
        [Required]
        public Guid Id { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        [EmailAddress]
        public string? Email { get; set; } = null;
        [Phone]
        public string? Phone { get; set; } = null;
        public Gender? Gender { get; set; } = null;
        public string? NewPassword { get; set; } = null;
        public string? ConfirmPassword { get; set; } = null;
        public string? OldPassword { get; set; } = null;
        public Guid? RoleId { get; set; } = null;
        public Guid? OrganizationId { get; set; } = null;
    }
}

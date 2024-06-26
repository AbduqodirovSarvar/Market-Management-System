using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public abstract class PersonBaseEntity : AudiTableEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string Phone {  get; set; } = null!;
        public Gender Gender { get; set; } = Gender.None;
    }
}

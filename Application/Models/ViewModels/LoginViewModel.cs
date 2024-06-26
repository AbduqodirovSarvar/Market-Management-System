using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ViewModels
{
    public class LoginViewModel
    {
        public UserViewModel? User { get; set; }
        public string? AccessToken { get; set; }
    }
}

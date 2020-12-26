using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPINetCore.Models
{
    public class ChangePasswordRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string OldPassword { get; set; }
             
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

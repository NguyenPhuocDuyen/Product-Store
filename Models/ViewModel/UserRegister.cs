using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserRegister : User
    {
        [NotMapped]
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [NotMapped]
        [Required]
        public bool agreeRule { get; set; }

        public bool IsValid(string confirmPassword)
        {
            if (Password != confirmPassword)
            {
                return false;
            }

            return true;
        }
    }
}

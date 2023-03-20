using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserForgotPassword : UserLogin
    {
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không đúng.")]
        public string ConfirmPassword { get; set; } = string.Empty;

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

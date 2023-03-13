using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserRegister : UserLogin
    {
        [Required(ErrorMessage = "Tên không được bỏ trống")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Điện thoại không được bỏ trống")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")] 
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không đúng.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        //[Required]
        //public bool agreeRule { get; set; }

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

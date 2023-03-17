using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Email không được bỏ trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng. Ví dụ: user@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật Khẩu không được bỏ trống")]
        [MinLength(6, ErrorMessage = "Độ dài tối thiểu 6 ký tự")]
        public string Password { get; set; } = string.Empty;
    }
}

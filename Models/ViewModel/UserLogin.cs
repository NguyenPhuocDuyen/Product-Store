﻿using System;
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
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Vui lòng nhập địa chỉ email hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật Khẩu không được bỏ trống")]
        [MinLength(6, ErrorMessage = "Độ dài tối thiểu 6 ký tự")]
        public string Password { get; set; } = string.Empty;
    }
}

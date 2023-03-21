using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel
{
    public class UserRegister : UserForgotPassword
    {
        [Required(ErrorMessage = "Tên không được bỏ trống")]
        public string FullName { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Số điện thoại sai")]
        [Required(ErrorMessage = "Điện thoại không được bỏ trống")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string Address { get; set; } = string.Empty;
    }
}

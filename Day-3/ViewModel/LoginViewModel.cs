using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.ViewModel
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nhập Tài Khoản!")]
        [StringLength(100)]
        public string Username { get; set; }
        [Required(ErrorMessage ="Nhập Mật Khẩu!")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

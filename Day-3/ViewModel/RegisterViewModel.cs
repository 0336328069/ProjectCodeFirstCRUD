using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.ViewModel
{
    public class RegisterViewModel
    {
    
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}

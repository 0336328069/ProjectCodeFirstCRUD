using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.ViewModel
{
    public class InsertProductsViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        [Display(Name = "Chọn file upload")]
        [BindProperty]
        public IFormFile UploadImage { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}

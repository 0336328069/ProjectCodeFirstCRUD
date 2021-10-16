using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.ViewModel
{
    public class UpdateProductsViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Image { get; set; }
        
        [DataType(DataType.Upload)]
        [Display(Name = "Chọn file upload")]
        [BindProperty]
        public IFormFile UploadImage { get; set; }
        
        public int Price { get; set; }
        
        public int CategoryId { get; set; }
    }
}

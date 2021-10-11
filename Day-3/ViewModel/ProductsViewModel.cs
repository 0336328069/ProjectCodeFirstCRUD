﻿using Day_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.ViewModel
{
    public class ProductsViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Chọn file upload")]
        [BindProperty]
        public IFormFile UploadImage { get; set; }
        public int Price { get; set; }
       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

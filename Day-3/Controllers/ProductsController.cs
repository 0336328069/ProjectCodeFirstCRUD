using Day_3.Models;
using Day_3.Services;
using Day_3.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct product;
        private readonly IWebHostEnvironment environment;
        public ProductsController(IProduct product, IWebHostEnvironment environment)
        {
            this.product = product;
            this.environment = environment;
        }
        
        
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewData["Products"]=product.Gets(id);
            return View();
        }
        public IActionResult Check(string name)
        {
            ViewBag.Products = product.Check(name);
            return View();
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(InsertProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UploadImage != null)
                {
                    var c = new Product();
                    var imageFolder = Path.Combine(environment.WebRootPath, "Img");
                    var uniqueFilename = Guid.NewGuid().ToString() + "_" + model.UploadImage.FileName;
                    var filePath = Path.Combine(imageFolder, uniqueFilename);
                    using (var filestream = new FileStream(filePath, FileMode.Create))
                    {
                        model.UploadImage.CopyTo(filestream);
                    }
                    c.Name = model.Name;
                    c.Image = model.UploadImage.FileName;
                    c.CategoryId = model.CategoryId;
                    c.Price = model.Price;
                    product.Create(c);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("~/Views/Products/Insert.cshtml", model);
        }
        public IActionResult Delete(int id)
        {
            product.Delete(id);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var p = product.Get(id);
            var pr = new UpdateProductsViewModel()
            {
               Id=p.Id,
               CategoryId=p.CategoryId,
               Image=p.Image,
               Name=p.Name,
               Price=p.Price
            };
            return View(pr);
        }
        [HttpPost]
        public IActionResult Update(UpdateProductsViewModel model)
        {

            var c = product.Get(model.Id);
            if (model.UploadImage != null)
            {
                
                var imageFolder = Path.Combine(environment.WebRootPath, "Img");
                var uniqueFilename = Guid.NewGuid().ToString() + "_" + model.UploadImage.FileName;
                var filePath = Path.Combine(imageFolder, uniqueFilename);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    model.UploadImage.CopyTo(filestream);
                }
                c.Image = model.UploadImage.FileName;
                c.Name = model.Name;
                c.Price = model.Price;
                c.CategoryId = model.CategoryId;

            }
            else
            {
                c.Image = model.Image;
                c.Name = model.Name;
                c.Price = model.Price;
                c.CategoryId = model.CategoryId;
            }
            product.Edit(c);
            product.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}

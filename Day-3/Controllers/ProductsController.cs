using Day_3.Models;
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
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(AppDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        
        
        [HttpGet]
        public IActionResult Index(int id)
        {
        
            List<ProductsViewModel> list = new List<ProductsViewModel>();
            foreach(var p in _db.Products)
            {
                if(id == p.CategoryId) {  
                var newP = new ProductsViewModel()
                {
                    CategoryId = p.CategoryId,
                    Id = p.Id,
                    Image = p.Image,
                    Name = p.Name,
                    Price = p.Price
                };
                list.Add(newP);
                }
            }
            return View(list);
        }
        public IActionResult Check(string name)
        {
            var List = new List<ProductsViewModel>();
            var list = _db.Products.Where(p => p.Name.Contains(name)).ToList();
            foreach(var p in list)
            {
                var productvm = new ProductsViewModel()
                {
                    Id = p.Id,
                    Image = p.Image,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                };
                List.Add(productvm);
            }
            return View(List);
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
                    var imageFolder = Path.Combine(_environment.WebRootPath, "Img");
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
                    _db.Products.Add(c);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("~/Views/Products/Insert.cshtml",model);
        }
        public IActionResult Delete(int id)
        {
            var c = _db.Products.FirstOrDefault(p => p.Id == id);
            _db.Products.Remove(c);
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var c = _db.Products.FirstOrDefault(p => p.Id == id);
            var pr = new UpdateProductsViewModel()
            {
                Id = c.Id,
                CategoryId = c.CategoryId,
                Image = c.Image,
                Name = c.Name,
                Price = c.Price
            };
            return View(pr);
        }
        [HttpPost]
        public IActionResult Update(UpdateProductsViewModel model)
        {
            var c = _db.Products.FirstOrDefault(p=>p.Id==model.Id);

            if (model.UploadImage != null)
            {
                var imageFolder = Path.Combine(_environment.WebRootPath, "Img");
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
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
          }
    }
}

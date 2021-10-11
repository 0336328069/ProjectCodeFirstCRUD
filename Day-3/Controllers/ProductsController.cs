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
            var list = _db.Products.Where(p => p.CategoryId == id).ToList();
            return View(list);
        }
        public IActionResult Check(string name)
        {
            var List = _db.Products.Where(p => p.Name.Contains(name)).ToList();
            return View(List);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(ProductsViewModel model)
        {
            var upload = Path.Combine(_environment.WebRootPath, "Img", model.UploadImage.FileName);
            using (var filestream = new FileStream(upload, FileMode.Create))
            {
                model.UploadImage.CopyTo(filestream);
            }
            var p = new Product()
            {
                Name = model.Name,
                Image = model.UploadImage.FileName,
                CategoryId = model.CategoryId,
                Price = model.Price
            };
            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
            var pr = new ProductsViewModel()
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
        public IActionResult Update(ProductsViewModel model)
        {
            var c = _db.Products.FirstOrDefault(p=>p.Id==model.Id);

            if (model.UploadImage != null)
            {
                var upload = Path.Combine(_environment.WebRootPath,"Img",model.UploadImage.FileName);
                using (var filestream = new FileStream(upload, FileMode.Create))
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

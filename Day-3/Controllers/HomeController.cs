using Day_3.Models;
using Day_3.Services;
using Day_3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IProduct product;
       
        public HomeController(IProduct product)
        {
            this.product = product;
        }
        public IActionResult Index()
        {
            List<ProductsViewModel> List = new List<ProductsViewModel>();
            var products = product.Gets();
            foreach(var product in products)
            {
                var p = new ProductsViewModel()
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Image = product.Image,
                    Name = product.Name,
                    Price = product.Price
                };
                List.Add(p);
            }
            return View(List);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

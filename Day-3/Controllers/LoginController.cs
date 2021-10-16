using Day_3.Models;
using Day_3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;
        public LoginController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
 
        public IActionResult  Login(LoginViewModel model)
        {
            IEnumerable<User> list = _db.Users;
            if (ModelState.IsValid)
            {
                foreach (var u in list)
                {
                    if (u.Username == model.Username && u.Password == u.Password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View("~/Views/Login/Index.cshtml", model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            IEnumerable<User> list = _db.Users;
            if (ModelState.IsValid)
            {
                foreach (var u in list)
                {
                    if (u.Username != model.Username || model.Password == model.RepeatPassword)
                    {
                        var c = new User()
                        {
                            Id = model.Id,
                            Username = model.Username,
                            Password = model.Password
                        };
                        _db.Users.Add(c);
                        break;
                        
                    }
                }
            } 
            _db.SaveChanges();
            return View("~/Views/Login/Register.cshtml", model);
        }
    }
}

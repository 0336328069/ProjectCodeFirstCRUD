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
        public IActionResult  Login(UserViewModel model)
        {
            var list = _db.Users.ToList();
            foreach(var u in list)
            {
                if(u.Username==model.Username&&u.Password==model.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Register(RegisterViewModel model)
        {
            var list = _db.Users.ToList();
            foreach(var u in list)
            {
                if(u.Username==model.Username||model.Password!=model.RepeatPassword)
                {
                    return RedirectToAction("Register", "Login"); 
                }
                else
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
            _db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}

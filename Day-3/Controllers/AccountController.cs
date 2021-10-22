using Day_3.Models;
using Day_3.Services;
using Day_3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Controllers
{
    public class AccountController : Controller
    {
        private IAccount account;
        public AccountController(IAccount account)
        {
            this.account = account;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]

        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var u in account.Gets())
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
            if (ModelState.IsValid)
            {
                foreach (var u in account.Gets())
                {
                    if (u.Username != model.Username || model.Password == model.RepeatPassword)
                    {
                        var c = new User()
                        {
                            Id = model.Id,
                            Username = model.Username,
                            Password = model.Password
                        };
                        account.Create(c);
                        break;

                    }
                }
            }
            account.Save();
            return View("~/Views/Login/Register.cshtml", model);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult ChangePassword(ChangePasswordViewModel model)
        //{

        //    var user = account.Get(name);
        //    if(user.Password==model.Password && model.NewPassword==model.RepeatNewPassword)
        //    {
        //        user.Password = model.NewPassword;
        //        account.Edit(user);
        //    }
        //    account.Save();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
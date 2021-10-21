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
    public class StaffController : Controller
    {
        private readonly IStaff staff;
        public StaffController(IStaff staff)
        {
            this.staff = staff;
        }
        public IActionResult Index()
        {
            List<StaffViewModel> List = new List<StaffViewModel>();
            foreach(var s in staff.Gets())
            {
                var staffvm = new StaffViewModel()
                {
                    Id = s.Id,
                    Name = s.Name
                };
                List.Add(staffvm);
            };
            return View(List);
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            var st = staff.Get(id);
            var s = new InfoStaffViewModel()
            {
                Id = st.Id,
                Name = st.Name,
                Age = st.Age,
                Birthday = st.Birthday,
                Email = st.Email,
                Address = st.Address
            };
            return View(s);
        }
        
        public IActionResult Update(InfoStaffViewModel model)
        {
            var st = staff.Get(model.Id);
            st.Id = model.Id;
            st.Name = model.Name;
            st.Age = model.Age;
            st.Birthday = model.Birthday;
            st.Email = model.Email;
            st.Address = model.Address;
            staff.Edit(st);
            staff.Save();
            return View("~/Views/Staff/Index.cshtml");
        }
        public  IActionResult Delete(InfoStaffViewModel model)
        {
            staff.Delete(model.Id);
            staff.Save();
            return View("~/Views/Staff/Index.cshtml");
        }

    }
}

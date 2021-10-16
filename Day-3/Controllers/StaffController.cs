using Day_3.Models;
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
        private readonly AppDbContext _db;
        public StaffController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Staff> list = _db.Staffs;
            List<StaffViewModel> List = new List<StaffViewModel>();
            foreach(var s in list)
            {
                var staffvm = new StaffViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age,
                    Email = s.Email,
                    Birthday = s.Birthday,
                    Address = s.Address
                };
                List.Add(staffvm);
            };
            return View(List);
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            var st = _db.Staffs.FirstOrDefault(s => s.Id == id);
            var s = new StaffViewModel()
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
        
        public IActionResult Update(StaffViewModel model)
        {
            var st = _db.Staffs.FirstOrDefault(s => s.Id == model.Id);
            st.Id = model.Id;
            st.Name = model.Name;
            st.Age = model.Age;
            st.Birthday = model.Birthday;
            st.Email = model.Email;
            st.Address = model.Address;
            _db.SaveChanges();
            return RedirectToAction("Index","Staff");
        }
        public  IActionResult Delete(StaffViewModel model)
        {
            var s = _db.Staffs.FirstOrDefault(s => s.Id == model.Id);
            _db.Remove(s);
            _db.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }

    }
}

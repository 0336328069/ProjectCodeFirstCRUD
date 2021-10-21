using Day_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Services
{
    public class StaffRepository : IStaff
    {
        private AppDbContext context;
        public StaffRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Staff s)
        {
            context.Staffs.Add(s);
        }

        public void Delete(int id)
        {
            var s = context.Staffs.Find(id);
            context.Remove(s);
        }

        public void Edit(Staff s)
        {
            context.Entry(s).State = EntityState.Modified;
        }

        public Staff Get(int id)
        {
            return context.Staffs.Find(id);
        }

        public IEnumerable<Staff> Gets()
        {
            return context.Staffs.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

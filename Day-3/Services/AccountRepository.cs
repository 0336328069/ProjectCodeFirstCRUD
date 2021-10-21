using Day_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Services
{
    public class AccountRepository : IAccount
    {
        private readonly AppDbContext context;
        public AccountRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(User u)
        {
            context.Add(u);
        }

        public void Edit(User u)
        {
            context.Entry(u).State = EntityState.Modified;
        }

        public User Get(string name)
        {
            return context.Users.Find(name);
        }

        public IEnumerable<User> Gets()
        {
            return context.Users.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

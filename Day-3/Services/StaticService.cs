using Day_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Services
{
    public class StaticService
    {
        private readonly AppDbContext context;
        public StaticService(AppDbContext context)
        {
            this.context = context;
        }
        public int Quantity()
        {
            return context.Products.Count();
        }
    }
}

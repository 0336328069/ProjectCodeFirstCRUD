using Day_3.Models;
using Day_3.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Services
{
    public class ProductRepository : IProduct
    {
        private readonly AppDbContext context;
        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Check(string name)
        {
            return context.Products.Where(p => p.Name.Contains(name)).ToList();
        }

        public void Create(Product p)
        {
            context.Products.Add(p);
        }

        public void Delete(int id)
        {
            var deleteProduct = context.Products.Find(id);
            context.Products.Remove(deleteProduct);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Product Get(int id)
        {
            var getProduct = context.Products.Find(id);
            return getProduct;
        }

        public IEnumerable<Product> Gets(int id)
        {
            return context.Products.Where(p=>p.CategoryId==id).ToList();
        }

        public void Edit(Product p)
        {
            context.Entry(p).State = EntityState.Modified;
        }

        public IEnumerable<Product> Gets()
        {
            return context.Products.ToList();
        }
    }
}

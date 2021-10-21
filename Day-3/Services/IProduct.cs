using Day_3.Models;
using Day_3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Services
{
    public interface IProduct
    {
        IEnumerable<Product> Gets();
        IEnumerable<Product> Gets(int id);
        IEnumerable<Product> Check(string name);
        Product Get(int id);
        void Create(Product p);
        void Save();
        void Edit(Product p);
        void Delete(int id);
    }
}

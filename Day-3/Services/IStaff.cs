using Day_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Services
{
    public interface IStaff
    {
        IEnumerable<Staff> Gets();
        Staff Get(int id);
        void Create(Staff s);
        void Edit(Staff s);
        void Delete(int id);

        void Save();
    }
}

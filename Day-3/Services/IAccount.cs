using Day_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Services
{
    public interface IAccount
    {
        IEnumerable<User> Gets();
        User Get(string name);
        void Create(User u);
        void Edit(User u);
        void Save();
    }
}
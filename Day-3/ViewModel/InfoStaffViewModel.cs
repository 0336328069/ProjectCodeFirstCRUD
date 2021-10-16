using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.ViewModel
{
    public class InfoStaffViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}

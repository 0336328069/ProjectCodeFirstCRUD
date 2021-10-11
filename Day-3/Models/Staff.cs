using Day_3.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day_3.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

        public static implicit operator Staff(StaffViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}

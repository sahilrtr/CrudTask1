using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Department Department { get; set; }
        public int Salary { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
    }
}

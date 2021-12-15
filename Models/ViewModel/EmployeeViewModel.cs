using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int DepartmentDid { get; set; }
        public int Salary { get; set; }
        public int AddressAid { get; set; }
        public bool IsActive { get; set; }

    }
}

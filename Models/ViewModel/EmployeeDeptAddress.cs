using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models.ViewModel
{
    public class EmployeeDeptAddress
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string FirstAddress { get; set; }
        public int Pincode { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }


    }
}

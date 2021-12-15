using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models.ViewModel
{
    public class AddressViewModel
    {
        public string FirstAddress { get; set; }
        public string SecondAddress { get; set; }
        public int Pincode { get; set; }

        public int CityCtId { get; set; }
        public int StateSid { get; set; }
        public int CountryCnid { get; set; }
    }
}

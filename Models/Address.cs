using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models
{
    public class Address
    {
        [Key]
        public int Aid { get; set; }
        public string FirstAddress { get; set; }
        public string SecondAddress { get; set; }
        public int Pincode { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}

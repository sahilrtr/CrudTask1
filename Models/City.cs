using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models
{
    public class City
    {
        [Key]
        public int CtId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public State State { get; set; }

    }
}

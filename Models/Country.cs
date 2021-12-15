using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models
{
    public class Country
    {
        [Key]
        public int Cnid { get; set; }
        public string    CountryName { get; set; }
        public string    CountryCode { get; set; }

    }
}

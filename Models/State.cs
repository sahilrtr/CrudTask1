using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models
{
    public class State
    {
        [Key]
        public int Sid { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public Country Country { get; set; }
    }
}

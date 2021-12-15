using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models
{
    public class Department
    {
        [Key]
        public int Did { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

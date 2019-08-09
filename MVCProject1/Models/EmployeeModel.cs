using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject1.Models
{

    public class EmployeeModel
    {
        public int EID { get; set; }

        [Required(ErrorMessage="This field is Required")]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; } 
        public Nullable<int> Salary { get; set; }
    }
}
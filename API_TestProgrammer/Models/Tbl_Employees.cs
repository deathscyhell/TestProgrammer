﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammer_API.Models
{
    public class Tbl_Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int PositionID { get; set; }
        public int ProfileID { get; set; }

        //Relaciones
        [JsonIgnore]
        public virtual Tbl_Positions Positions { get; set; }
         [JsonIgnore]
        public virtual Tbl_Profiles Profiles { get; set; }

    }
}

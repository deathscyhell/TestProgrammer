using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammer_API.Models
{
    public class Tbl_Positions
    {
        [Key]
        public int PositionID { get; set; }
        [Display(Name = "Name")]
        [MinLength(50)]
        public string PositionName { get; set; }
    }
}

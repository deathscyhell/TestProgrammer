using System;
using System.Collections.Generic;
using System.Text;

namespace APP_TestProgrammer.Model
{
    public class Employees
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public int positionID { get; set; }
        public int profileID { get; set; }

        //Relaciones

        public Profile Profile { get; set; }
        public Position Position { get; set; }
    }
}

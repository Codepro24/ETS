using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Domain
{
    public class EmpHrs
    {
        //public int EmpHrsID { get; set; }
        public int EmpID { get; set; }
        public string WorkDate { get; set; }
        public int Hours { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineStatusClient.Models
{
    public class LineShift
    {
        public int ID { get; set; }
        public string LineCode { get; set; }
        public int WorkShiftID { get; set; }
    }

    public class LineShiftDTO: LineShift
    {
        public string Line_nm { get; set; }
    }

    public class LineShiftDT0_W: LineShift
    {
        public int ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}

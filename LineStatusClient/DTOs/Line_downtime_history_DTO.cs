using LineStatusClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineStatusClient.DTOs
{
    public class Line_downtime_history_DTO : Line_downtime_history
    {
        public string status_text { get; set; }
        public string shift_text { get; set; }
        public string line_nm { get; set; }
        public string TotalRunningTime { get; set; }
        public string TotalDowntime { get; set; }
        public DateTime WorkDate { get; set; }

    }
}

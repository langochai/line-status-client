using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineStatusClient.Models
{
    public class LineEmailConfig
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}

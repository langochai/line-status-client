using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineStatusClient.Models
{
    public class SystemSettings
    {
        public int ID { get; set; }
        public string ConfigName { get; set; }
        public int ConfigValue { get; set; }
        public string Password { get; set; }
    }
}

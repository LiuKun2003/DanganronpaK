using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DialoguesDefine
    {
        public int Key { get; set; }
        public string Dialogue { get; set; }
        public int Next { get; set; }
        public string Effects { get; set; }
    }
}

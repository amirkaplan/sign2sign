using sign2sign.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sign2sign.bo
{
    public class Layout
    {
        public int id { get; set; }
        public string name { get; set; }
    
        public ICollection<Window> windows { get; set; }
    }
}

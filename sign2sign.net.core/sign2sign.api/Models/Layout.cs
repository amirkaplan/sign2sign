using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Layout
    {
        public Layout()
        {
            Windows = new HashSet<Window>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Window> Windows { get; set; }
    }
}

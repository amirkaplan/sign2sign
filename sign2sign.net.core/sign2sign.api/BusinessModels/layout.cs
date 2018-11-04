using System;
using System.Collections.Generic;

namespace sign2sign.api.BusinessModels
{
    public partial class layout
    {
        public layout()
        {
            Windows = new HashSet<window>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<window> Windows { get; set; }
    }
}

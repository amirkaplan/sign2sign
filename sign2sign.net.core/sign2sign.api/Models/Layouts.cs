using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Layouts
    {
        public Layouts()
        {
            Screens = new HashSet<Screens>();
            Windows = new HashSet<Windows>();
        }

        public int Id { get; set; }
        public string Template { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Deleted { get; set; }
        public int? Art { get; set; }

        public ICollection<Screens> Screens { get; set; }
        public ICollection<Windows> Windows { get; set; }
    }
}

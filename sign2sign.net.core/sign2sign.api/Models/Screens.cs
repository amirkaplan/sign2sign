using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Screens
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Loaction { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public int? LayoutId { get; set; }
        public int? PlayerId { get; set; }
        public int? Deleted { get; set; }

        public Layouts Layout { get; set; }
        public Players Player { get; set; }
    }
}

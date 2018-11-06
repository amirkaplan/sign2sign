using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Window
    {
        public Window()
        {

        }

        public int Id { get; set; }
        public int? LayoutId { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? ZIndex { get; set; }
        public int? Deleted { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
    }
}

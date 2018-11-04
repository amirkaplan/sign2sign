using System;
using System.Collections.Generic;

namespace sign2sign.api.BusinessModels
{
    public partial class window
    {
        public window() { }

        public int Id { get; set; }
        public int? LayoutId { get; set; }
        public int? Width { get; set; }
        public int? Hieght { get; set; }
        public int? ZIndex { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }

        public playlist Playlist { get; set; }
    }
}

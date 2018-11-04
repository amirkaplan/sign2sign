using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Windows
    {
        public Windows()
        {
            Played = new HashSet<Played>();
        }

        public int Id { get; set; }
        public int? LayoutId { get; set; }
        public int? Width { get; set; }
        public int? Hieght { get; set; }
        public int? ZIndex { get; set; }
        public int? Deleted { get; set; }
        public int? PlaylistId { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }

        public Layouts Layout { get; set; }
        public Playlists Playlist { get; set; }
        public ICollection<Played> Played { get; set; }
    }
}

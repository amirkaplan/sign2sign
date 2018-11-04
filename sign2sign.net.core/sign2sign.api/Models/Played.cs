using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Played
    {
        public int Id { get; set; }
        public int? PlaylistId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? WindowId { get; set; }
        public int? Duration { get; set; }

        public Playlists Playlist { get; set; }
        public Windows Window { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Content
    {
        public Content()
        {
            Playlists = new HashSet<Playlists>();
        }

        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int? Duration { get; set; }
        public string Text { get; set; }
        public bool? Approved { get; set; }
        public bool? Active { get; set; }
        public bool? Public { get; set; }
        public bool? Deleted { get; set; }
        public string Html { get; set; }

        public Businesses Business { get; set; }
        public Categories Category { get; set; }
        public ICollection<Playlists> Playlists { get; set; }
    }
}

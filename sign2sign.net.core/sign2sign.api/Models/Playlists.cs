using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Playlists
    {
        public Playlists()
        {
            Played = new HashSet<Played>();
            Windows = new HashSet<Windows>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BusinessId { get; set; }
        public int ContentId { get; set; }
        public bool? Public { get; set; }

        public Businesses Business { get; set; }
        public Content Content { get; set; }
        public ICollection<Played> Played { get; set; }
        public ICollection<Windows> Windows { get; set; }
    }
}

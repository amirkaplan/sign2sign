using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Businesses
    {
        public Businesses()
        {
            Content = new HashSet<Content>();
            Players = new HashSet<Players>();
            Playlists = new HashSet<Playlists>();
            Promotions = new HashSet<Promotions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }

        public ICollection<Content> Content { get; set; }
        public ICollection<Players> Players { get; set; }
        public ICollection<Playlists> Playlists { get; set; }
        public ICollection<Promotions> Promotions { get; set; }
    }
}

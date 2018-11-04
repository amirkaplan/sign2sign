using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Players
    {
        public Players()
        {
            Screens = new HashSet<Screens>();
        }

        public int Id { get; set; }
        public int? BusinessId { get; set; }

        public Businesses Business { get; set; }
        public ICollection<Screens> Screens { get; set; }
    }
}

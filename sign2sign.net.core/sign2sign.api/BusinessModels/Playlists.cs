using System;
using System.Collections.Generic;

namespace sign2sign.api.BusinessModels
{
    public partial class playlist
    {
        public playlist() {
            Contents = new HashSet<content>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<content> Contents { get; set; }
    }
}

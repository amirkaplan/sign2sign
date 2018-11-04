using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Promotions
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int CategotyId { get; set; }
        public bool? Allow { get; set; }
        public bool? Deny { get; set; }
        public double? Distance { get; set; }

        public Businesses Business { get; set; }
        public Categories Categoty { get; set; }
    }
}

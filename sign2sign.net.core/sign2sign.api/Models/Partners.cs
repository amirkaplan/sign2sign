using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Partners
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public int? PartnerId { get; set; }
    }
}

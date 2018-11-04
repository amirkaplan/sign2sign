using System;
using System.Collections.Generic;

namespace sign2sign.api.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Content = new HashSet<Content>();
            InverseCategory = new HashSet<Categories>();
            Promotions = new HashSet<Promotions>();
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public int? CategoryId { get; set; }

        public Categories Category { get; set; }
        public ICollection<Content> Content { get; set; }
        public ICollection<Categories> InverseCategory { get; set; }
        public ICollection<Promotions> Promotions { get; set; }
    }
}

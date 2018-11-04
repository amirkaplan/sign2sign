using System;
using System.Collections.Generic;

namespace sign2sign.api.BusinessModels
{
    public partial class content
    {
        public content() {}

        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int? Duration { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sign2sign.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class screen
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string loaction { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public Nullable<int> layout_id { get; set; }
        public Nullable<int> player_id { get; set; }
        public Nullable<int> deleted { get; set; }
    
        public virtual layout layout { get; set; }
        public virtual player player { get; set; }
    }
}

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
    
    public partial class business
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public business()
        {
            this.contents = new HashSet<content>();
            this.players = new HashSet<player>();
            this.playlists = new HashSet<playlist>();
            this.promotions = new HashSet<promotion>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string logo { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string web_site { get; set; }
        public string address { get; set; }
        public string user_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<content> contents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player> players { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<playlist> playlists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<promotion> promotions { get; set; }
    }
}

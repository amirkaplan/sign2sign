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
    
    public partial class playlist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public playlist()
        {
            this.playeds = new HashSet<played>();
            this.windows = new HashSet<window>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int business_id { get; set; }
        public int content_id { get; set; }
        public Nullable<bool> @public { get; set; }
    
        public virtual business business { get; set; }
        public virtual content content { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<played> playeds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<window> windows { get; set; }
    }
}

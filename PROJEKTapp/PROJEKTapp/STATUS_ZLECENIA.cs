//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJEKTapp
{
    using System;
    using System.Collections.Generic;
    
    public partial class STATUS_ZLECENIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STATUS_ZLECENIA()
        {
            this.ZLECENIA = new HashSet<ZLECENIA>();
        }
    
        public int ID_STATUSU_ZLECENIA { get; set; }
        public string ETAP { get; set; }
        public Nullable<System.DateTime> DATA_ZMIANY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZLECENIA> ZLECENIA { get; set; }
    }
}
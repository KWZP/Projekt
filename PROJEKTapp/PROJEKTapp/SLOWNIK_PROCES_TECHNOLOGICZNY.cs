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
    
    public partial class SLOWNIK_PROCES_TECHNOLOGICZNY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SLOWNIK_PROCES_TECHNOLOGICZNY()
        {
            this.PROCES = new HashSet<PROCES>();
        }
    
        public int ID_SLOWNIK_PROCES_TECHNOLOGICZNY { get; set; }
        public string NAZWA_PROCESU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROCES> PROCES { get; set; }
    }
}

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
    
    public partial class ADRESY_PRACOWNICY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADRESY_PRACOWNICY()
        {
            this.PRACOWNICY = new HashSet<PRACOWNICY>();
        }
    
        public int ID_ADRESU { get; set; }
        public string ULICA { get; set; }
        public string NR_BUDYNKU { get; set; }
        public string NR_LOKALU { get; set; }
        public string KOD_POCZTOWY { get; set; }
        public Nullable<int> ID_MIASTA { get; set; }
        public string KRAJ { get; set; }
    
        public virtual MIASTA MIASTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNICY> PRACOWNICY { get; set; }
    }
}


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
    
public partial class PROJEKT
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PROJEKT()
    {

        this.DOKUMENTACJA = new HashSet<DOKUMENTACJA>();

    }


    public int ID_PROJEKTU { get; set; }

    public bool CZY_ISTNIEJE { get; set; }

    public decimal KOSZT { get; set; }

    public System.DateTime CZAS_REALIZACJI { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DOKUMENTACJA> DOKUMENTACJA { get; set; }

}

}

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
    
    public partial class FAKTURY
    {

        public int ID_FAKTURY { get; set; }
        public Nullable<int> ID_ZLECENIA { get; set; }
        public Nullable<int> ID_PRACOWNIKA { get; set; }
        public Nullable<System.DateTime> DATA_WYSTAWIENIA { get; set; }
        public Nullable<System.DateTime> DATA_PLATNOSCI { get; set; }
        public Nullable<decimal> KWOTA { get; set; }
        public string WALUTA { get; set; }
    
        public virtual PRACOWNICY PRACOWNICY { get; set; }
        public virtual ZLECENIA ZLECENIA { get; set; }
    }
}

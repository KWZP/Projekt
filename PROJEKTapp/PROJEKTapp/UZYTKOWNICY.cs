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
    
    public partial class UZYTKOWNICY
    {
        public int ID_UZYTKOWNIKA { get; set; }
        public Nullable<int> ID_PRACOWNIK { get; set; }
        public int UPRAWNIENIA { get; set; }
        public string NAZWA_LOGOWANIE { get; set; }
        public string HASLO { get; set; }
    
        public virtual UPRAWNIENIA UPRAWNIENIA1 { get; set; }
        public virtual PRACOWNICY PRACOWNICY { get; set; }
    }
}


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
    
public partial class PROCES
{

    public int ID_PROCESU { get; set; }

    public Nullable<int> ID_SLOWNIK_PROCES_TECHNOLOGICZNY { get; set; }

    public Nullable<int> ID_MASZYNY { get; set; }

    public Nullable<int> CZAS_TRWANIA { get; set; }



    public virtual MASZYNY MASZYNY { get; set; }

    public virtual SLOWNIK_PROCES_TECHNOLOGICZNY SLOWNIK_PROCES_TECHNOLOGICZNY { get; set; }

}

}

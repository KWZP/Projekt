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
    
    public partial class PARAMETRY_MATERIALU
    {
        public Nullable<int> ID_MATERIAL { get; set; }
        public Nullable<int> ID_PARAMETR { get; set; }
        public int WARTOŚĆ { get; set; }
    
        public virtual PARAMETRY PARAMETRY { get; set; }
        public virtual MATERIAL MATERIAL { get; set; }
    }
}

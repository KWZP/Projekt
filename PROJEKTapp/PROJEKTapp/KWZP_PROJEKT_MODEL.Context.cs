﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KWZP_PROJEKTEntities : DbContext
    {
        public KWZP_PROJEKTEntities()
            : base("name=KWZP_PROJEKTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADRESY> ADRESY { get; set; }
        public virtual DbSet<ADRESY_PRACOWNICY> ADRESY_PRACOWNICY { get; set; }
        public virtual DbSet<DOKUMENTACJA> DOKUMENTACJA { get; set; }
        public virtual DbSet<DOSTAWA> DOSTAWA { get; set; }
        public virtual DbSet<FAKTURY> FAKTURY { get; set; }
        public virtual DbSet<FIRMY> FIRMY { get; set; }
        public virtual DbSet<LOKALIZACJA> LOKALIZACJA { get; set; }
        public virtual DbSet<MASZYNY> MASZYNY { get; set; }
        public virtual DbSet<MATERIAL> MATERIAL { get; set; }
        public virtual DbSet<MIASTA> MIASTA { get; set; }
        public virtual DbSet<MODELE_MASZYN> MODELE_MASZYN { get; set; }
        public virtual DbSet<NARZEDZIA> NARZEDZIA { get; set; }
        public virtual DbSet<OKRES> OKRES { get; set; }
        public virtual DbSet<PARAMETRY> PARAMETRY { get; set; }
        public virtual DbSet<PODATEK> PODATEK { get; set; }
        public virtual DbSet<POJAZDY> POJAZDY { get; set; }
        public virtual DbSet<POLPRODUKTY> POLPRODUKTY { get; set; }
        public virtual DbSet<PRACOWNICY> PRACOWNICY { get; set; }
        public virtual DbSet<PROCES> PROCES { get; set; }
        public virtual DbSet<PRODUKT> PRODUKT { get; set; }
        public virtual DbSet<PROJEKT> PROJEKT { get; set; }
        public virtual DbSet<REALIZACJA_PRODUKCJA> REALIZACJA_PRODUKCJA { get; set; }
        public virtual DbSet<SLOWNIK_PROCES_TECHNOLOGICZNY> SLOWNIK_PROCES_TECHNOLOGICZNY { get; set; }
        public virtual DbSet<STANOWISKO> STANOWISKO { get; set; }
        public virtual DbSet<STANOWISKO_PRACOWNICY> STANOWISKO_PRACOWNICY { get; set; }
        public virtual DbSet<STATUS_ZAMOWIENIA> STATUS_ZAMOWIENIA { get; set; }
        public virtual DbSet<STATUS_ZLECENIA> STATUS_ZLECENIA { get; set; }
        public virtual DbSet<STAWKA> STAWKA { get; set; }
        public virtual DbSet<STAWKA_PRACOWNICY> STAWKA_PRACOWNICY { get; set; }
        public virtual DbSet<SZKOLENIA> SZKOLENIA { get; set; }
        public virtual DbSet<TYPY_ZMIANY_STANU> TYPY_ZMIANY_STANU { get; set; }
        public virtual DbSet<WALUTY> WALUTY { get; set; }
        public virtual DbSet<WOLNE> WOLNE { get; set; }
        public virtual DbSet<WOLNE_PRACOWNICY> WOLNE_PRACOWNICY { get; set; }
        public virtual DbSet<ZAMOWIENIA> ZAMOWIENIA { get; set; }
        public virtual DbSet<ZLECENIA> ZLECENIA { get; set; }
        public virtual DbSet<PARAMETRY_MASZYNY> PARAMETRY_MASZYNY { get; set; }
        public virtual DbSet<PARAMETRY_MATERIALU> PARAMETRY_MATERIALU { get; set; }
        public virtual DbSet<PRODUKCJA_POLPRODUKTU> PRODUKCJA_POLPRODUKTU { get; set; }
    }
}
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
using System.Data.Entity.Core.Objects;
using System.Linq;


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
    public virtual DbSet<MATERIAL> MATERIAL { get; set; }
    public virtual DbSet<MIASTA> MIASTA { get; set; }
    public virtual DbSet<MODELE_MASZYN> MODELE_MASZYN { get; set; }
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
    public virtual DbSet<STATUS_ZLECENIA> STATUS_ZLECENIA { get; set; }
    public virtual DbSet<STAWKA> STAWKA { get; set; }
    public virtual DbSet<STAWKA_PRACOWNICY> STAWKA_PRACOWNICY { get; set; }
    public virtual DbSet<SZKOLENIA> SZKOLENIA { get; set; }
    public virtual DbSet<WALUTY> WALUTY { get; set; }
    public virtual DbSet<WOLNE> WOLNE { get; set; }
    public virtual DbSet<WOLNE_PRACOWNICY> WOLNE_PRACOWNICY { get; set; }
    public virtual DbSet<ZLECENIA> ZLECENIA { get; set; }
    public virtual DbSet<PARAMETRY_MASZYNY> PARAMETRY_MASZYNY { get; set; }
    public virtual DbSet<PARAMETRY_MATERIALU> PARAMETRY_MATERIALU { get; set; }
    public virtual DbSet<PRODUKCJA_POLPRODUKTU> PRODUKCJA_POLPRODUKTU { get; set; }
    public virtual DbSet<WYKORZYSTANE_MASZYNY> WYKORZYSTANE_MASZYNY { get; set; }
    public virtual DbSet<WYKORZYSTANE_NARZEDZIA> WYKORZYSTANE_NARZEDZIA { get; set; }
    public virtual DbSet<WYKORZYSTANE_PROCESY> WYKORZYSTANE_PROCESY { get; set; }
    public virtual DbSet<OBCIAZENIE_MASZYN> OBCIAZENIE_MASZYN { get; set; }
    public virtual DbSet<OBCIAZENIE_NARZEDZI> OBCIAZENIE_NARZEDZI { get; set; }
    public virtual DbSet<GABARYT_PRODUTKU> GABARYT_PRODUTKU { get; set; }
    public virtual DbSet<MASA_PRODUKTU> MASA_PRODUKTU { get; set; }
    public virtual DbSet<PRACOWNICY_STANOWISKA> PRACOWNICY_STANOWISKA { get; set; }
    public virtual DbSet<STAWKA_OKRES> STAWKA_OKRES { get; set; }
    public virtual DbSet<PRACOWNICY_ZATRUDNIENI> PRACOWNICY_ZATRUDNIENI { get; set; }
    public virtual DbSet<UPRAWNIENIA> UPRAWNIENIA { get; set; }
    public virtual DbSet<UZYTKOWNICY> UZYTKOWNICY { get; set; }
    public virtual DbSet<DATA_STATUSU_ZLECENIA> DATA_STATUSU_ZLECENIA { get; set; }
    public virtual DbSet<AKTUALNY_STATUS_ZLECEN> AKTUALNY_STATUS_ZLECEN { get; set; }
    public virtual DbSet<AKTUALNY_STATUS_ZLECEN_NAZWY> AKTUALNY_STATUS_ZLECEN_NAZWY { get; set; }
    public virtual DbSet<ADRESY_PRACOWNIKA> ADRESY_PRACOWNIKA { get; set; }
    public virtual DbSet<PRACOWNICY_URLOP_STANOWISKO> PRACOWNICY_URLOP_STANOWISKO { get; set; }
    public virtual DbSet<PRACOWNIK_DANE> PRACOWNIK_DANE { get; set; }
    public virtual DbSet<LOKALIZACJA> LOKALIZACJA { get; set; }
    public virtual DbSet<SPIS_UZYTKOWNIKOW> SPIS_UZYTKOWNIKOW { get; set; }
    public virtual DbSet<ZMIANA_STANU_MAGAZYNU_MATERIALOW> ZMIANA_STANU_MAGAZYNU_MATERIALOW { get; set; }
    public virtual DbSet<ZMIANA_STANU_MAGAZYNU_PRODUKTOW> ZMIANA_STANU_MAGAZYNU_PRODUKTOW { get; set; }
    public virtual DbSet<STAN_MATERIALY_NAZWY> STAN_MATERIALY_NAZWY { get; set; }
    public virtual DbSet<STAN_PRODUKTY_NAZWY> STAN_PRODUKTY_NAZWY { get; set; }
    public virtual DbSet<KREATOR_FAKTUR> KREATOR_FAKTUR { get; set; }
    public virtual DbSet<PRZYGOTOWANIE_TRANSPORTU> PRZYGOTOWANIE_TRANSPORTU { get; set; }
    public virtual DbSet<ZLECENIA_LOKALIZACJA> ZLECENIA_LOKALIZACJA { get; set; }
    public virtual DbSet<ZLECENIE_PRODUKT> ZLECENIE_PRODUKT { get; set; }
    public virtual DbSet<ZLECENIA_MATERIALY> ZLECENIA_MATERIALY { get; set; }
    public virtual DbSet<HISTORIA_STATUS_ZLECENIA> HISTORIA_STATUS_ZLECENIA { get; set; }
    public virtual DbSet<ZLECENIA_PRODUKTY_NAZWY> ZLECENIA_PRODUKTY_NAZWY { get; set; }
    public virtual DbSet<SZKOLENIA_PRACOWNIKA> SZKOLENIA_PRACOWNIKA { get; set; }
    public virtual DbSet<PRACOWNICY_W_PRACY> PRACOWNICY_W_PRACY { get; set; }
    public virtual DbSet<CZAS_PRACY_MASZYN> CZAS_PRACY_MASZYN { get; set; }
    public virtual DbSet<CZAS_PRACY_NARZEDZI> CZAS_PRACY_NARZEDZI { get; set; }
    public virtual DbSet<MASZYNY> MASZYNY { get; set; }
    public virtual DbSet<NARZEDZIA> NARZEDZIA { get; set; }
    public virtual DbSet<ZESPOL_MASZYN> ZESPOL_MASZYN { get; set; }
    public virtual DbSet<ZESPOL_NARZEDZI> ZESPOL_NARZEDZI { get; set; }
    public virtual DbSet<URLOPY_PRACOWNIKA> URLOPY_PRACOWNIKA { get; set; }
    public virtual DbSet<KOSZTY_CZASY_PRODUKCJI> KOSZTY_CZASY_PRODUKCJI { get; set; }
    public virtual DbSet<OFERTA> OFERTA { get; set; }
    public virtual DbSet<PENSJE> PENSJE { get; set; }
    public virtual DbSet<ZAMOWIENIA> ZAMOWIENIA { get; set; }
    public virtual DbSet<Status_detale_zlecenie> Status_detale_zlecenie { get; set; }
    public virtual DbSet<SUMA_ZAPOTRZEBOWANIA_MATERIAL_ZLECENIE> SUMA_ZAPOTRZEBOWANIA_MATERIAL_ZLECENIE { get; set; }
    public virtual DbSet<ZAMOWIENIA_MATERIALU_NAZLECENIE> ZAMOWIENIA_MATERIALU_NAZLECENIE { get; set; }
    public virtual DbSet<zestawienie> zestawienie { get; set; }
}

}


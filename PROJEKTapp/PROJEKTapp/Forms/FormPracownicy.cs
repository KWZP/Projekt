﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKTapp
{
    public partial class FormPracownicy : Form
    {
        KWZP_PROJEKTEntities db;

        public FormPracownicy(KWZP_PROJEKTEntities db)
        {
            this.db = db;
            InitializeComponent();
            cbStanowisko.DataSource = db.STANOWISKO.ToList();
            cbStanowisko.DisplayMember = "Nazwa";
            cbStanowisko.ValueMember = "Id_Stanowisko";

            cbMiasto.DataSource = db.MIASTA.ToList();
            cbMiasto.DisplayMember = "Nazwa";
            cbMiasto.ValueMember = "Id_Miasta";
            btnUpdate.Hide();
        }

        public FormPracownicy(KWZP_PROJEKTEntities db, PRACOWNICY pracownik)
        {
            this.db = db;
            InitializeComponent();
            cbStanowisko.DataSource = db.STANOWISKO.ToList();
            cbStanowisko.DisplayMember = "Nazwa";
            cbStanowisko.ValueMember = "Id_Stanowisko";

            cbMiasto.DataSource = db.MIASTA.ToList();
            cbMiasto.DisplayMember = "Nazwa";
            cbMiasto.ValueMember = "Id_Miasta";

            btnDodaj.Hide();

            txtboxNazwisko.Text = pracownik.NAZWISKO;
            txtboxImie.Text = pracownik.IMIE;
            txtboxKodpocztowy.Text = "";
            txtboxTel.Text = pracownik.TELEFON;
            txtboxPesel.Text = pracownik.PESEL;
            txtboxUlica.Text = "";
            txtNrbudynku.Text = "";
            txtboxNrlokalu.Text = "" ;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (txtboxImie.Text == "" || txtboxNazwisko.Text == "" || txtboxTel.Text=="" || txtboxPesel.Text =="" || txtboxUlica.Text == "" || txtNrbudynku.Text == "" || txtboxNrlokalu.Text == "" || txtboxKodpocztowy.Text == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola");
            }
            else
            {
                PRACOWNICY pracownicyNew = new PRACOWNICY
                {
                    IMIE = txtboxImie.Text,
                    NAZWISKO = txtboxNazwisko.Text,
                    PESEL = txtboxPesel.Text,
                    TELEFON = txtboxTel.Text
                };
                ADRESY_PRACOWNICY adresypracownicy = new ADRESY_PRACOWNICY
                {
                    ULICA = txtboxUlica.Text,
                    NR_BUDYNKU = txtNrbudynku.Text,
                    NR_LOKALU = txtboxNrlokalu.Text,
                    KOD_POCZTOWY = txtboxKodpocztowy.Text,
                    ID_MIASTA = (int)cbMiasto.SelectedValue,
                    KRAJ = txtboxKraj.Text,
                };
                db.PRACOWNICY.Add(pracownicyNew);
                db.ADRESY_PRACOWNICY.Add(adresypracownicy);
                pracownicyNew.ADRESY_PRACOWNICY.Add(adresypracownicy);

                STANOWISKO_PRACOWNICY stanowiskopracownicy = new STANOWISKO_PRACOWNICY
                {
                    ID_PRACOWNIK = pracownicyNew.ID_PRACOWNIK,
                    ID_STANOWISKO = (int)cbStanowisko.SelectedValue,
                    DATA_START = txtDataRozpoczeciaPracy.Value
                };
                db.STANOWISKO_PRACOWNICY.Add(stanowiskopracownicy);
                db.SaveChanges();
            }
        }
        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            txtboxNazwisko.Clear();
            txtboxImie.Clear();
            txtboxKodpocztowy.Clear();
            txtboxTel.Clear();
            txtboxPesel.Clear();
            txtboxUlica.Clear();
            txtNrbudynku.Clear();
            txtboxNrlokalu.Clear();
        }
    }
}
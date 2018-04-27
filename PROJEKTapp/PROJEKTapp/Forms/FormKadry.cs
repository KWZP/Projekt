﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKTapp
{
    public partial class FormKadry : Form
    {
        KWZP_PROJEKTEntities db;//połaczenie z bazą danych
        bool TrybPrzyciskuZapisEdycja;
        bool ladowanieformularzazokienkami;
        PRACOWNICY pracownik;
        ADRESY_PRACOWNICY adrespracownik;
        STANOWISKO_PRACOWNICY pracownikstanowisko;
        STAWKA_PRACOWNICY pracownikstawka;

        public FormKadry(KWZP_PROJEKTEntities db, bool ladowanieformularzazokienkami)
        {
            this.db = db;
            this.ladowanieformularzazokienkami = ladowanieformularzazokienkami;
            InitializeComponent();

            cbStanowisko.DataSource = db.STANOWISKO.ToList();
            cbStanowisko.DisplayMember = "Nazwa";
           // cbStanowisko.ValueMember = "Id_Stanowisko";

            cbMiasto.DataSource = db.MIASTA.ToList();
            cbMiasto.DisplayMember = "Nazwa";
            //cbMiasto.ValueMember = "Id_Miasta";

            cbOkres.DataSource = db.OKRES.ToList();
            cbOkres.DisplayMember = "Nazwa";

            cbStawka.DataSource = db.STAWKA.Where(stawka => stawka.ID_OKRES.Equals(((OKRES)this.cbOkres.SelectedValue).ID_OKRES)).ToList();
            cbStawka.DisplayMember = "Wartosc";
        }


        private void FormKadry_Load(object sender, EventArgs e)
        {
            if (ladowanieformularzazokienkami == true)
            {
                pnlUserControl.Show();
                pnlUserSearch.Show();
                pnlUserField.Hide();
                ladowanieformularzazokienkami = false;
                this.ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
                ListaPracownikow.Columns[0].HeaderText = "NUMER";
                ListaPracownikow.Columns[0].Width = 60;
                ListaPracownikow.Columns[4].HeaderText = "STANOWISKO";
            }
            else
            {
                pnlUserControl.Hide();
                pnlUserSearch.Hide();
                pnlUserField.Hide();
                ladowanieformularzazokienkami = true;
            }
        }

        private void btnPracownicy_Click(object sender, EventArgs e)
        {
            if (ladowanieformularzazokienkami == true)
            {
                ladowanieformularzazokienkami = false;
                pnlUserControl.Show();
                pnlUserSearch.Show();
                pnlUserField.Hide();
                this.ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
                ListaPracownikow.Columns[0].HeaderText = "NUMER";
                ListaPracownikow.Columns[0].Width = 60;
                ListaPracownikow.Columns[4].HeaderText = "STANOWISKO";
            }
            else
            {
                ladowanieformularzazokienkami = true;
                pnlUserControl.Hide();
                pnlUserSearch.Hide();
                pnlUserField.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e) =>
            this.Close();

        private void btnUrlopy_Click(object sender, EventArgs e)
        {
            ladowanieformularzazokienkami = true;
            FormUrlopy urlopy = new FormUrlopy(db, ladowanieformularzazokienkami);
            urlopy.Show();
            this.Close();
        }


        private void txtWyszukajNazwisko_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtWyszukajNazwisko.Text))
            {
                this.ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
            }
            else
            {
                this.ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.Where(x => x.NAZWISKO.StartsWith(txtWyszukajNazwisko.Text)).ToList();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            
            {
                chbEdycjaStanoiwska.Hide();
                pnlUserField.Show();
                czyscform();
                TrybPrzyciskuZapisEdycja = true;
                txtboxKraj.Text = "Polska";
                cbOkres.Enabled = true;
                cbStawka.Enabled = true;
            }
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            pnlUserField.Show();
            TrybPrzyciskuZapisEdycja = false;
            chbEdycjaStanoiwska.Show();
            cbOkres.Enabled = false;
            cbStawka.Enabled = false;

            int ID = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);
            pracownik = db.PRACOWNICY.Where(x => x.ID_PRACOWNIK == ID).First();
            txtboxNazwisko.Text = pracownik.NAZWISKO;
            txtboxImie.Text = pracownik.IMIE;
            txtboxTel.Text = pracownik.TELEFON;
            txtboxPesel.Text = pracownik.PESEL;
            adrespracownik = pracownik.ADRESY_PRACOWNICY.First();
            txtboxUlica.Text = adrespracownik.ULICA;
            txtboxNrlokalu.Text = adrespracownik.NR_LOKALU;
            txtboxNrbudynku.Text = adrespracownik.NR_BUDYNKU;
            txtboxKodpocztowy.Text = adrespracownik.KOD_POCZTOWY;
            (((MIASTA)this.cbMiasto.SelectedValue).ID_MIASTA) = (int)adrespracownik.ID_MIASTA;
            txtboxKraj.Text = adrespracownik.KRAJ;
            pracownikstawka = pracownik.STAWKA_PRACOWNICY.Last();
            ((STAWKA)this.cbStawka.SelectedValue).ID_STAWKA = (int)pracownikstawka.ID_STAWKA;
            cbOkres.SelectedIndex = (int)pracownikstawka.STAWKA.ID_OKRES;
            pracownikstanowisko = pracownik.STANOWISKO_PRACOWNICY.Last();
            ((STANOWISKO)cbStanowisko.SelectedValue).ID_STANOWISKO = (int)pracownikstanowisko.ID_STANOWISKO;
            txtDataRozpoczeciaPracy.Value = pracownikstanowisko.DATA_START;
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy chcesz usunąć dane pracownika: " + ListaPracownikow.CurrentRow.Cells[1].Value + " " + ListaPracownikow.CurrentRow.Cells[2].Value, "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int ID = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);
                PRACOWNICY pracownik = db.PRACOWNICY.Where(x => x.ID_PRACOWNIK == ID).First();
                STANOWISKO_PRACOWNICY stanowisko = db.STANOWISKO_PRACOWNICY.Where(s => s.ID_PRACOWNIK.Equals(ID)).First(); //sprawdzić usówanie wszystkiech rekordów - czym zastąpić .First()
                try
                {
                    db.STANOWISKO_PRACOWNICY.Remove(stanowisko);
                    db.PRACOWNICY.Remove(pracownik);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Usunięcie pracownika nie powiodło się");
                }
                ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
                ListaPracownikow.Refresh();
                pnlUserField.Hide();
            } 
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            pnlUserField.Hide();
            czyscform();
        }

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            czyscform();
        }
        private void czyscform()
        {
            foreach (Control control in this.pnlUserField.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    if (textBox.Name.Contains("txtbox"))
                    {
                        (control as TextBox).Clear();
                    }
                }
            }
        }

        private void btnZapiszDodaj_Click(object sender, EventArgs e)
        {
                if (txtboxImie.Text == "" || txtboxNazwisko.Text == "" || txtboxTel.Text == "" || txtboxPesel.Text == "" || txtboxUlica.Text == "" || txtboxNrbudynku.Text == "" || txtboxNrlokalu.Text == "" || txtboxKodpocztowy.Text == "")
                {
                    MessageBox.Show("Wypełnij wszystkie pola");
                }
                else if (TrybPrzyciskuZapisEdycja == true) //Tworzenie nowego pracownika
                {
                    PRACOWNICY pracownik = new PRACOWNICY();
                    pracownik.NAZWISKO = this.txtboxNazwisko.Text;
                    pracownik.IMIE = this.txtboxImie.Text;
                    pracownik.TELEFON = this.txtboxTel.Text;
                    pracownik.PESEL = this.txtboxPesel.Text;
                    ADRESY_PRACOWNICY adrespracownika = new ADRESY_PRACOWNICY();
                    adrespracownika.ULICA = this.txtboxUlica.Text;
                    adrespracownika.NR_BUDYNKU = this.txtboxNrbudynku.Text;
                    adrespracownika.NR_LOKALU = this.txtboxNrlokalu.Text;
                    adrespracownika.KOD_POCZTOWY = this.txtboxKodpocztowy.Text;
                    adrespracownika.ID_MIASTA = ((MIASTA)this.cbMiasto.SelectedValue).ID_MIASTA;
                    adrespracownika.KRAJ = this.txtboxKraj.Text;
                    STANOWISKO_PRACOWNICY pracownikstanowisko = new STANOWISKO_PRACOWNICY();
                pracownikstanowisko.ID_STANOWISKO = ((STANOWISKO)cbStanowisko.SelectedValue).ID_STANOWISKO;
                    pracownikstanowisko.DATA_START = txtDataRozpoczeciaPracy.Value;
                if (chbDataKoniec.Checked == true)
                {
                    pracownikstanowisko.DATA_KONIEC = txtDataKoniec.Value;
                }
                    STAWKA_PRACOWNICY stawkapracownika = new STAWKA_PRACOWNICY();
                stawkapracownika.ID_STAWKA = ((STAWKA)this.cbStawka.SelectedValue).ID_STAWKA;
                    stawkapracownika.DATA_START = txtDataRozpoczeciaPracy.Value;
                if (chbDataKoniec.Checked == true)
                {
                    stawkapracownika.DATA_KONIEC = txtDataKoniec.Value;
                }
                pracownik.STAWKA_PRACOWNICY.Add(stawkapracownika);
                    pracownik.STANOWISKO_PRACOWNICY.Add(pracownikstanowisko);
                    pracownik.ADRESY_PRACOWNICY.Add(adrespracownika);
                    db.PRACOWNICY.Add(pracownik);
                    db.SaveChanges();
                    ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
                ListaPracownikow.Refresh();
                }
            else
            {//Edycja istniejącego pracownika
                int ID = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);
                pracownik = db.PRACOWNICY.Where(x => x.ID_PRACOWNIK == ID).First();
                pracownik.NAZWISKO = this.txtboxNazwisko.Text;
                pracownik.IMIE = this.txtboxImie.Text;
                pracownik.TELEFON = this.txtboxTel.Text;
                pracownik.PESEL = this.txtboxPesel.Text;
                adrespracownik = pracownik.ADRESY_PRACOWNICY.First();
                adrespracownik.ULICA = this.txtboxUlica.Text;
                adrespracownik.NR_BUDYNKU = this.txtboxNrbudynku.Text;
                adrespracownik.NR_LOKALU = this.txtboxNrlokalu.Text;
                adrespracownik.KOD_POCZTOWY = this.txtboxKodpocztowy.Text;
                adrespracownik.ID_MIASTA = (int)cbMiasto.SelectedValue;
                adrespracownik.KRAJ = this.txtboxKraj.Text;
                if (chbEdycjaStanoiwska.Checked == true)
                {
                    pracownikstanowisko.DATA_KONIEC = txtDataRozpoczeciaPracy.Value;
                    STANOWISKO_PRACOWNICY pracownikstanowiskoN = new STANOWISKO_PRACOWNICY();
                    pracownikstanowiskoN.ID_STANOWISKO = (int)cbStanowisko.SelectedValue;
                    pracownikstanowiskoN.DATA_START = txtDataRozpoczeciaPracy.Value;
                    if (chbDataKoniec.Checked == true)
                    {
                        pracownikstanowisko.DATA_KONIEC = txtDataKoniec.Value;
                    }
                    pracownik.STANOWISKO_PRACOWNICY.Add(pracownikstanowiskoN);
                }
                if (chbZmianaStawki.Checked ==true)
                {
                    STAWKA_PRACOWNICY stawkapracownika = new STAWKA_PRACOWNICY();
                    stawkapracownika.ID_STAWKA = (int)cbStawka.SelectedValue;
                    pracownik.STAWKA_PRACOWNICY.Add(stawkapracownika);
                }
                db.SaveChanges();
                ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
                ListaPracownikow.Refresh();
                czyscform();
            }
           
        }

        private void btnSzkolenia_Click(object sender, EventArgs e)
        {
            ladowanieformularzazokienkami = true;
            FormSzkolenie szkolenie = new FormSzkolenie(db, ladowanieformularzazokienkami);
            szkolenie.Show();
            this.Close();
        }

        private void btnWynagrodzenia_Click(object sender, EventArgs e)
        {
            ladowanieformularzazokienkami = true;
            FormWynagordzenie wynagrodzenie = new FormWynagordzenie(db, ladowanieformularzazokienkami);
            wynagrodzenie.Show();
            this.Close();
        }

        private void btnStatystyki_Click(object sender, EventArgs e)
        {
            ladowanieformularzazokienkami = true;
            FormStatystyki statystyki = new FormStatystyki(db, ladowanieformularzazokienkami);
            statystyki.Show();
            this.Close();
        }

        private void chbDataKoniec_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDataKoniec.Checked == true)
                txtDataKoniec.Show();
            else
                txtDataKoniec.Hide();
        }

        private void cbOkres_SelectedValueChanged(object sender, EventArgs e)
        {
            cbStawka.DataSource = db.STAWKA.Where(stawka => stawka.ID_OKRES.Equals(((OKRES)this.cbOkres.SelectedValue).ID_OKRES)).ToList();
            cbStawka.DisplayMember = "Wartosc";
        }

        private void chbZmianaStawki_CheckedChanged(object sender, EventArgs e)
        {
            if (chbZmianaStawki.Checked ==true)
            {
                cbOkres.Enabled = true;
                cbStawka.Enabled = true;
            }
            else
                {
                cbOkres.Enabled = false;
                cbStawka.Enabled = false;
            }
        }
    }
}

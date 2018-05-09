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
    public partial class FormUrlopy : Form
    {
        KWZP_PROJEKTEntities db;
        bool ladowanieformularzazokienkami;
        PRACOWNICY pracownik;


        public FormUrlopy(KWZP_PROJEKTEntities db, bool ladowanieformularzazokienkami)
        {
            this.ladowanieformularzazokienkami = ladowanieformularzazokienkami;
            this.db = db;
            InitializeComponent();

            cbTypUrlopu.DataSource = db.WOLNE.ToList();
            cbTypUrlopu.DisplayMember = "NAZWA";
            cbTypUrlopu.ValueMember = "ID_WOLNE";
        }

        private void FormUrlopy_Load(object sender, EventArgs e)
        {
            if (ladowanieformularzazokienkami == true)
            {
                pnlUrlopyControl.Show();
                pnlUserSearch.Show();
                pnlWolne.Hide();
                ladowanieformularzazokienkami = false;
                this.ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
                ListaPracownikow.Columns[0].HeaderText = "NUMER";
                ListaPracownikow.Columns[0].Width = 60;
                ListaPracownikow.Columns[4].HeaderText = "STANOWISKO";
                int ID = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);
                this.dgvUrlopyPraconik.DataSource = db.URLOPY_PRACOWNIKA.Where(urlop => urlop.ID_PRACOWNIK.Equals(ID)).ToList();
                dgvUrlopyPraconik.Columns[0].Visible = false;
            }
            else
            {
                pnlUrlopyControl.Hide();
                pnlUserSearch.Hide();
                pnlWolne.Hide();
                ladowanieformularzazokienkami = true;
            }
            
            KalendarzUrlop.SelectionStart = DateTime.Now;
            KalendarzUrlop.SelectionEnd = DateTime.Now.AddDays(3);
                }

        private void btnUrlopy_Click(object sender, EventArgs e)
        {

            if (ladowanieformularzazokienkami == true)
            {
                pnlUrlopyControl.Show();
                pnlUserSearch.Show();
                pnlWolne.Hide();
                ladowanieformularzazokienkami = false;
                this.ListaPracownikow.DataSource = db.PRACOWNICY_ZATRUDNIENI.ToList();
                ListaPracownikow.Columns[0].HeaderText = "NUMER";
                ListaPracownikow.Columns[0].Width = 60;
                ListaPracownikow.Columns[4].HeaderText = "STANOWISKO";
            }
            else
            {
                pnlUrlopyControl.Hide();
                pnlUserSearch.Hide();
                pnlWolne.Hide();
                ladowanieformularzazokienkami = true;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPracownicy_Click(object sender, EventArgs e)
        {
            ladowanieformularzazokienkami = true;
            FormKadry kadry = new FormKadry(db, ladowanieformularzazokienkami);
            kadry.Show();
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

        private void czyscform()
        {
            foreach (Control control in this.pnlWolne.Controls)
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

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            pnlWolne.Show();
            czyscform();
            
            KalendarzUrlop.BoldedDates = new DateTime[] { };
            int ID = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);
            this.pracownik = db.PRACOWNICY.Where(pracownik => pracownik.ID_PRACOWNIK == ID).First();
            foreach (SZKOLENIA szkolenie in pracownik.SZKOLENIA)
            {
                int dlugoscSzkolenia = szkolenie.DATA_KONIEC.Subtract(szkolenie.DATA_START).Days + 1;
                DateTime aktualnaData = szkolenie.DATA_START;
                for (int i = 0; i < dlugoscSzkolenia; i++)
                {
                    KalendarzUrlop.BoldedDates = KalendarzUrlop.BoldedDates.Concat(new DateTime[] { aktualnaData.AddDays(i) }).ToArray();

                }
            }
            foreach (WOLNE_PRACOWNICY wolne in pracownik.WOLNE_PRACOWNICY)
            {
                int dlugoscwolne = wolne.DATA_KONIEC.Subtract(wolne.DATA_START).Days + 1;
                DateTime aktualnaData = wolne.DATA_START;
                for (int i = 0; i < dlugoscwolne; i++)
                {
                    KalendarzUrlop.BoldedDates = KalendarzUrlop.BoldedDates.Concat(new DateTime[] { aktualnaData.AddDays(i) }).ToArray();

                }
            }

        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            pnlWolne.Show();
            czyscform();

            int ID = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);

        }

        private void btnUsun_Click(object sender, EventArgs e)
        {

        }

        private void btnZapiszDodaj_Click(object sender, EventArgs e)
        {     
                WOLNE_PRACOWNICY wolnepracownik = new WOLNE_PRACOWNICY();
                wolnepracownik.DATA_KONIEC = txtDataKoniec.Value;
                wolnepracownik.DATA_START = txtDataStart.Value;
                wolnepracownik.ID_WOLNE = (int)cbTypUrlopu.SelectedValue;
                wolnepracownik.ID_PRACOWNIK = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);
                db.SaveChanges();
                ListaPracownikow.Refresh();
                pnlUrlopyControl.Hide();
        }

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            czyscform();
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            pnlWolne.Hide();
            czyscform();
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

        private void ListaPracownikow_MouseClick(object sender, MouseEventArgs e)
        {
            int ID = Convert.ToInt32(ListaPracownikow.CurrentRow.Cells[0].Value);
            this.dgvUrlopyPraconik.DataSource = db.URLOPY_PRACOWNIKA.Where(urlop => urlop.ID_PRACOWNIK.Equals(ID)).ToList();
            dgvUrlopyPraconik.Columns[0].Visible = false;
        }
    }
}

﻿using PROJEKTapp.Forms;
using PROJEKTapp.Forms_NoweZlecenie;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PROJEKTapp
{
    public partial class FormNoweZlecenie : Form
    {
        KWZP_PROJEKTEntities db;
        List<ZLECENIA_PRODUKTY_NAZWY> lZP = new List<ZLECENIA_PRODUKTY_NAZWY>();
        List<ZLECENIA_PRODUKTY_NAZWY> sZP = new List<ZLECENIA_PRODUKTY_NAZWY>();
        ZLECENIA zlecenie;
        
        bool ofertowano = false;
        public static int id_firmy;
        public FormNoweZlecenie(ZLECENIA zlecenie, KWZP_PROJEKTEntities db)
        {

            this.db = db;
            this.zlecenie = zlecenie;
            InitializeComponent();

            
            cbBoxFirmy.DisplayMember = "NAZWA_FIRMY";
            cbBoxFirmy.ValueMember = "ID_FIRMY";
            cbBoxFirmy.DropDownStyle = ComboBoxStyle.DropDownList;
            
            
            cBox_Produkty_Oferta.DataSource = db.PRODUKT.ToList();
            cBox_Produkty_Oferta.DisplayMember = "NAZWA_PRODUKTU";
            cBox_Produkty_Oferta.ValueMember = "Id_Produktu";
            cBox_Produkty_Oferta.DropDownStyle = ComboBoxStyle.DropDownList;

            txtBox_Data_Zlecenia.Text = DateTime.Now.ToString("dd/MM/yyyy");
          
        }
        
    
        private void btn_Dodaj_Zlecenie_Click(object sender, EventArgs e)
        {
          
            ZLECENIA zlecenie = new ZLECENIA();
            zlecenie.DATA_REALIZACJI = DateTime.Parse(txtBox_Data_Realizacji.Text);
            zlecenie.DATA_ZLECENIA = DateTime.Parse(txtBox_Data_Zlecenia.Text);
            zlecenie.ID_FIRMY = int.Parse(cbBoxFirmy.SelectedValue.ToString());
            int  id = db.ZLECENIA.Max(a => a.ID_ZLECENIA);
            zlecenie.ID_ZLECENIA = id;
            db.Entry(zlecenie).State = EntityState.Modified; 
            db.SaveChanges();
            DATA_STATUSU_ZLECENIA dATA_STATUSU_ZLECENIA = new DATA_STATUSU_ZLECENIA();
            dATA_STATUSU_ZLECENIA.ID_ZLECENIA = id;
            dATA_STATUSU_ZLECENIA.ID_STATUSU_ZLECENIA = 1;

            db.DATA_STATUSU_ZLECENIA.Add(dATA_STATUSU_ZLECENIA);
            db.SaveChanges();

            MessageBox.Show("Akcje zapisano pomyślne .", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }



        private void btn_Dodaj_Oferta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBox_Ilosc_Oferta.Text))
            {
                MessageBox.Show(" Należy wypelnić polę Ilość w celu dodania produktu do listy. ");
            }
            else
            {
                var powtorki = lZP.Where(a => a.ID_PRODUKTU == int.Parse(cBox_Produkty_Oferta.SelectedValue.ToString()));
                if (powtorki.Count() == 0)
                  {
                   

                    ZLECENIA_PRODUKTY_NAZWY zLECENIA_PRODUKTY_NAZWY = new ZLECENIA_PRODUKTY_NAZWY();

                    zLECENIA_PRODUKTY_NAZWY.ID_PRODUKTU = int.Parse(cBox_Produkty_Oferta.SelectedValue.ToString());
                    zLECENIA_PRODUKTY_NAZWY.ILOSC = int.Parse(txtBox_Ilosc_Oferta.Text);
                    zLECENIA_PRODUKTY_NAZWY.NAZWA_PRODUKTU = cBox_Produkty_Oferta.Text;
                    zLECENIA_PRODUKTY_NAZWY.ID_ZLECENIA = db.ZLECENIA.Max(a => a.ID_ZLECENIA);

                    lZP.Add(zLECENIA_PRODUKTY_NAZWY);

                    zLECENIAPRODUKTYNAZWYBindingSource.DataSource = lZP;
                    zLECENIAPRODUKTYNAZWYBindingSource.DataSource = null;
                    zLECENIAPRODUKTYNAZWYBindingSource.DataSource = lZP;


                 
                }
                else
                {
                    MessageBox.Show("Lista zawiera już ten produkt, można zmienić jego ilość na liście. ");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            czyscOferteProdukt();

            ZLECENIA zLECENIA = db.ZLECENIA.First(a => a.ID_ZLECENIA == zlecenie.ID_ZLECENIA);

            db.ZLECENIA.Remove(zLECENIA);
            db.SaveChanges();
            KWZP_PROJEKTEntities nDB = new KWZP_PROJEKTEntities();
            db = nDB;
            this.Close();
        }

        private void ofertuj()
        {
            
            KWZP_PROJEKTEntities nDB = new KWZP_PROJEKTEntities();
            db.KOSZTY_CZASY_PRODUKCJI = nDB.KOSZTY_CZASY_PRODUKCJI;
            db.OFERTA = nDB.OFERTA;
            db = nDB;
            int c = db.ZLECENIA.Max(a => a.ID_ZLECENIA);
            oFERTABindingSource1.DataSource = db.OFERTA.Where(a => a.ID_ZLECENIA == c).ToList();
            OFERTA oFERTA = oFERTABindingSource1.Current as OFERTA;
            decimal dcena = decimal.Parse(oFERTA.KOSZT_CALKOWITY_PRODUKCJI.ToString());
            int cena = Decimal.ToInt32(dcena);
            txtBoxCena.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", cena);
            DateTime date = db.ZLECENIA.Max(a => a.DATA_REALIZACJI);
            DateTime czasrealizacji1 = date.AddDays(double.Parse(oFERTA.CZAS_PRODUKCJI.ToString()));
            DateTime czasrealizacji2 = czasrealizacji1.AddDays(6);
            txtBox_Data_Realizacji.Text = czasrealizacji2.ToLongDateString();
            
        }

        private void btnPrzedstaw_Oferte_Click(object sender, EventArgs e)
        {
            czyscOferteProdukt();

            ofertowano = true;
           
            db.SaveChanges();
            sZP.Clear();

            foreach (ZLECENIA_PRODUKTY_NAZWY element in lZP)
            {
                ZLECENIE_PRODUKT zLECENIE_PRODUKT = new ZLECENIE_PRODUKT();
                zLECENIE_PRODUKT.ID_ZLECENIA = element.ID_ZLECENIA;
                zLECENIE_PRODUKT.ID_PRODUKTU = element.ID_PRODUKTU;
                zLECENIE_PRODUKT.ILOSC = element.ILOSC;
                db.ZLECENIE_PRODUKT.Add(zLECENIE_PRODUKT);
                sZP.Add(element);
                db.SaveChanges();
            }

            ofertuj();

        }

        

            private void btnWybierzFirme_Click(object sender, EventArgs e)
        {
            using (FormFirmyDoZlecenia formFirmyDoZlecenia = new FormFirmyDoZlecenia(db))
            {
                formFirmyDoZlecenia.ShowDialog();
               
                if (! cbBoxFirmy.DataSource.Equals(db.FIRMY.ToList()))
                {
                    cbBoxFirmy.DataSource = db.FIRMY.ToList();
                }
                cbBoxFirmy.SelectedValue = id_firmy;
                
            }
        }

        private void FormNoweZlecenie_Load(object sender, EventArgs e)
        {
            dGVOFERTA.Visible = false;
            KWZP_PROJEKTEntities ndb = new KWZP_PROJEKTEntities();
            db.ZLECENIA = ndb.ZLECENIA;
            db = ndb;
            db.SaveChanges();
            cbBoxFirmy.DataSource = db.FIRMY.ToList();
            zlecenie.DATA_REALIZACJI = DateTime.Parse(txtBox_Data_Zlecenia.Text);
            zlecenie.DATA_ZLECENIA = DateTime.Parse(txtBox_Data_Zlecenia.Text);
            zlecenie.ID_FIRMY = 1;
            db.ZLECENIA.Add(zlecenie);
            db.SaveChanges();
        }

   

        private void txtBox_Ilosc_Oferta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBox_Ilosc_Oferta.Text))
            {
                int parsedVal;
                if (!int.TryParse(txtBox_Ilosc_Oferta.Text, out parsedVal))
                {
                    MessageBox.Show("To pole może zawierać tylko liczbę. ");
                    txtBox_Ilosc_Oferta.Clear();
                    return;
                }
            }

        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            dataGridViewOferta.CurrentCell.Value = 1;
            MessageBox.Show("To pole może zawierać tylko liczbę. ");
        }

        private void dataGridViewOferta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int parsedVal;
            if (!int.TryParse(dataGridViewOferta.CurrentCell.Value.ToString(), out parsedVal))
            {
                MessageBox.Show("To pole może zawierać tylko liczbę. ");
                dataGridViewOferta.CurrentCell.Value = 1;
                return;
            }
            if (parsedVal <= 0)
            {
                MessageBox.Show("Ilosc produktu musi byc dodatnia. ");
                dataGridViewOferta.CurrentCell.Value = 1;
                return;
            }
            
        }

        private void czyscOferteProdukt ()
        {
            if (ofertowano)
            {

                foreach (ZLECENIA_PRODUKTY_NAZWY element in sZP)
                {
                    ZLECENIE_PRODUKT zLECENIE_PRODUKT = new ZLECENIE_PRODUKT();
                    zLECENIE_PRODUKT.ID_ZLECENIA = element.ID_ZLECENIA;
                    zLECENIE_PRODUKT.ID_PRODUKTU = element.ID_PRODUKTU;
                    zLECENIE_PRODUKT.ILOSC = element.ILOSC;
                    db.ZLECENIE_PRODUKT.Attach(zLECENIE_PRODUKT);
                    db.ZLECENIE_PRODUKT.Remove(zLECENIE_PRODUKT);
                    db.SaveChanges();
                }
            }
        }

        private void btnOdrzuc_click(object sender, EventArgs e)
        {
            czyscOferteProdukt();

            ZLECENIA zLECENIA = db.ZLECENIA.First(a => a.ID_ZLECENIA == zlecenie.ID_ZLECENIA);
         
            db.ZLECENIA.Remove(zLECENIA);
            db.SaveChanges();
            KWZP_PROJEKTEntities nDB = new KWZP_PROJEKTEntities();
            db = nDB;
            this.Close();
        }
    }
}

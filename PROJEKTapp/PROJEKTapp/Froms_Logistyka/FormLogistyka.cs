﻿using PROJEKTapp.Forms;
using PROJEKTapp.Forms.Forms_Logistyka;
using System;
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
    public partial class FormLogistyka : Form

    {
        KWZP_PROJEKTEntities db;
        public FormLogistyka(KWZP_PROJEKTEntities db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void FormLogistyka_Load(object sender, EventArgs e)
        {

        }

       
        private void Btn_zmiana_stat_Click(object sender, EventArgs e)
        {
          //  FormZmianaStanuMagazynu ZmianaStanuMagazynu = new FormZmianaStanuMagazynu(db);
          //  ZmianaStanuMagazynu.Show();
        }

        private void Btn_kreat_fak_Click(object sender, EventArgs e)
        {
            FormListaFaktur KreatorFaktur = new FormListaFaktur(db);
            KreatorFaktur.Show();
            
        }

        private void Btn_przyg_trans_Click(object sender, EventArgs e)
        {
           
        }

        private void Btn_zam_mat_Click(object sender, EventArgs e)
        {
            ZamowienieMaterialu ZamowienieMaterialu = new ZamowienieMaterialu(db);
            ZamowienieMaterialu.Show();
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

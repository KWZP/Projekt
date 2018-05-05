﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKTapp.Forms
{
    public partial class FormZmianaStanuMagazynu : Form
    {
        KWZP_PROJEKTEntities db;
        public FormZmianaStanuMagazynu(KWZP_PROJEKTEntities db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonZmianaStanu_Click(object sender, EventArgs e)
        {

        }

        private void checkBSurowce_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBSurowce.Checked )
            {
                checkBMaterialy.Checked = false;
                DGV_PRODUKTY.Show();
                DGV_MATERIALY.Hide();
            }
        }

        private void checkBMaterialy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBMaterialy.Checked)
            {
                checkBSurowce.Checked = false;
                DGV_MATERIALY.Show();
                DGV_PRODUKTY.Hide();
            }
        }

        private void FormZmianaStanuMagazynu_Load(object sender, EventArgs e)
        {
            sTANMATERIALYNAZWYBindingSource.DataSource = db.STAN_MATERIALY_NAZWY.ToList();
            sTANPRODUKTYNAZWYBindingSource.DataSource = db.STAN_PRODUKTY_NAZWY.ToList();
            checkBMaterialy.Checked = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BateEkranDeneme.Forms
{
    public partial class FormSiparisDuzenleme : Form
    {
        public FormSiparisDuzenleme()
        {
            InitializeComponent();
        }

        private void FormSiparisDuzenleme_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dinamikMikroPlusDataSet2.Dinamik_Depo' table. You can move, or remove it, as needed.
            this.dinamik_DepoTableAdapter.Fill(this.dinamikMikroPlusDataSet2.Dinamik_Depo);
            // TODO: This line of code loads data into the 'dinamikMikroPlusDataSet1.Dinamik_Coklu_Stok_Sec' table. You can move, or remove it, as needed.
            this.dinamik_Coklu_Stok_SecTableAdapter.Fill(this.dinamikMikroPlusDataSet1.Dinamik_Coklu_Stok_Sec);
            // TODO: This line of code loads data into the 'dinamikMikroPlusDataSet.Dinamik_Firma_Tanimi' table. You can move, or remove it, as needed.
            this.dinamik_Firma_TanimiTableAdapter.Fill(this.dinamikMikroPlusDataSet.Dinamik_Firma_Tanimi);

        }

      
      
    }
}

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
    public partial class FormAnaEkran : Form
    {
        string alinanUserName;
        public FormAnaEkran(string userName)
        {
            userName = this.alinanUserName;
            InitializeComponent();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAlislardanFiyatFarki tiklaForm = new FormAlislardanFiyatFarki();
            tiklaForm.Show();

        }

        private void btnStokKartDuzenle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormInsert insert = new FormInsert();
            insert.Show();

        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormStokKartDuzenle stok = new FormStokKartDuzenle();
            stok.Show();
        }

        private void FormAnaEkran_Load(object sender, EventArgs e)
        {
            Console.Write("Merhaba");
        }

        private void barButtonItem21_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormStokYonetimi click = new FormStokYonetimi();
            click.Show();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormStokKartlariBirlestirme click = new FormStokKartlariBirlestirme();
            click.Show();
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormFiyatiDegisenStoklar click = new FormFiyatiDegisenStoklar();
            click.Show();
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormStokKartKontrol click = new FormStokKartKontrol();
            click.Show();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormGenelStokKarlılık click = new FormGenelStokKarlılık();
            click.Show();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPazarPayiRaporu click = new FormPazarPayiRaporu();
            click.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormStokDepoDetaylari click = new FormStokDepoDetaylari();
            click.Show();

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAlisFaturalardanSatisFiyatiOlustur click = new FormAlisFaturalardanSatisFiyatiOlustur();
            click.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormSiparisHazirlama click = new FormSiparisHazirlama();
            click.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormSiparisIzleme click = new FormSiparisIzleme();
            click.Show();
        }

       
    }
}

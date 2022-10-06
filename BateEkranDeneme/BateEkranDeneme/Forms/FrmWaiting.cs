namespace DinamikMikroSync
{
    public partial class FrmWaiting : DevExpress.XtraEditors.XtraForm
    {
        public FrmWaiting(string caption, string description)
        {
            InitializeComponent();
            ppWaiting.Caption = caption;
            ppWaiting.Description = description;
        }
    }
}
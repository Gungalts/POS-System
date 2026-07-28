using POS.WinForms.Data;

namespace POS.WinForms.Forms.Products;

public partial class SupplierForm : IReadOnlyForm
{
    public void SetReadOnly()
    {
        btnSave.Enabled = false;
        btnDelete.Enabled = false;
        Text += " (Lihat Saja)";
    }
}

using Microsoft.Extensions.DependencyInjection;
using POS.WinForms.Forms.Products;

namespace POS.WinForms.Forms;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public MainForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void btnCategory_Click(object sender, EventArgs e)
    {
        var form = _serviceProvider.GetRequiredService<CategoryForm>();
        form.ShowDialog();
    }

    private void btnSupplier_Click(object sender, EventArgs e)
    {
        var form = _serviceProvider.GetRequiredService<SupplierForm>();
        form.ShowDialog();
    }

    private void btnCustomer_Click(object sender, EventArgs e)
    {
        var form = _serviceProvider.GetRequiredService<CustomerForm>();
        form.ShowDialog();
    }
}
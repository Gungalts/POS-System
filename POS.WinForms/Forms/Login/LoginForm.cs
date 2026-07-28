using POS.Application.Interfaces;
using POS.Domain.Exceptions;
using POS.WinForms.Data;

namespace POS.WinForms.Forms.Login;

public partial class LoginForm : Form
{
    private readonly IUserService _userService;
    private readonly UserSession _session;

    public LoginForm(IUserService userService, UserSession session)
    {
        _userService = userService;
        _session = session;
        InitializeComponent();
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        btnLogin.Enabled = false;
        try
        {
            var user = await _userService.LoginAsync(txtUsername.Text, txtPassword.Text);
            _session.CurrentUser = user;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Clear();
            txtPassword.Focus();
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }
}

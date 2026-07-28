namespace POS.WinForms.Forms.Login;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblUsername = new System.Windows.Forms.Label();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.lblPassword = new System.Windows.Forms.Label();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.btnLogin = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // lblTitle
        //
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblTitle.Location = new System.Drawing.Point(30, 25);
        this.lblTitle.Text = "POS - Masuk";
        //
        // lblUsername
        //
        this.lblUsername.AutoSize = true;
        this.lblUsername.Location = new System.Drawing.Point(30, 75);
        this.lblUsername.Text = "Username";
        this.txtUsername.Location = new System.Drawing.Point(120, 72);
        this.txtUsername.Size = new System.Drawing.Size(200, 23);
        this.txtUsername.TabIndex = 0;
        //
        // lblPassword
        //
        this.lblPassword.AutoSize = true;
        this.lblPassword.Location = new System.Drawing.Point(30, 110);
        this.lblPassword.Text = "Password";
        this.txtPassword.Location = new System.Drawing.Point(120, 107);
        this.txtPassword.Size = new System.Drawing.Size(200, 23);
        this.txtPassword.UseSystemPasswordChar = true;
        this.txtPassword.TabIndex = 1;
        //
        // btnLogin
        //
        this.btnLogin.Location = new System.Drawing.Point(120, 150);
        this.btnLogin.Size = new System.Drawing.Size(200, 38);
        this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnLogin.Text = "MASUK";
        this.btnLogin.TabIndex = 2;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        //
        // LoginForm
        //
        this.AcceptButton = this.btnLogin;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(360, 220);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblUsername);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblPassword);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.btnLogin);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "LoginForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Login";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnLogin;
}

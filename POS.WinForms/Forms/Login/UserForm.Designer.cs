namespace POS.WinForms.Forms.Login;

partial class UserForm
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
        this.dgvUser = new System.Windows.Forms.DataGridView();
        this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlForm = new System.Windows.Forms.Panel();
        this.lblUsername = new System.Windows.Forms.Label();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.lblFullName = new System.Windows.Forms.Label();
        this.txtFullName = new System.Windows.Forms.TextBox();
        this.lblRole = new System.Windows.Forms.Label();
        this.cmbRole = new System.Windows.Forms.ComboBox();
        this.lblPassword = new System.Windows.Forms.Label();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnResetPassword = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
        this.pnlForm.SuspendLayout();
        this.SuspendLayout();
        //
        // dgvUser
        //
        this.dgvUser.AllowUserToAddRows = false;
        this.dgvUser.AllowUserToDeleteRows = false;
        this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsername, this.colFullName, this.colRole });
        this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvUser.MultiSelect = false;
        this.dgvUser.Name = "dgvUser";
        this.dgvUser.ReadOnly = true;
        this.dgvUser.RowHeadersVisible = false;
        this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvUser.TabIndex = 0;
        this.dgvUser.SelectionChanged += new System.EventHandler(this.dgvUser_SelectionChanged);

        this.colUsername.DataPropertyName = "Username";
        this.colUsername.HeaderText = "Username";
        this.colUsername.Name = "colUsername";
        this.colUsername.Width = 150;
        this.colFullName.DataPropertyName = "FullName";
        this.colFullName.HeaderText = "Nama Lengkap";
        this.colFullName.Name = "colFullName";
        this.colFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colRole.DataPropertyName = "Role";
        this.colRole.HeaderText = "Role";
        this.colRole.Name = "colRole";
        this.colRole.Width = 120;
        //
        // pnlForm
        //
        this.pnlForm.Controls.Add(this.lblUsername);
        this.pnlForm.Controls.Add(this.txtUsername);
        this.pnlForm.Controls.Add(this.lblFullName);
        this.pnlForm.Controls.Add(this.txtFullName);
        this.pnlForm.Controls.Add(this.lblRole);
        this.pnlForm.Controls.Add(this.cmbRole);
        this.pnlForm.Controls.Add(this.lblPassword);
        this.pnlForm.Controls.Add(this.txtPassword);
        this.pnlForm.Controls.Add(this.btnSave);
        this.pnlForm.Controls.Add(this.btnResetPassword);
        this.pnlForm.Controls.Add(this.btnDelete);
        this.pnlForm.Controls.Add(this.btnClear);
        this.pnlForm.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlForm.Name = "pnlForm";
        this.pnlForm.Size = new System.Drawing.Size(560, 160);
        this.pnlForm.TabIndex = 1;

        this.lblUsername.AutoSize = true;
        this.lblUsername.Location = new System.Drawing.Point(12, 18);
        this.lblUsername.Text = "Username";
        this.txtUsername.Location = new System.Drawing.Point(100, 15);
        this.txtUsername.Size = new System.Drawing.Size(180, 23);
        this.txtUsername.TabIndex = 0;

        this.lblFullName.AutoSize = true;
        this.lblFullName.Location = new System.Drawing.Point(12, 50);
        this.lblFullName.Text = "Nama Lengkap";
        this.txtFullName.Location = new System.Drawing.Point(100, 47);
        this.txtFullName.Size = new System.Drawing.Size(180, 23);
        this.txtFullName.TabIndex = 1;

        this.lblRole.AutoSize = true;
        this.lblRole.Location = new System.Drawing.Point(300, 18);
        this.lblRole.Text = "Role";
        this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbRole.Location = new System.Drawing.Point(370, 15);
        this.cmbRole.Size = new System.Drawing.Size(170, 23);
        this.cmbRole.TabIndex = 2;

        this.lblPassword.AutoSize = true;
        this.lblPassword.Location = new System.Drawing.Point(300, 50);
        this.lblPassword.Text = "Password";
        this.txtPassword.Location = new System.Drawing.Point(370, 47);
        this.txtPassword.Size = new System.Drawing.Size(170, 23);
        this.txtPassword.UseSystemPasswordChar = true;
        this.txtPassword.TabIndex = 3;

        this.btnSave.Location = new System.Drawing.Point(100, 100);
        this.btnSave.Size = new System.Drawing.Size(100, 32);
        this.btnSave.Text = "Simpan";
        this.btnSave.TabIndex = 4;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

        this.btnResetPassword.Location = new System.Drawing.Point(210, 100);
        this.btnResetPassword.Size = new System.Drawing.Size(130, 32);
        this.btnResetPassword.Text = "Reset Password";
        this.btnResetPassword.TabIndex = 5;
        this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

        this.btnDelete.Location = new System.Drawing.Point(350, 100);
        this.btnDelete.Size = new System.Drawing.Size(90, 32);
        this.btnDelete.Text = "Hapus";
        this.btnDelete.TabIndex = 6;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        this.btnClear.Location = new System.Drawing.Point(450, 100);
        this.btnClear.Size = new System.Drawing.Size(90, 32);
        this.btnClear.Text = "Bersihkan";
        this.btnClear.TabIndex = 7;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
        //
        // UserForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(560, 460);
        this.Controls.Add(this.dgvUser);
        this.Controls.Add(this.pnlForm);
        this.MinimumSize = new System.Drawing.Size(576, 499);
        this.Name = "UserForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Kelola User";
        this.Load += new System.EventHandler(this.UserForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
        this.pnlForm.ResumeLayout(false);
        this.pnlForm.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.DataGridView dgvUser;
    private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
    private System.Windows.Forms.Panel pnlForm;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label lblFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lblRole;
    private System.Windows.Forms.ComboBox cmbRole;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnResetPassword;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnClear;
}

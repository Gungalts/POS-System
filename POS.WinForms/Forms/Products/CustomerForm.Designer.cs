namespace POS.WinForms.Forms.Products;

partial class CustomerForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.dgvCustomer = new System.Windows.Forms.DataGridView();
        this.lblCustomerName = new System.Windows.Forms.Label();
        this.txtCustomerName = new System.Windows.Forms.TextBox();
        this.lblPhoneNumber = new System.Windows.Forms.Label();
        this.txtPhoneNumber = new System.Windows.Forms.TextBox();
        this.lblAddress = new System.Windows.Forms.Label();
        this.txtAddress = new System.Windows.Forms.TextBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();
        this.pnlForm = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
        this.pnlForm.SuspendLayout();
        this.SuspendLayout();
        //
        // dgvCustomer
        //
        this.dgvCustomer.AllowUserToAddRows = false;
        this.dgvCustomer.AllowUserToDeleteRows = false;
        this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvCustomer.Location = new System.Drawing.Point(0, 0);
        this.dgvCustomer.MultiSelect = false;
        this.dgvCustomer.Name = "dgvCustomer";
        this.dgvCustomer.ReadOnly = true;
        this.dgvCustomer.RowHeadersVisible = false;
        this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvCustomer.Size = new System.Drawing.Size(600, 280);
        this.dgvCustomer.TabIndex = 0;
        this.dgvCustomer.SelectionChanged += new System.EventHandler(this.dgvCustomer_SelectionChanged);
        //
        // pnlForm
        //
        this.pnlForm.Controls.Add(this.btnClear);
        this.pnlForm.Controls.Add(this.btnDelete);
        this.pnlForm.Controls.Add(this.btnSave);
        this.pnlForm.Controls.Add(this.txtAddress);
        this.pnlForm.Controls.Add(this.lblAddress);
        this.pnlForm.Controls.Add(this.txtPhoneNumber);
        this.pnlForm.Controls.Add(this.lblPhoneNumber);
        this.pnlForm.Controls.Add(this.txtCustomerName);
        this.pnlForm.Controls.Add(this.lblCustomerName);
        this.pnlForm.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlForm.Location = new System.Drawing.Point(0, 280);
        this.pnlForm.Name = "pnlForm";
        this.pnlForm.Padding = new System.Windows.Forms.Padding(12);
        this.pnlForm.Size = new System.Drawing.Size(600, 150);
        this.pnlForm.TabIndex = 1;
        //
        // lblCustomerName
        //
        this.lblCustomerName.AutoSize = true;
        this.lblCustomerName.Location = new System.Drawing.Point(12, 20);
        this.lblCustomerName.Name = "lblCustomerName";
        this.lblCustomerName.Size = new System.Drawing.Size(96, 15);
        this.lblCustomerName.TabIndex = 0;
        this.lblCustomerName.Text = "Nama Customer";
        //
        // txtCustomerName
        //
        this.txtCustomerName.Location = new System.Drawing.Point(120, 17);
        this.txtCustomerName.Name = "txtCustomerName";
        this.txtCustomerName.Size = new System.Drawing.Size(250, 23);
        this.txtCustomerName.TabIndex = 1;
        //
        // lblPhoneNumber
        //
        this.lblPhoneNumber.AutoSize = true;
        this.lblPhoneNumber.Location = new System.Drawing.Point(12, 52);
        this.lblPhoneNumber.Name = "lblPhoneNumber";
        this.lblPhoneNumber.Size = new System.Drawing.Size(88, 15);
        this.lblPhoneNumber.TabIndex = 2;
        this.lblPhoneNumber.Text = "No. Telepon";
        //
        // txtPhoneNumber
        //
        this.txtPhoneNumber.Location = new System.Drawing.Point(120, 49);
        this.txtPhoneNumber.Name = "txtPhoneNumber";
        this.txtPhoneNumber.Size = new System.Drawing.Size(250, 23);
        this.txtPhoneNumber.TabIndex = 3;
        //
        // lblAddress
        //
        this.lblAddress.AutoSize = true;
        this.lblAddress.Location = new System.Drawing.Point(12, 84);
        this.lblAddress.Name = "lblAddress";
        this.lblAddress.Size = new System.Drawing.Size(48, 15);
        this.lblAddress.TabIndex = 4;
        this.lblAddress.Text = "Alamat";
        //
        // txtAddress
        //
        this.txtAddress.Location = new System.Drawing.Point(120, 81);
        this.txtAddress.Name = "txtAddress";
        this.txtAddress.Size = new System.Drawing.Size(250, 23);
        this.txtAddress.TabIndex = 5;
        //
        // btnSave
        //
        this.btnSave.Location = new System.Drawing.Point(390, 16);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(90, 27);
        this.btnSave.TabIndex = 6;
        this.btnSave.Text = "Simpan";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        //
        // btnDelete
        //
        this.btnDelete.Location = new System.Drawing.Point(490, 16);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(90, 27);
        this.btnDelete.TabIndex = 7;
        this.btnDelete.Text = "Hapus";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        //
        // btnClear
        //
        this.btnClear.Location = new System.Drawing.Point(390, 49);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(90, 27);
        this.btnClear.TabIndex = 8;
        this.btnClear.Text = "Bersihkan";
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
        //
        // CustomerForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(600, 430);
        this.Controls.Add(this.dgvCustomer);
        this.Controls.Add(this.pnlForm);
        this.MinimumSize = new System.Drawing.Size(500, 450);
        this.Name = "CustomerForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Kelola Customer";
        this.Load += new System.EventHandler(this.CustomerForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
        this.pnlForm.ResumeLayout(false);
        this.pnlForm.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.DataGridView dgvCustomer;
    private System.Windows.Forms.Panel pnlForm;
    private System.Windows.Forms.Label lblCustomerName;
    private System.Windows.Forms.TextBox txtCustomerName;
    private System.Windows.Forms.Label lblPhoneNumber;
    private System.Windows.Forms.TextBox txtPhoneNumber;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnClear;
}

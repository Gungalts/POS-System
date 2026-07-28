namespace POS.WinForms.Forms.Products;

partial class SupplierForm
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
        this.dgvSupplier = new System.Windows.Forms.DataGridView();
        this.lblSupplierName = new System.Windows.Forms.Label();
        this.txtSupplierName = new System.Windows.Forms.TextBox();
        this.lblPhoneNumber = new System.Windows.Forms.Label();
        this.txtPhoneNumber = new System.Windows.Forms.TextBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();
        this.pnlForm = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
        this.pnlForm.SuspendLayout();
        this.SuspendLayout();
        //
        // dgvSupplier
        //
        this.dgvSupplier.AllowUserToAddRows = false;
        this.dgvSupplier.AllowUserToDeleteRows = false;
        this.dgvSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvSupplier.Location = new System.Drawing.Point(0, 0);
        this.dgvSupplier.MultiSelect = false;
        this.dgvSupplier.Name = "dgvSupplier";
        this.dgvSupplier.ReadOnly = true;
        this.dgvSupplier.RowHeadersVisible = false;
        this.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvSupplier.Size = new System.Drawing.Size(600, 300);
        this.dgvSupplier.TabIndex = 0;
        this.dgvSupplier.SelectionChanged += new System.EventHandler(this.dgvSupplier_SelectionChanged);
        //
        // pnlForm
        //
        this.pnlForm.Controls.Add(this.btnClear);
        this.pnlForm.Controls.Add(this.btnDelete);
        this.pnlForm.Controls.Add(this.btnSave);
        this.pnlForm.Controls.Add(this.txtPhoneNumber);
        this.pnlForm.Controls.Add(this.lblPhoneNumber);
        this.pnlForm.Controls.Add(this.txtSupplierName);
        this.pnlForm.Controls.Add(this.lblSupplierName);
        this.pnlForm.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlForm.Location = new System.Drawing.Point(0, 300);
        this.pnlForm.Name = "pnlForm";
        this.pnlForm.Padding = new System.Windows.Forms.Padding(12);
        this.pnlForm.Size = new System.Drawing.Size(600, 120);
        this.pnlForm.TabIndex = 1;
        //
        // lblSupplierName
        //
        this.lblSupplierName.AutoSize = true;
        this.lblSupplierName.Location = new System.Drawing.Point(12, 20);
        this.lblSupplierName.Name = "lblSupplierName";
        this.lblSupplierName.Size = new System.Drawing.Size(96, 15);
        this.lblSupplierName.TabIndex = 0;
        this.lblSupplierName.Text = "Nama Supplier";
        //
        // txtSupplierName
        //
        this.txtSupplierName.Location = new System.Drawing.Point(120, 17);
        this.txtSupplierName.Name = "txtSupplierName";
        this.txtSupplierName.Size = new System.Drawing.Size(250, 23);
        this.txtSupplierName.TabIndex = 1;
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
        // btnSave
        //
        this.btnSave.Location = new System.Drawing.Point(390, 16);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(90, 27);
        this.btnSave.TabIndex = 4;
        this.btnSave.Text = "Simpan";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        //
        // btnDelete
        //
        this.btnDelete.Location = new System.Drawing.Point(490, 16);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(90, 27);
        this.btnDelete.TabIndex = 5;
        this.btnDelete.Text = "Hapus";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        //
        // btnClear
        //
        this.btnClear.Location = new System.Drawing.Point(390, 49);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(90, 27);
        this.btnClear.TabIndex = 6;
        this.btnClear.Text = "Bersihkan";
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
        //
        // SupplierForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(600, 420);
        this.Controls.Add(this.dgvSupplier);
        this.Controls.Add(this.pnlForm);
        this.MinimumSize = new System.Drawing.Size(500, 420);
        this.Name = "SupplierForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Kelola Supplier";
        this.Load += new System.EventHandler(this.SupplierForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
        this.pnlForm.ResumeLayout(false);
        this.pnlForm.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.DataGridView dgvSupplier;
    private System.Windows.Forms.Panel pnlForm;
    private System.Windows.Forms.Label lblSupplierName;
    private System.Windows.Forms.TextBox txtSupplierName;
    private System.Windows.Forms.Label lblPhoneNumber;
    private System.Windows.Forms.TextBox txtPhoneNumber;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnClear;
}

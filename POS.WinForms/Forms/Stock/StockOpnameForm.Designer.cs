namespace POS.WinForms.Forms.Stock;

partial class StockOpnameForm
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
        this.dgvOpname = new System.Windows.Forms.DataGridView();
        this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPhysical = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlBottom = new System.Windows.Forms.Panel();
        this.lblNotes = new System.Windows.Forms.Label();
        this.txtNotes = new System.Windows.Forms.TextBox();
        this.btnReload = new System.Windows.Forms.Button();
        this.btnSave = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOpname)).BeginInit();
        this.pnlBottom.SuspendLayout();
        this.SuspendLayout();
        //
        // dgvOpname
        //
        this.dgvOpname.AllowUserToAddRows = false;
        this.dgvOpname.AllowUserToDeleteRows = false;
        this.dgvOpname.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName, this.colSystem, this.colPhysical, this.colDiff });
        this.dgvOpname.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvOpname.MultiSelect = false;
        this.dgvOpname.Name = "dgvOpname";
        this.dgvOpname.RowHeadersVisible = false;
        this.dgvOpname.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
        this.dgvOpname.TabIndex = 0;
        this.dgvOpname.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOpname_CellEndEdit);

        this.colName.DataPropertyName = "ProductName";
        this.colName.HeaderText = "Produk";
        this.colName.Name = "colName";
        this.colName.ReadOnly = true;
        this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colSystem.DataPropertyName = "SystemStock";
        this.colSystem.HeaderText = "Stok Sistem";
        this.colSystem.Name = "colSystem";
        this.colSystem.ReadOnly = true;
        this.colSystem.Width = 110;
        this.colPhysical.DataPropertyName = "PhysicalStock";
        this.colPhysical.HeaderText = "Stok Fisik";
        this.colPhysical.Name = "colPhysical";
        this.colPhysical.Width = 110;
        this.colDiff.DataPropertyName = "Difference";
        this.colDiff.HeaderText = "Selisih";
        this.colDiff.Name = "colDiff";
        this.colDiff.ReadOnly = true;
        this.colDiff.Width = 90;
        //
        // pnlBottom
        //
        this.pnlBottom.Controls.Add(this.lblNotes);
        this.pnlBottom.Controls.Add(this.txtNotes);
        this.pnlBottom.Controls.Add(this.btnReload);
        this.pnlBottom.Controls.Add(this.btnSave);
        this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Size = new System.Drawing.Size(560, 90);
        this.pnlBottom.TabIndex = 1;

        this.lblNotes.AutoSize = true;
        this.lblNotes.Location = new System.Drawing.Point(12, 18);
        this.lblNotes.Text = "Catatan";
        this.txtNotes.Location = new System.Drawing.Point(75, 15);
        this.txtNotes.Size = new System.Drawing.Size(300, 23);
        this.txtNotes.TabIndex = 0;

        this.btnReload.Location = new System.Drawing.Point(75, 50);
        this.btnReload.Size = new System.Drawing.Size(140, 30);
        this.btnReload.Text = "Muat Ulang";
        this.btnReload.TabIndex = 1;
        this.btnReload.Click += new System.EventHandler(this.btnReload_Click);

        this.btnSave.Location = new System.Drawing.Point(235, 50);
        this.btnSave.Size = new System.Drawing.Size(140, 30);
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnSave.Text = "SIMPAN OPNAME";
        this.btnSave.TabIndex = 2;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        //
        // StockOpnameForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(560, 520);
        this.Controls.Add(this.dgvOpname);
        this.Controls.Add(this.pnlBottom);
        this.MinimumSize = new System.Drawing.Size(576, 400);
        this.Name = "StockOpnameForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Stock Opname";
        this.Load += new System.EventHandler(this.StockOpnameForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvOpname)).EndInit();
        this.pnlBottom.ResumeLayout(false);
        this.pnlBottom.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.DataGridView dgvOpname;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSystem;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPhysical;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDiff;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Label lblNotes;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.Button btnReload;
    private System.Windows.Forms.Button btnSave;
}

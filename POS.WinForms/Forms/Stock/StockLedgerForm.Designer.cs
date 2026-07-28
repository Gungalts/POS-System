namespace POS.WinForms.Forms.Stock;

partial class StockLedgerForm
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
        this.pnlTop = new System.Windows.Forms.Panel();
        this.lblProduct = new System.Windows.Forms.Label();
        this.cmbProduct = new System.Windows.Forms.ComboBox();
        this.lblFrom = new System.Windows.Forms.Label();
        this.dtpFrom = new System.Windows.Forms.DateTimePicker();
        this.lblTo = new System.Windows.Forms.Label();
        this.dtpTo = new System.Windows.Forms.DateTimePicker();
        this.btnApply = new System.Windows.Forms.Button();
        this.btnAll = new System.Windows.Forms.Button();
        this.dgvLedger = new System.Windows.Forms.DataGridView();
        this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
        this.pnlTop.SuspendLayout();
        this.SuspendLayout();
        //
        // pnlTop
        //
        this.pnlTop.Controls.Add(this.lblProduct);
        this.pnlTop.Controls.Add(this.cmbProduct);
        this.pnlTop.Controls.Add(this.lblFrom);
        this.pnlTop.Controls.Add(this.dtpFrom);
        this.pnlTop.Controls.Add(this.lblTo);
        this.pnlTop.Controls.Add(this.dtpTo);
        this.pnlTop.Controls.Add(this.btnApply);
        this.pnlTop.Controls.Add(this.btnAll);
        this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Size = new System.Drawing.Size(840, 90);
        this.pnlTop.TabIndex = 0;

        this.lblProduct.AutoSize = true;
        this.lblProduct.Location = new System.Drawing.Point(12, 16);
        this.lblProduct.Text = "Produk";
        this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbProduct.Location = new System.Drawing.Point(75, 13);
        this.cmbProduct.Size = new System.Drawing.Size(250, 23);
        this.cmbProduct.TabIndex = 0;

        this.lblFrom.AutoSize = true;
        this.lblFrom.Location = new System.Drawing.Point(12, 52);
        this.lblFrom.Text = "Dari";
        this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpFrom.Location = new System.Drawing.Point(75, 49);
        this.dtpFrom.Size = new System.Drawing.Size(120, 23);
        this.dtpFrom.TabIndex = 1;

        this.lblTo.AutoSize = true;
        this.lblTo.Location = new System.Drawing.Point(210, 52);
        this.lblTo.Text = "Sampai";
        this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpTo.Location = new System.Drawing.Point(265, 49);
        this.dtpTo.Size = new System.Drawing.Size(120, 23);
        this.dtpTo.TabIndex = 2;

        this.btnApply.Location = new System.Drawing.Point(410, 47);
        this.btnApply.Size = new System.Drawing.Size(110, 27);
        this.btnApply.Text = "Terapkan Filter";
        this.btnApply.TabIndex = 3;
        this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
        this.btnAll.Location = new System.Drawing.Point(528, 47);
        this.btnAll.Size = new System.Drawing.Size(100, 27);
        this.btnAll.Text = "Tampilkan Semua";
        this.btnAll.TabIndex = 4;
        this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
        //
        // dgvLedger
        //
        this.dgvLedger.AllowUserToAddRows = false;
        this.dgvLedger.AllowUserToDeleteRows = false;
        this.dgvLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate, this.colProduct, this.colType, this.colChange,
            this.colBefore, this.colAfter, this.colRef, this.colNotes });
        this.dgvLedger.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvLedger.MultiSelect = false;
        this.dgvLedger.Name = "dgvLedger";
        this.dgvLedger.ReadOnly = true;
        this.dgvLedger.RowHeadersVisible = false;
        this.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvLedger.TabIndex = 1;

        this.colDate.DataPropertyName = "CreatedAt";
        this.colDate.HeaderText = "Waktu";
        this.colDate.Name = "colDate";
        this.colDate.Width = 140;
        this.colProduct.DataPropertyName = "ProductName";
        this.colProduct.HeaderText = "Produk";
        this.colProduct.Name = "colProduct";
        this.colProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colType.DataPropertyName = "MovementType";
        this.colType.HeaderText = "Jenis";
        this.colType.Name = "colType";
        this.colType.Width = 90;
        this.colChange.DataPropertyName = "QuantityChange";
        this.colChange.HeaderText = "Perubahan";
        this.colChange.Name = "colChange";
        this.colChange.Width = 90;
        this.colBefore.DataPropertyName = "StockBefore";
        this.colBefore.HeaderText = "Stok Awal";
        this.colBefore.Name = "colBefore";
        this.colBefore.Width = 80;
        this.colAfter.DataPropertyName = "StockAfter";
        this.colAfter.HeaderText = "Stok Akhir";
        this.colAfter.Name = "colAfter";
        this.colAfter.Width = 80;
        this.colRef.DataPropertyName = "ReferenceType";
        this.colRef.HeaderText = "Sumber";
        this.colRef.Name = "colRef";
        this.colRef.Width = 80;
        this.colNotes.DataPropertyName = "Notes";
        this.colNotes.HeaderText = "Catatan";
        this.colNotes.Name = "colNotes";
        this.colNotes.Width = 120;
        //
        // StockLedgerForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(840, 520);
        this.Controls.Add(this.dgvLedger);
        this.Controls.Add(this.pnlTop);
        this.MinimumSize = new System.Drawing.Size(700, 400);
        this.Name = "StockLedgerForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Stock Ledger - Riwayat Pergerakan Barang";
        this.Load += new System.EventHandler(this.StockLedgerForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblProduct;
    private System.Windows.Forms.ComboBox cmbProduct;
    private System.Windows.Forms.Label lblFrom;
    private System.Windows.Forms.DateTimePicker dtpFrom;
    private System.Windows.Forms.Label lblTo;
    private System.Windows.Forms.DateTimePicker dtpTo;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.Button btnAll;
    private System.Windows.Forms.DataGridView dgvLedger;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
    private System.Windows.Forms.DataGridViewTextBoxColumn colType;
    private System.Windows.Forms.DataGridViewTextBoxColumn colChange;
    private System.Windows.Forms.DataGridViewTextBoxColumn colBefore;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAfter;
    private System.Windows.Forms.DataGridViewTextBoxColumn colRef;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
}

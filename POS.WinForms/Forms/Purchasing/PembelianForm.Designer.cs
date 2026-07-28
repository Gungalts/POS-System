namespace POS.WinForms.Forms.Purchasing;

partial class PembelianForm
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
        this.lblSupplier = new System.Windows.Forms.Label();
        this.cmbSupplier = new System.Windows.Forms.ComboBox();
        this.lblScan = new System.Windows.Forms.Label();
        this.txtBarcode = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.dgvLines = new System.Windows.Forms.DataGridView();
        this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlBottom = new System.Windows.Forms.Panel();
        this.lblTotal = new System.Windows.Forms.Label();
        this.lblTotalValue = new System.Windows.Forms.Label();
        this.lblInitialPayment = new System.Windows.Forms.Label();
        this.numInitialPayment = new System.Windows.Forms.NumericUpDown();
        this.lblNotes = new System.Windows.Forms.Label();
        this.txtNotes = new System.Windows.Forms.TextBox();
        this.btnRemoveItem = new System.Windows.Forms.Button();
        this.btnSave = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numInitialPayment)).BeginInit();
        this.pnlTop.SuspendLayout();
        this.pnlBottom.SuspendLayout();
        this.SuspendLayout();
        //
        // pnlTop
        //
        this.pnlTop.Controls.Add(this.lblSupplier);
        this.pnlTop.Controls.Add(this.cmbSupplier);
        this.pnlTop.Controls.Add(this.lblScan);
        this.pnlTop.Controls.Add(this.txtBarcode);
        this.pnlTop.Controls.Add(this.btnAdd);
        this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Size = new System.Drawing.Size(720, 55);
        this.pnlTop.TabIndex = 0;

        this.lblSupplier.AutoSize = true;
        this.lblSupplier.Location = new System.Drawing.Point(12, 18);
        this.lblSupplier.Text = "Supplier";
        this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbSupplier.Location = new System.Drawing.Point(75, 15);
        this.cmbSupplier.Size = new System.Drawing.Size(200, 23);
        this.cmbSupplier.TabIndex = 0;

        this.lblScan.AutoSize = true;
        this.lblScan.Location = new System.Drawing.Point(295, 18);
        this.lblScan.Text = "Barcode / Cari";
        this.txtBarcode.Location = new System.Drawing.Point(390, 15);
        this.txtBarcode.Size = new System.Drawing.Size(220, 23);
        this.txtBarcode.TabIndex = 1;
        this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
        this.btnAdd.Location = new System.Drawing.Point(616, 14);
        this.btnAdd.Size = new System.Drawing.Size(90, 26);
        this.btnAdd.Text = "Tambah";
        this.btnAdd.TabIndex = 2;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        //
        // dgvLines
        //
        this.dgvLines.AllowUserToAddRows = false;
        this.dgvLines.AllowUserToDeleteRows = false;
        this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName, this.colQty, this.colPrice, this.colSubtotal });
        this.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvLines.MultiSelect = false;
        this.dgvLines.Name = "dgvLines";
        this.dgvLines.RowHeadersVisible = false;
        this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvLines.TabIndex = 1;
        this.dgvLines.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLines_CellEndEdit);

        this.colName.DataPropertyName = "ProductName";
        this.colName.HeaderText = "Produk";
        this.colName.Name = "colName";
        this.colName.ReadOnly = true;
        this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colQty.DataPropertyName = "Quantity";
        this.colQty.HeaderText = "Qty (Beli)";
        this.colQty.Name = "colQty";
        this.colQty.Width = 90;
        this.colPrice.DataPropertyName = "PurchasePrice";
        this.colPrice.HeaderText = "Harga Beli";
        this.colPrice.Name = "colPrice";
        this.colPrice.Width = 120;
        this.colPrice.DefaultCellStyle.Format = "N0";
        this.colSubtotal.DataPropertyName = "Subtotal";
        this.colSubtotal.HeaderText = "Subtotal";
        this.colSubtotal.Name = "colSubtotal";
        this.colSubtotal.ReadOnly = true;
        this.colSubtotal.Width = 130;
        this.colSubtotal.DefaultCellStyle.Format = "N0";
        //
        // pnlBottom
        //
        this.pnlBottom.Controls.Add(this.lblTotal);
        this.pnlBottom.Controls.Add(this.lblTotalValue);
        this.pnlBottom.Controls.Add(this.lblInitialPayment);
        this.pnlBottom.Controls.Add(this.numInitialPayment);
        this.pnlBottom.Controls.Add(this.lblNotes);
        this.pnlBottom.Controls.Add(this.txtNotes);
        this.pnlBottom.Controls.Add(this.btnRemoveItem);
        this.pnlBottom.Controls.Add(this.btnSave);
        this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Size = new System.Drawing.Size(720, 140);
        this.pnlBottom.TabIndex = 2;

        this.lblTotal.AutoSize = true;
        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotal.Location = new System.Drawing.Point(12, 12);
        this.lblTotal.Text = "TOTAL";
        this.lblTotalValue.AutoSize = true;
        this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotalValue.Location = new System.Drawing.Point(90, 12);
        this.lblTotalValue.Text = "Rp 0";

        this.lblInitialPayment.AutoSize = true;
        this.lblInitialPayment.Location = new System.Drawing.Point(12, 55);
        this.lblInitialPayment.Text = "Pembayaran Awal";
        this.numInitialPayment.Location = new System.Drawing.Point(130, 52);
        this.numInitialPayment.Size = new System.Drawing.Size(160, 23);
        this.numInitialPayment.Maximum = 1000000000;
        this.numInitialPayment.ThousandsSeparator = true;
        this.numInitialPayment.TabIndex = 0;

        this.lblNotes.AutoSize = true;
        this.lblNotes.Location = new System.Drawing.Point(12, 90);
        this.lblNotes.Text = "Catatan";
        this.txtNotes.Location = new System.Drawing.Point(130, 87);
        this.txtNotes.Size = new System.Drawing.Size(280, 23);
        this.txtNotes.TabIndex = 1;

        this.btnRemoveItem.Location = new System.Drawing.Point(470, 50);
        this.btnRemoveItem.Size = new System.Drawing.Size(120, 30);
        this.btnRemoveItem.Text = "Hapus Baris";
        this.btnRemoveItem.TabIndex = 2;
        this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
        this.btnSave.Location = new System.Drawing.Point(470, 90);
        this.btnSave.Size = new System.Drawing.Size(230, 40);
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnSave.Text = "SIMPAN PEMBELIAN";
        this.btnSave.TabIndex = 3;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        //
        // PembelianForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(720, 520);
        this.Controls.Add(this.dgvLines);
        this.Controls.Add(this.pnlBottom);
        this.Controls.Add(this.pnlTop);
        this.MinimumSize = new System.Drawing.Size(736, 559);
        this.Name = "PembelianForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Pembelian";
        this.Load += new System.EventHandler(this.PembelianForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numInitialPayment)).EndInit();
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.pnlBottom.ResumeLayout(false);
        this.pnlBottom.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblSupplier;
    private System.Windows.Forms.ComboBox cmbSupplier;
    private System.Windows.Forms.Label lblScan;
    private System.Windows.Forms.TextBox txtBarcode;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.DataGridView dgvLines;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblTotalValue;
    private System.Windows.Forms.Label lblInitialPayment;
    private System.Windows.Forms.NumericUpDown numInitialPayment;
    private System.Windows.Forms.Label lblNotes;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.Button btnRemoveItem;
    private System.Windows.Forms.Button btnSave;
}

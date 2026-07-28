namespace POS.WinForms.Forms.Cashier;

partial class KasirForm
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
        this.lblScan = new System.Windows.Forms.Label();
        this.txtBarcode = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.lblCustomer = new System.Windows.Forms.Label();
        this.cmbCustomer = new System.Windows.Forms.ComboBox();
        this.dgvCart = new System.Windows.Forms.DataGridView();
        this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlBottom = new System.Windows.Forms.Panel();
        this.lblTotal = new System.Windows.Forms.Label();
        this.lblTotalValue = new System.Windows.Forms.Label();
        this.lblPaymentMethod = new System.Windows.Forms.Label();
        this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
        this.lblAmountPaid = new System.Windows.Forms.Label();
        this.numAmountPaid = new System.Windows.Forms.NumericUpDown();
        this.lblChange = new System.Windows.Forms.Label();
        this.lblChangeValue = new System.Windows.Forms.Label();
        this.btnRemoveItem = new System.Windows.Forms.Button();
        this.btnClearCart = new System.Windows.Forms.Button();
        this.btnCheckout = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numAmountPaid)).BeginInit();
        this.pnlTop.SuspendLayout();
        this.pnlBottom.SuspendLayout();
        this.SuspendLayout();
        //
        // pnlTop
        //
        this.pnlTop.Controls.Add(this.lblScan);
        this.pnlTop.Controls.Add(this.txtBarcode);
        this.pnlTop.Controls.Add(this.btnAdd);
        this.pnlTop.Controls.Add(this.lblCustomer);
        this.pnlTop.Controls.Add(this.cmbCustomer);
        this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Size = new System.Drawing.Size(720, 55);
        this.pnlTop.TabIndex = 0;

        this.lblScan.AutoSize = true;
        this.lblScan.Location = new System.Drawing.Point(12, 18);
        this.lblScan.Text = "Barcode / Cari";
        this.txtBarcode.Location = new System.Drawing.Point(110, 15);
        this.txtBarcode.Size = new System.Drawing.Size(220, 23);
        this.txtBarcode.TabIndex = 0;
        this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
        this.btnAdd.Location = new System.Drawing.Point(336, 14);
        this.btnAdd.Size = new System.Drawing.Size(90, 26);
        this.btnAdd.Text = "Tambah";
        this.btnAdd.TabIndex = 1;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        this.lblCustomer.AutoSize = true;
        this.lblCustomer.Location = new System.Drawing.Point(450, 18);
        this.lblCustomer.Text = "Pelanggan";
        this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbCustomer.Location = new System.Drawing.Point(525, 15);
        this.cmbCustomer.Size = new System.Drawing.Size(180, 23);
        this.cmbCustomer.TabIndex = 2;
        //
        // dgvCart
        //
        this.dgvCart.AllowUserToAddRows = false;
        this.dgvCart.AllowUserToDeleteRows = false;
        this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName, this.colPrice, this.colQty, this.colSubtotal });
        this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvCart.MultiSelect = false;
        this.dgvCart.Name = "dgvCart";
        this.dgvCart.RowHeadersVisible = false;
        this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvCart.TabIndex = 1;
        this.dgvCart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellEndEdit);

        this.colName.DataPropertyName = "ProductName";
        this.colName.HeaderText = "Produk";
        this.colName.Name = "colName";
        this.colName.ReadOnly = true;
        this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colPrice.DataPropertyName = "SalePrice";
        this.colPrice.HeaderText = "Harga";
        this.colPrice.Name = "colPrice";
        this.colPrice.ReadOnly = true;
        this.colPrice.DefaultCellStyle.Format = "N0";
        this.colPrice.Width = 100;
        this.colQty.DataPropertyName = "Quantity";
        this.colQty.HeaderText = "Qty";
        this.colQty.Name = "colQty";
        this.colQty.Width = 70;
        this.colSubtotal.DataPropertyName = "Subtotal";
        this.colSubtotal.HeaderText = "Subtotal";
        this.colSubtotal.Name = "colSubtotal";
        this.colSubtotal.ReadOnly = true;
        this.colSubtotal.DefaultCellStyle.Format = "N0";
        this.colSubtotal.Width = 120;
        //
        // pnlBottom
        //
        this.pnlBottom.Controls.Add(this.lblTotal);
        this.pnlBottom.Controls.Add(this.lblTotalValue);
        this.pnlBottom.Controls.Add(this.lblPaymentMethod);
        this.pnlBottom.Controls.Add(this.cmbPaymentMethod);
        this.pnlBottom.Controls.Add(this.lblAmountPaid);
        this.pnlBottom.Controls.Add(this.numAmountPaid);
        this.pnlBottom.Controls.Add(this.lblChange);
        this.pnlBottom.Controls.Add(this.lblChangeValue);
        this.pnlBottom.Controls.Add(this.btnRemoveItem);
        this.pnlBottom.Controls.Add(this.btnClearCart);
        this.pnlBottom.Controls.Add(this.btnCheckout);
        this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Size = new System.Drawing.Size(720, 160);
        this.pnlBottom.TabIndex = 2;

        this.lblTotal.AutoSize = true;
        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotal.Location = new System.Drawing.Point(12, 12);
        this.lblTotal.Text = "TOTAL";
        this.lblTotalValue.AutoSize = true;
        this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotalValue.Location = new System.Drawing.Point(90, 12);
        this.lblTotalValue.Text = "Rp 0";

        this.lblPaymentMethod.AutoSize = true;
        this.lblPaymentMethod.Location = new System.Drawing.Point(12, 55);
        this.lblPaymentMethod.Text = "Metode Bayar";
        this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbPaymentMethod.Location = new System.Drawing.Point(110, 52);
        this.cmbPaymentMethod.Size = new System.Drawing.Size(150, 23);
        this.cmbPaymentMethod.TabIndex = 0;

        this.lblAmountPaid.AutoSize = true;
        this.lblAmountPaid.Location = new System.Drawing.Point(12, 90);
        this.lblAmountPaid.Text = "Jumlah Bayar";
        this.numAmountPaid.Location = new System.Drawing.Point(110, 87);
        this.numAmountPaid.Size = new System.Drawing.Size(150, 23);
        this.numAmountPaid.Maximum = 1000000000;
        this.numAmountPaid.ThousandsSeparator = true;
        this.numAmountPaid.TabIndex = 1;
        this.numAmountPaid.ValueChanged += new System.EventHandler(this.numAmountPaid_ValueChanged);

        this.lblChange.AutoSize = true;
        this.lblChange.Location = new System.Drawing.Point(12, 122);
        this.lblChange.Text = "Kembalian";
        this.lblChangeValue.AutoSize = true;
        this.lblChangeValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblChangeValue.ForeColor = System.Drawing.Color.Green;
        this.lblChangeValue.Location = new System.Drawing.Point(110, 121);
        this.lblChangeValue.Text = "Rp 0";

        this.btnRemoveItem.Location = new System.Drawing.Point(470, 50);
        this.btnRemoveItem.Size = new System.Drawing.Size(110, 30);
        this.btnRemoveItem.Text = "Hapus Baris";
        this.btnRemoveItem.TabIndex = 2;
        this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
        this.btnClearCart.Location = new System.Drawing.Point(590, 50);
        this.btnClearCart.Size = new System.Drawing.Size(110, 30);
        this.btnClearCart.Text = "Kosongkan";
        this.btnClearCart.TabIndex = 3;
        this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
        this.btnCheckout.Location = new System.Drawing.Point(470, 95);
        this.btnCheckout.Size = new System.Drawing.Size(230, 45);
        this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnCheckout.Text = "BAYAR";
        this.btnCheckout.TabIndex = 4;
        this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
        //
        // KasirForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(720, 520);
        this.Controls.Add(this.dgvCart);
        this.Controls.Add(this.pnlBottom);
        this.Controls.Add(this.pnlTop);
        this.MinimumSize = new System.Drawing.Size(736, 559);
        this.Name = "KasirForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Kasir - Penjualan";
        this.Load += new System.EventHandler(this.KasirForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numAmountPaid)).EndInit();
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.pnlBottom.ResumeLayout(false);
        this.pnlBottom.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblScan;
    private System.Windows.Forms.TextBox txtBarcode;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Label lblCustomer;
    private System.Windows.Forms.ComboBox cmbCustomer;
    private System.Windows.Forms.DataGridView dgvCart;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblTotalValue;
    private System.Windows.Forms.Label lblPaymentMethod;
    private System.Windows.Forms.ComboBox cmbPaymentMethod;
    private System.Windows.Forms.Label lblAmountPaid;
    private System.Windows.Forms.NumericUpDown numAmountPaid;
    private System.Windows.Forms.Label lblChange;
    private System.Windows.Forms.Label lblChangeValue;
    private System.Windows.Forms.Button btnRemoveItem;
    private System.Windows.Forms.Button btnClearCart;
    private System.Windows.Forms.Button btnCheckout;
}

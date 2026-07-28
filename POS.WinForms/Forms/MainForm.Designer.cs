namespace POS.WinForms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblMaster;
    private System.Windows.Forms.Button btnCategory;
    private System.Windows.Forms.Button btnSupplier;
    private System.Windows.Forms.Button btnCustomer;
    private System.Windows.Forms.Button btnProduct;
    private System.Windows.Forms.Label lblTrans;
    private System.Windows.Forms.Button btnKasir;
    private System.Windows.Forms.Button btnPembelian;
    private System.Windows.Forms.Button btnHutang;
    private System.Windows.Forms.Button btnOpname;
    private System.Windows.Forms.Button btnLedger;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.lblMaster = new System.Windows.Forms.Label();
        this.btnCategory = new System.Windows.Forms.Button();
        this.btnSupplier = new System.Windows.Forms.Button();
        this.btnCustomer = new System.Windows.Forms.Button();
        this.btnProduct = new System.Windows.Forms.Button();
        this.lblTrans = new System.Windows.Forms.Label();
        this.btnKasir = new System.Windows.Forms.Button();
        this.btnPembelian = new System.Windows.Forms.Button();
        this.btnHutang = new System.Windows.Forms.Button();
        this.btnOpname = new System.Windows.Forms.Button();
        this.btnLedger = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // lblMaster
        //
        this.lblMaster.AutoSize = true;
        this.lblMaster.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblMaster.Location = new System.Drawing.Point(40, 20);
        this.lblMaster.Text = "Master Data";
        //
        // btnCategory
        //
        this.btnCategory.Location = new System.Drawing.Point(40, 50);
        this.btnCategory.Size = new System.Drawing.Size(200, 45);
        this.btnCategory.TabIndex = 0;
        this.btnCategory.Text = "Kelola Kategori";
        this.btnCategory.UseVisualStyleBackColor = true;
        this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
        //
        // btnSupplier
        //
        this.btnSupplier.Location = new System.Drawing.Point(40, 105);
        this.btnSupplier.Size = new System.Drawing.Size(200, 45);
        this.btnSupplier.TabIndex = 1;
        this.btnSupplier.Text = "Kelola Supplier";
        this.btnSupplier.UseVisualStyleBackColor = true;
        this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
        //
        // btnCustomer
        //
        this.btnCustomer.Location = new System.Drawing.Point(40, 160);
        this.btnCustomer.Size = new System.Drawing.Size(200, 45);
        this.btnCustomer.TabIndex = 2;
        this.btnCustomer.Text = "Kelola Customer";
        this.btnCustomer.UseVisualStyleBackColor = true;
        this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
        //
        // btnProduct
        //
        this.btnProduct.Location = new System.Drawing.Point(40, 215);
        this.btnProduct.Size = new System.Drawing.Size(200, 45);
        this.btnProduct.TabIndex = 3;
        this.btnProduct.Text = "Kelola Produk";
        this.btnProduct.UseVisualStyleBackColor = true;
        this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
        //
        // lblTrans
        //
        this.lblTrans.AutoSize = true;
        this.lblTrans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblTrans.Location = new System.Drawing.Point(280, 20);
        this.lblTrans.Text = "Transaksi & Stok";
        //
        // btnKasir
        //
        this.btnKasir.Location = new System.Drawing.Point(280, 50);
        this.btnKasir.Size = new System.Drawing.Size(200, 45);
        this.btnKasir.TabIndex = 4;
        this.btnKasir.Text = "Kasir (Penjualan)";
        this.btnKasir.UseVisualStyleBackColor = true;
        this.btnKasir.Click += new System.EventHandler(this.btnKasir_Click);
        //
        // btnPembelian
        //
        this.btnPembelian.Location = new System.Drawing.Point(280, 105);
        this.btnPembelian.Size = new System.Drawing.Size(200, 45);
        this.btnPembelian.TabIndex = 5;
        this.btnPembelian.Text = "Pembelian";
        this.btnPembelian.UseVisualStyleBackColor = true;
        this.btnPembelian.Click += new System.EventHandler(this.btnPembelian_Click);
        //
        // btnHutang
        //
        this.btnHutang.Location = new System.Drawing.Point(280, 160);
        this.btnHutang.Size = new System.Drawing.Size(200, 45);
        this.btnHutang.TabIndex = 6;
        this.btnHutang.Text = "Pembayaran Hutang";
        this.btnHutang.UseVisualStyleBackColor = true;
        this.btnHutang.Click += new System.EventHandler(this.btnHutang_Click);
        //
        // btnOpname
        //
        this.btnOpname.Location = new System.Drawing.Point(280, 215);
        this.btnOpname.Size = new System.Drawing.Size(200, 45);
        this.btnOpname.TabIndex = 7;
        this.btnOpname.Text = "Stock Opname";
        this.btnOpname.UseVisualStyleBackColor = true;
        this.btnOpname.Click += new System.EventHandler(this.btnOpname_Click);
        //
        // btnLedger
        //
        this.btnLedger.Location = new System.Drawing.Point(280, 270);
        this.btnLedger.Size = new System.Drawing.Size(200, 45);
        this.btnLedger.TabIndex = 8;
        this.btnLedger.Text = "Stock Ledger";
        this.btnLedger.UseVisualStyleBackColor = true;
        this.btnLedger.Click += new System.EventHandler(this.btnLedger_Click);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(520, 345);
        this.Controls.Add(this.lblMaster);
        this.Controls.Add(this.btnCategory);
        this.Controls.Add(this.btnSupplier);
        this.Controls.Add(this.btnCustomer);
        this.Controls.Add(this.btnProduct);
        this.Controls.Add(this.lblTrans);
        this.Controls.Add(this.btnKasir);
        this.Controls.Add(this.btnPembelian);
        this.Controls.Add(this.btnHutang);
        this.Controls.Add(this.btnOpname);
        this.Controls.Add(this.btnLedger);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "POS - Menu Utama";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}

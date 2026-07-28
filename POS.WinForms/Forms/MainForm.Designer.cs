namespace POS.WinForms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblUser;
    private System.Windows.Forms.Button btnLogout;
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
    private System.Windows.Forms.Button btnUsers;
    private System.Windows.Forms.Button btnLaporan;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.lblUser = new System.Windows.Forms.Label();
        this.btnLogout = new System.Windows.Forms.Button();
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
        this.btnUsers = new System.Windows.Forms.Button();
        this.btnLaporan = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // lblUser
        //
        this.lblUser.AutoSize = true;
        this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
        this.lblUser.ForeColor = System.Drawing.Color.DimGray;
        this.lblUser.Location = new System.Drawing.Point(40, 15);
        this.lblUser.Text = "Login: -";
        //
        // btnLogout
        //
        this.btnLogout.Location = new System.Drawing.Point(380, 10);
        this.btnLogout.Size = new System.Drawing.Size(100, 28);
        this.btnLogout.TabIndex = 20;
        this.btnLogout.Text = "Logout";
        this.btnLogout.UseVisualStyleBackColor = true;
        this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
        //
        // lblMaster
        //
        this.lblMaster.AutoSize = true;
        this.lblMaster.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblMaster.Location = new System.Drawing.Point(40, 55);
        this.lblMaster.Text = "Master Data";
        //
        // btnCategory
        //
        this.btnCategory.Location = new System.Drawing.Point(40, 85);
        this.btnCategory.Size = new System.Drawing.Size(200, 45);
        this.btnCategory.TabIndex = 0;
        this.btnCategory.Text = "Kelola Kategori";
        this.btnCategory.UseVisualStyleBackColor = true;
        this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
        //
        // btnSupplier
        //
        this.btnSupplier.Location = new System.Drawing.Point(40, 140);
        this.btnSupplier.Size = new System.Drawing.Size(200, 45);
        this.btnSupplier.TabIndex = 1;
        this.btnSupplier.Text = "Kelola Supplier";
        this.btnSupplier.UseVisualStyleBackColor = true;
        this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
        //
        // btnCustomer
        //
        this.btnCustomer.Location = new System.Drawing.Point(40, 195);
        this.btnCustomer.Size = new System.Drawing.Size(200, 45);
        this.btnCustomer.TabIndex = 2;
        this.btnCustomer.Text = "Kelola Customer";
        this.btnCustomer.UseVisualStyleBackColor = true;
        this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
        //
        // btnProduct
        //
        this.btnProduct.Location = new System.Drawing.Point(40, 250);
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
        this.lblTrans.Location = new System.Drawing.Point(280, 55);
        this.lblTrans.Text = "Transaksi & Stok";
        //
        // btnKasir
        //
        this.btnKasir.Location = new System.Drawing.Point(280, 85);
        this.btnKasir.Size = new System.Drawing.Size(200, 45);
        this.btnKasir.TabIndex = 4;
        this.btnKasir.Text = "Kasir (Penjualan)";
        this.btnKasir.UseVisualStyleBackColor = true;
        this.btnKasir.Click += new System.EventHandler(this.btnKasir_Click);
        //
        // btnPembelian
        //
        this.btnPembelian.Location = new System.Drawing.Point(280, 140);
        this.btnPembelian.Size = new System.Drawing.Size(200, 45);
        this.btnPembelian.TabIndex = 5;
        this.btnPembelian.Text = "Pembelian";
        this.btnPembelian.UseVisualStyleBackColor = true;
        this.btnPembelian.Click += new System.EventHandler(this.btnPembelian_Click);
        //
        // btnHutang
        //
        this.btnHutang.Location = new System.Drawing.Point(280, 195);
        this.btnHutang.Size = new System.Drawing.Size(200, 45);
        this.btnHutang.TabIndex = 6;
        this.btnHutang.Text = "Pembayaran Hutang";
        this.btnHutang.UseVisualStyleBackColor = true;
        this.btnHutang.Click += new System.EventHandler(this.btnHutang_Click);
        //
        // btnOpname
        //
        this.btnOpname.Location = new System.Drawing.Point(280, 250);
        this.btnOpname.Size = new System.Drawing.Size(200, 45);
        this.btnOpname.TabIndex = 7;
        this.btnOpname.Text = "Stock Opname";
        this.btnOpname.UseVisualStyleBackColor = true;
        this.btnOpname.Click += new System.EventHandler(this.btnOpname_Click);
        //
        // btnLedger
        //
        this.btnLedger.Location = new System.Drawing.Point(280, 305);
        this.btnLedger.Size = new System.Drawing.Size(200, 45);
        this.btnLedger.TabIndex = 8;
        this.btnLedger.Text = "Stock Ledger";
        this.btnLedger.UseVisualStyleBackColor = true;
        this.btnLedger.Click += new System.EventHandler(this.btnLedger_Click);
        //
        // btnUsers
        //
        this.btnUsers.Location = new System.Drawing.Point(40, 305);
        this.btnUsers.Size = new System.Drawing.Size(200, 45);
        this.btnUsers.TabIndex = 9;
        this.btnUsers.Text = "Kelola User";
        this.btnUsers.UseVisualStyleBackColor = true;
        this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
        //
        // btnLaporan
        //
        this.btnLaporan.Location = new System.Drawing.Point(40, 365);
        this.btnLaporan.Size = new System.Drawing.Size(440, 45);
        this.btnLaporan.TabIndex = 10;
        this.btnLaporan.Text = "Laporan";
        this.btnLaporan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnLaporan.UseVisualStyleBackColor = true;
        this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(520, 435);
        this.Controls.Add(this.lblUser);
        this.Controls.Add(this.btnLogout);
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
        this.Controls.Add(this.btnUsers);
        this.Controls.Add(this.btnLaporan);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "POS - Menu Utama";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}

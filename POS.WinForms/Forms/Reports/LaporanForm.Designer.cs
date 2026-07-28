namespace POS.WinForms.Forms.Reports;

partial class LaporanForm
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
        this.tabControl = new System.Windows.Forms.TabControl();
        this.tabSales = new System.Windows.Forms.TabPage();
        this.tabPurchase = new System.Windows.Forms.TabPage();
        this.tabDebt = new System.Windows.Forms.TabPage();
        this.tabInventory = new System.Windows.Forms.TabPage();

        this.dgvSales = new System.Windows.Forms.DataGridView();
        this.colSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSCogs = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlSalesTop = new System.Windows.Forms.Panel();
        this.lblSalesFrom = new System.Windows.Forms.Label();
        this.dtpSalesFrom = new System.Windows.Forms.DateTimePicker();
        this.lblSalesTo = new System.Windows.Forms.Label();
        this.dtpSalesTo = new System.Windows.Forms.DateTimePicker();
        this.btnSalesShow = new System.Windows.Forms.Button();
        this.lblSalesSummary = new System.Windows.Forms.Label();

        this.dgvPurchase = new System.Windows.Forms.DataGridView();
        this.colPSup = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlPurchaseTop = new System.Windows.Forms.Panel();
        this.lblPurchaseFrom = new System.Windows.Forms.Label();
        this.dtpPurchaseFrom = new System.Windows.Forms.DateTimePicker();
        this.lblPurchaseTo = new System.Windows.Forms.Label();
        this.dtpPurchaseTo = new System.Windows.Forms.DateTimePicker();
        this.btnPurchaseShow = new System.Windows.Forms.Button();
        this.lblPurchaseTotal = new System.Windows.Forms.Label();

        this.dgvDebt = new System.Windows.Forms.DataGridView();
        this.colDSup = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colDOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlDebtTop = new System.Windows.Forms.Panel();
        this.btnDebtRefresh = new System.Windows.Forms.Button();
        this.lblDebtTotal = new System.Windows.Forms.Label();

        this.dgvInventory = new System.Windows.Forms.DataGridView();
        this.colIName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colIStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colIAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colIValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlInvTop = new System.Windows.Forms.Panel();
        this.btnInventoryRefresh = new System.Windows.Forms.Button();
        this.lblInventoryTotal = new System.Windows.Forms.Label();

        ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDebt)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
        this.tabControl.SuspendLayout();
        this.tabSales.SuspendLayout();
        this.tabPurchase.SuspendLayout();
        this.tabDebt.SuspendLayout();
        this.tabInventory.SuspendLayout();
        this.pnlSalesTop.SuspendLayout();
        this.pnlPurchaseTop.SuspendLayout();
        this.pnlDebtTop.SuspendLayout();
        this.pnlInvTop.SuspendLayout();
        this.SuspendLayout();
        //
        // tabControl
        //
        this.tabControl.Controls.Add(this.tabSales);
        this.tabControl.Controls.Add(this.tabPurchase);
        this.tabControl.Controls.Add(this.tabDebt);
        this.tabControl.Controls.Add(this.tabInventory);
        this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControl.Name = "tabControl";
        this.tabControl.TabIndex = 0;
        //
        // tabSales
        //
        this.tabSales.Controls.Add(this.dgvSales);
        this.tabSales.Controls.Add(this.pnlSalesTop);
        this.tabSales.Name = "tabSales";
        this.tabSales.Padding = new System.Windows.Forms.Padding(3);
        this.tabSales.Text = "Penjualan & Laba";
        this.tabSales.UseVisualStyleBackColor = true;
        //
        // dgvSales
        //
        this.dgvSales.AllowUserToAddRows = false;
        this.dgvSales.AllowUserToDeleteRows = false;
        this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSName, this.colSQty, this.colSRev, this.colSCogs, this.colSProfit });
        this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvSales.Name = "dgvSales";
        this.dgvSales.ReadOnly = true;
        this.dgvSales.RowHeadersVisible = false;
        this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvSales.TabIndex = 1;
        this.colSName.DataPropertyName = "ProductName";
        this.colSName.HeaderText = "Produk";
        this.colSName.Name = "colSName";
        this.colSName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colSQty.DataPropertyName = "QtySold";
        this.colSQty.HeaderText = "Qty Terjual";
        this.colSQty.Name = "colSQty";
        this.colSQty.Width = 90;
        this.colSRev.DataPropertyName = "Revenue";
        this.colSRev.HeaderText = "Omzet";
        this.colSRev.Name = "colSRev";
        this.colSRev.Width = 110;
        this.colSRev.DefaultCellStyle.Format = "N0";
        this.colSCogs.DataPropertyName = "Cogs";
        this.colSCogs.HeaderText = "HPP";
        this.colSCogs.Name = "colSCogs";
        this.colSCogs.Width = 110;
        this.colSCogs.DefaultCellStyle.Format = "N0";
        this.colSProfit.DataPropertyName = "GrossProfit";
        this.colSProfit.HeaderText = "Laba Kotor";
        this.colSProfit.Name = "colSProfit";
        this.colSProfit.Width = 110;
        this.colSProfit.DefaultCellStyle.Format = "N0";
        //
        // pnlSalesTop
        //
        this.pnlSalesTop.Controls.Add(this.lblSalesFrom);
        this.pnlSalesTop.Controls.Add(this.dtpSalesFrom);
        this.pnlSalesTop.Controls.Add(this.lblSalesTo);
        this.pnlSalesTop.Controls.Add(this.dtpSalesTo);
        this.pnlSalesTop.Controls.Add(this.btnSalesShow);
        this.pnlSalesTop.Controls.Add(this.lblSalesSummary);
        this.pnlSalesTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlSalesTop.Location = new System.Drawing.Point(3, 3);
        this.pnlSalesTop.Name = "pnlSalesTop";
        this.pnlSalesTop.Size = new System.Drawing.Size(780, 75);
        this.pnlSalesTop.TabIndex = 0;
        this.lblSalesFrom.AutoSize = true;
        this.lblSalesFrom.Location = new System.Drawing.Point(10, 12);
        this.lblSalesFrom.Text = "Dari";
        this.dtpSalesFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpSalesFrom.Location = new System.Drawing.Point(50, 9);
        this.dtpSalesFrom.Size = new System.Drawing.Size(120, 23);
        this.dtpSalesFrom.TabIndex = 0;
        this.lblSalesTo.AutoSize = true;
        this.lblSalesTo.Location = new System.Drawing.Point(185, 12);
        this.lblSalesTo.Text = "Sampai";
        this.dtpSalesTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpSalesTo.Location = new System.Drawing.Point(240, 9);
        this.dtpSalesTo.Size = new System.Drawing.Size(120, 23);
        this.dtpSalesTo.TabIndex = 1;
        this.btnSalesShow.Location = new System.Drawing.Point(375, 8);
        this.btnSalesShow.Size = new System.Drawing.Size(110, 26);
        this.btnSalesShow.Text = "Tampilkan";
        this.btnSalesShow.TabIndex = 2;
        this.btnSalesShow.Click += new System.EventHandler(this.btnSalesShow_Click);
        this.lblSalesSummary.AutoSize = true;
        this.lblSalesSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblSalesSummary.Location = new System.Drawing.Point(10, 48);
        this.lblSalesSummary.Text = "Transaksi: 0    |    Omzet: Rp 0    |    HPP: Rp 0    |    Laba Kotor: Rp 0";
        //
        // tabPurchase
        //
        this.tabPurchase.Controls.Add(this.dgvPurchase);
        this.tabPurchase.Controls.Add(this.pnlPurchaseTop);
        this.tabPurchase.Name = "tabPurchase";
        this.tabPurchase.Padding = new System.Windows.Forms.Padding(3);
        this.tabPurchase.Text = "Pembelian";
        this.tabPurchase.UseVisualStyleBackColor = true;
        //
        // dgvPurchase
        //
        this.dgvPurchase.AllowUserToAddRows = false;
        this.dgvPurchase.AllowUserToDeleteRows = false;
        this.dgvPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPSup, this.colPCount, this.colPTotal, this.colPPaid, this.colPOut });
        this.dgvPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvPurchase.Name = "dgvPurchase";
        this.dgvPurchase.ReadOnly = true;
        this.dgvPurchase.RowHeadersVisible = false;
        this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvPurchase.TabIndex = 1;
        this.colPSup.DataPropertyName = "SupplierName";
        this.colPSup.HeaderText = "Supplier";
        this.colPSup.Name = "colPSup";
        this.colPSup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colPCount.DataPropertyName = "PurchaseCount";
        this.colPCount.HeaderText = "Jml Nota";
        this.colPCount.Name = "colPCount";
        this.colPCount.Width = 80;
        this.colPTotal.DataPropertyName = "TotalPurchase";
        this.colPTotal.HeaderText = "Total Beli";
        this.colPTotal.Name = "colPTotal";
        this.colPTotal.Width = 110;
        this.colPTotal.DefaultCellStyle.Format = "N0";
        this.colPPaid.DataPropertyName = "TotalPaid";
        this.colPPaid.HeaderText = "Dibayar";
        this.colPPaid.Name = "colPPaid";
        this.colPPaid.Width = 110;
        this.colPPaid.DefaultCellStyle.Format = "N0";
        this.colPOut.DataPropertyName = "Outstanding";
        this.colPOut.HeaderText = "Sisa";
        this.colPOut.Name = "colPOut";
        this.colPOut.Width = 110;
        this.colPOut.DefaultCellStyle.Format = "N0";
        //
        // pnlPurchaseTop
        //
        this.pnlPurchaseTop.Controls.Add(this.lblPurchaseFrom);
        this.pnlPurchaseTop.Controls.Add(this.dtpPurchaseFrom);
        this.pnlPurchaseTop.Controls.Add(this.lblPurchaseTo);
        this.pnlPurchaseTop.Controls.Add(this.dtpPurchaseTo);
        this.pnlPurchaseTop.Controls.Add(this.btnPurchaseShow);
        this.pnlPurchaseTop.Controls.Add(this.lblPurchaseTotal);
        this.pnlPurchaseTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlPurchaseTop.Location = new System.Drawing.Point(3, 3);
        this.pnlPurchaseTop.Name = "pnlPurchaseTop";
        this.pnlPurchaseTop.Size = new System.Drawing.Size(780, 75);
        this.pnlPurchaseTop.TabIndex = 0;
        this.lblPurchaseFrom.AutoSize = true;
        this.lblPurchaseFrom.Location = new System.Drawing.Point(10, 12);
        this.lblPurchaseFrom.Text = "Dari";
        this.dtpPurchaseFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpPurchaseFrom.Location = new System.Drawing.Point(50, 9);
        this.dtpPurchaseFrom.Size = new System.Drawing.Size(120, 23);
        this.dtpPurchaseFrom.TabIndex = 0;
        this.lblPurchaseTo.AutoSize = true;
        this.lblPurchaseTo.Location = new System.Drawing.Point(185, 12);
        this.lblPurchaseTo.Text = "Sampai";
        this.dtpPurchaseTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpPurchaseTo.Location = new System.Drawing.Point(240, 9);
        this.dtpPurchaseTo.Size = new System.Drawing.Size(120, 23);
        this.dtpPurchaseTo.TabIndex = 1;
        this.btnPurchaseShow.Location = new System.Drawing.Point(375, 8);
        this.btnPurchaseShow.Size = new System.Drawing.Size(110, 26);
        this.btnPurchaseShow.Text = "Tampilkan";
        this.btnPurchaseShow.TabIndex = 2;
        this.btnPurchaseShow.Click += new System.EventHandler(this.btnPurchaseShow_Click);
        this.lblPurchaseTotal.AutoSize = true;
        this.lblPurchaseTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblPurchaseTotal.Location = new System.Drawing.Point(10, 48);
        this.lblPurchaseTotal.Text = "Total Pembelian: Rp 0    |    Sisa Belum Dibayar: Rp 0";
        //
        // tabDebt
        //
        this.tabDebt.Controls.Add(this.dgvDebt);
        this.tabDebt.Controls.Add(this.pnlDebtTop);
        this.tabDebt.Name = "tabDebt";
        this.tabDebt.Padding = new System.Windows.Forms.Padding(3);
        this.tabDebt.Text = "Hutang Supplier";
        this.tabDebt.UseVisualStyleBackColor = true;
        //
        // dgvDebt
        //
        this.dgvDebt.AllowUserToAddRows = false;
        this.dgvDebt.AllowUserToDeleteRows = false;
        this.dgvDebt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDSup, this.colDOut });
        this.dgvDebt.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvDebt.Name = "dgvDebt";
        this.dgvDebt.ReadOnly = true;
        this.dgvDebt.RowHeadersVisible = false;
        this.dgvDebt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvDebt.TabIndex = 1;
        this.colDSup.DataPropertyName = "SupplierName";
        this.colDSup.HeaderText = "Supplier";
        this.colDSup.Name = "colDSup";
        this.colDSup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colDOut.DataPropertyName = "Outstanding";
        this.colDOut.HeaderText = "Hutang";
        this.colDOut.Name = "colDOut";
        this.colDOut.Width = 150;
        this.colDOut.DefaultCellStyle.Format = "N0";
        //
        // pnlDebtTop
        //
        this.pnlDebtTop.Controls.Add(this.btnDebtRefresh);
        this.pnlDebtTop.Controls.Add(this.lblDebtTotal);
        this.pnlDebtTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlDebtTop.Location = new System.Drawing.Point(3, 3);
        this.pnlDebtTop.Name = "pnlDebtTop";
        this.pnlDebtTop.Size = new System.Drawing.Size(780, 55);
        this.pnlDebtTop.TabIndex = 0;
        this.btnDebtRefresh.Location = new System.Drawing.Point(10, 12);
        this.btnDebtRefresh.Size = new System.Drawing.Size(110, 28);
        this.btnDebtRefresh.Text = "Muat Ulang";
        this.btnDebtRefresh.TabIndex = 0;
        this.btnDebtRefresh.Click += new System.EventHandler(this.btnDebtRefresh_Click);
        this.lblDebtTotal.AutoSize = true;
        this.lblDebtTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblDebtTotal.ForeColor = System.Drawing.Color.Firebrick;
        this.lblDebtTotal.Location = new System.Drawing.Point(140, 18);
        this.lblDebtTotal.Text = "Total Hutang Berjalan: Rp 0";
        //
        // tabInventory
        //
        this.tabInventory.Controls.Add(this.dgvInventory);
        this.tabInventory.Controls.Add(this.pnlInvTop);
        this.tabInventory.Name = "tabInventory";
        this.tabInventory.Padding = new System.Windows.Forms.Padding(3);
        this.tabInventory.Text = "Nilai Persediaan";
        this.tabInventory.UseVisualStyleBackColor = true;
        //
        // dgvInventory
        //
        this.dgvInventory.AllowUserToAddRows = false;
        this.dgvInventory.AllowUserToDeleteRows = false;
        this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIName, this.colIStock, this.colIAvg, this.colIValue });
        this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvInventory.Name = "dgvInventory";
        this.dgvInventory.ReadOnly = true;
        this.dgvInventory.RowHeadersVisible = false;
        this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvInventory.TabIndex = 1;
        this.colIName.DataPropertyName = "ProductName";
        this.colIName.HeaderText = "Produk";
        this.colIName.Name = "colIName";
        this.colIName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colIStock.DataPropertyName = "Stock";
        this.colIStock.HeaderText = "Stok";
        this.colIStock.Name = "colIStock";
        this.colIStock.Width = 90;
        this.colIAvg.DataPropertyName = "AverageCost";
        this.colIAvg.HeaderText = "HPP/Unit";
        this.colIAvg.Name = "colIAvg";
        this.colIAvg.Width = 120;
        this.colIAvg.DefaultCellStyle.Format = "N2";
        this.colIValue.DataPropertyName = "Value";
        this.colIValue.HeaderText = "Nilai";
        this.colIValue.Name = "colIValue";
        this.colIValue.Width = 140;
        this.colIValue.DefaultCellStyle.Format = "N2";
        //
        // pnlInvTop
        //
        this.pnlInvTop.Controls.Add(this.btnInventoryRefresh);
        this.pnlInvTop.Controls.Add(this.lblInventoryTotal);
        this.pnlInvTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlInvTop.Location = new System.Drawing.Point(3, 3);
        this.pnlInvTop.Name = "pnlInvTop";
        this.pnlInvTop.Size = new System.Drawing.Size(780, 55);
        this.pnlInvTop.TabIndex = 0;
        this.btnInventoryRefresh.Location = new System.Drawing.Point(10, 12);
        this.btnInventoryRefresh.Size = new System.Drawing.Size(110, 28);
        this.btnInventoryRefresh.Text = "Muat Ulang";
        this.btnInventoryRefresh.TabIndex = 0;
        this.btnInventoryRefresh.Click += new System.EventHandler(this.btnInventoryRefresh_Click);
        this.lblInventoryTotal.AutoSize = true;
        this.lblInventoryTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblInventoryTotal.ForeColor = System.Drawing.Color.SeaGreen;
        this.lblInventoryTotal.Location = new System.Drawing.Point(140, 18);
        this.lblInventoryTotal.Text = "Total Nilai Persediaan: Rp 0";
        //
        // LaporanForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 520);
        this.Controls.Add(this.tabControl);
        this.MinimumSize = new System.Drawing.Size(700, 450);
        this.Name = "LaporanForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Laporan";
        this.Load += new System.EventHandler(this.LaporanForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDebt)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
        this.tabControl.ResumeLayout(false);
        this.tabSales.ResumeLayout(false);
        this.tabSales.PerformLayout();
        this.tabPurchase.ResumeLayout(false);
        this.tabPurchase.PerformLayout();
        this.tabDebt.ResumeLayout(false);
        this.tabDebt.PerformLayout();
        this.tabInventory.ResumeLayout(false);
        this.tabInventory.PerformLayout();
        this.pnlSalesTop.ResumeLayout(false);
        this.pnlSalesTop.PerformLayout();
        this.pnlPurchaseTop.ResumeLayout(false);
        this.pnlPurchaseTop.PerformLayout();
        this.pnlDebtTop.ResumeLayout(false);
        this.pnlDebtTop.PerformLayout();
        this.pnlInvTop.ResumeLayout(false);
        this.pnlInvTop.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabSales;
    private System.Windows.Forms.TabPage tabPurchase;
    private System.Windows.Forms.TabPage tabDebt;
    private System.Windows.Forms.TabPage tabInventory;

    private System.Windows.Forms.DataGridView dgvSales;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSQty;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSRev;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSCogs;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSProfit;
    private System.Windows.Forms.Panel pnlSalesTop;
    private System.Windows.Forms.Label lblSalesFrom;
    private System.Windows.Forms.DateTimePicker dtpSalesFrom;
    private System.Windows.Forms.Label lblSalesTo;
    private System.Windows.Forms.DateTimePicker dtpSalesTo;
    private System.Windows.Forms.Button btnSalesShow;
    private System.Windows.Forms.Label lblSalesSummary;

    private System.Windows.Forms.DataGridView dgvPurchase;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPSup;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPCount;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPTotal;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPPaid;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPOut;
    private System.Windows.Forms.Panel pnlPurchaseTop;
    private System.Windows.Forms.Label lblPurchaseFrom;
    private System.Windows.Forms.DateTimePicker dtpPurchaseFrom;
    private System.Windows.Forms.Label lblPurchaseTo;
    private System.Windows.Forms.DateTimePicker dtpPurchaseTo;
    private System.Windows.Forms.Button btnPurchaseShow;
    private System.Windows.Forms.Label lblPurchaseTotal;

    private System.Windows.Forms.DataGridView dgvDebt;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDSup;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDOut;
    private System.Windows.Forms.Panel pnlDebtTop;
    private System.Windows.Forms.Button btnDebtRefresh;
    private System.Windows.Forms.Label lblDebtTotal;

    private System.Windows.Forms.DataGridView dgvInventory;
    private System.Windows.Forms.DataGridViewTextBoxColumn colIName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colIStock;
    private System.Windows.Forms.DataGridViewTextBoxColumn colIAvg;
    private System.Windows.Forms.DataGridViewTextBoxColumn colIValue;
    private System.Windows.Forms.Panel pnlInvTop;
    private System.Windows.Forms.Button btnInventoryRefresh;
    private System.Windows.Forms.Label lblInventoryTotal;
}

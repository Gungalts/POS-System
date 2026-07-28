namespace POS.WinForms.Forms.Purchasing;

partial class PembayaranHutangForm
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
        this.lblDebt = new System.Windows.Forms.Label();
        this.lblDebtValue = new System.Windows.Forms.Label();
        this.dgvUnpaid = new System.Windows.Forms.DataGridView();
        this.colPurchaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlBottom = new System.Windows.Forms.Panel();
        this.lblPayment = new System.Windows.Forms.Label();
        this.numPayment = new System.Windows.Forms.NumericUpDown();
        this.lblNotes = new System.Windows.Forms.Label();
        this.txtNotes = new System.Windows.Forms.TextBox();
        this.btnPay = new System.Windows.Forms.Button();
        this.lblHistory = new System.Windows.Forms.Label();
        this.dgvHistory = new System.Windows.Forms.DataGridView();
        this.colHistDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colHistAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colHistNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaid)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numPayment)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
        this.pnlTop.SuspendLayout();
        this.pnlBottom.SuspendLayout();
        this.SuspendLayout();
        //
        // pnlTop
        //
        this.pnlTop.Controls.Add(this.lblSupplier);
        this.pnlTop.Controls.Add(this.cmbSupplier);
        this.pnlTop.Controls.Add(this.lblDebt);
        this.pnlTop.Controls.Add(this.lblDebtValue);
        this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Size = new System.Drawing.Size(760, 50);
        this.pnlTop.TabIndex = 0;

        this.lblSupplier.AutoSize = true;
        this.lblSupplier.Location = new System.Drawing.Point(12, 16);
        this.lblSupplier.Text = "Supplier";
        this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbSupplier.Location = new System.Drawing.Point(75, 13);
        this.cmbSupplier.Size = new System.Drawing.Size(220, 23);
        this.cmbSupplier.TabIndex = 0;
        this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);

        this.lblDebt.AutoSize = true;
        this.lblDebt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblDebt.Location = new System.Drawing.Point(430, 15);
        this.lblDebt.Text = "Total Hutang:";
        this.lblDebtValue.AutoSize = true;
        this.lblDebtValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblDebtValue.ForeColor = System.Drawing.Color.Firebrick;
        this.lblDebtValue.Location = new System.Drawing.Point(540, 15);
        this.lblDebtValue.Text = "Rp 0";
        //
        // dgvUnpaid
        //
        this.dgvUnpaid.AllowUserToAddRows = false;
        this.dgvUnpaid.AllowUserToDeleteRows = false;
        this.dgvUnpaid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPurchaseId, this.colDate, this.colTotal, this.colPaid, this.colRemaining, this.colStatus });
        this.dgvUnpaid.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvUnpaid.MultiSelect = false;
        this.dgvUnpaid.Name = "dgvUnpaid";
        this.dgvUnpaid.ReadOnly = true;
        this.dgvUnpaid.RowHeadersVisible = false;
        this.dgvUnpaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvUnpaid.TabIndex = 1;
        this.dgvUnpaid.SelectionChanged += new System.EventHandler(this.dgvUnpaid_SelectionChanged);

        this.colPurchaseId.DataPropertyName = "PurchaseId";
        this.colPurchaseId.HeaderText = "No";
        this.colPurchaseId.Name = "colPurchaseId";
        this.colPurchaseId.Width = 50;
        this.colDate.DataPropertyName = "PurchaseDate";
        this.colDate.HeaderText = "Tanggal";
        this.colDate.Name = "colDate";
        this.colDate.Width = 140;
        this.colTotal.DataPropertyName = "GrandTotal";
        this.colTotal.HeaderText = "Total";
        this.colTotal.Name = "colTotal";
        this.colTotal.DefaultCellStyle.Format = "N0";
        this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colPaid.DataPropertyName = "AmountPaid";
        this.colPaid.HeaderText = "Dibayar";
        this.colPaid.Name = "colPaid";
        this.colPaid.DefaultCellStyle.Format = "N0";
        this.colPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colRemaining.DataPropertyName = "Remaining";
        this.colRemaining.HeaderText = "Sisa";
        this.colRemaining.Name = "colRemaining";
        this.colRemaining.DefaultCellStyle.Format = "N0";
        this.colRemaining.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.colStatus.DataPropertyName = "PaymentStatusValue";
        this.colStatus.HeaderText = "Status";
        this.colStatus.Name = "colStatus";
        this.colStatus.Width = 90;
        //
        // pnlBottom
        //
        this.pnlBottom.Controls.Add(this.lblPayment);
        this.pnlBottom.Controls.Add(this.numPayment);
        this.pnlBottom.Controls.Add(this.lblNotes);
        this.pnlBottom.Controls.Add(this.txtNotes);
        this.pnlBottom.Controls.Add(this.btnPay);
        this.pnlBottom.Controls.Add(this.lblHistory);
        this.pnlBottom.Controls.Add(this.dgvHistory);
        this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Size = new System.Drawing.Size(760, 190);
        this.pnlBottom.TabIndex = 2;

        this.lblPayment.AutoSize = true;
        this.lblPayment.Location = new System.Drawing.Point(12, 18);
        this.lblPayment.Text = "Jumlah Bayar";
        this.numPayment.Location = new System.Drawing.Point(110, 15);
        this.numPayment.Size = new System.Drawing.Size(180, 23);
        this.numPayment.Maximum = 1000000000;
        this.numPayment.ThousandsSeparator = true;
        this.numPayment.TabIndex = 0;

        this.lblNotes.AutoSize = true;
        this.lblNotes.Location = new System.Drawing.Point(12, 52);
        this.lblNotes.Text = "Catatan";
        this.txtNotes.Location = new System.Drawing.Point(110, 49);
        this.txtNotes.Size = new System.Drawing.Size(180, 23);
        this.txtNotes.TabIndex = 1;

        this.btnPay.Location = new System.Drawing.Point(110, 90);
        this.btnPay.Size = new System.Drawing.Size(180, 40);
        this.btnPay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnPay.Text = "BAYAR CICILAN";
        this.btnPay.TabIndex = 2;
        this.btnPay.Click += new System.EventHandler(this.btnPay_Click);

        this.lblHistory.AutoSize = true;
        this.lblHistory.Location = new System.Drawing.Point(360, 8);
        this.lblHistory.Text = "Histori Pembayaran";
        this.dgvHistory.AllowUserToAddRows = false;
        this.dgvHistory.AllowUserToDeleteRows = false;
        this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHistDate, this.colHistAmount, this.colHistNotes });
        this.dgvHistory.Location = new System.Drawing.Point(360, 28);
        this.dgvHistory.Size = new System.Drawing.Size(385, 150);
        this.dgvHistory.MultiSelect = false;
        this.dgvHistory.Name = "dgvHistory";
        this.dgvHistory.ReadOnly = true;
        this.dgvHistory.RowHeadersVisible = false;
        this.dgvHistory.TabIndex = 3;

        this.colHistDate.DataPropertyName = "PaymentDate";
        this.colHistDate.HeaderText = "Tanggal";
        this.colHistDate.Name = "colHistDate";
        this.colHistDate.Width = 130;
        this.colHistAmount.DataPropertyName = "Amount";
        this.colHistAmount.HeaderText = "Jumlah";
        this.colHistAmount.Name = "colHistAmount";
        this.colHistAmount.DefaultCellStyle.Format = "N0";
        this.colHistAmount.Width = 110;
        this.colHistNotes.DataPropertyName = "Notes";
        this.colHistNotes.HeaderText = "Catatan";
        this.colHistNotes.Name = "colHistNotes";
        this.colHistNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        //
        // PembayaranHutangForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(760, 520);
        this.Controls.Add(this.dgvUnpaid);
        this.Controls.Add(this.pnlBottom);
        this.Controls.Add(this.pnlTop);
        this.MinimumSize = new System.Drawing.Size(776, 559);
        this.Name = "PembayaranHutangForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Pembayaran Hutang Supplier";
        this.Load += new System.EventHandler(this.PembayaranHutangForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaid)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numPayment)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
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
    private System.Windows.Forms.Label lblDebt;
    private System.Windows.Forms.Label lblDebtValue;
    private System.Windows.Forms.DataGridView dgvUnpaid;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
    private System.Windows.Forms.DataGridViewTextBoxColumn colRemaining;
    private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Label lblPayment;
    private System.Windows.Forms.NumericUpDown numPayment;
    private System.Windows.Forms.Label lblNotes;
    private System.Windows.Forms.TextBox txtNotes;
    private System.Windows.Forms.Button btnPay;
    private System.Windows.Forms.Label lblHistory;
    private System.Windows.Forms.DataGridView dgvHistory;
    private System.Windows.Forms.DataGridViewTextBoxColumn colHistDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colHistAmount;
    private System.Windows.Forms.DataGridViewTextBoxColumn colHistNotes;
}

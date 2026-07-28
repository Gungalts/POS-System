namespace POS.WinForms.Forms.Products;

partial class ProductForm
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
        this.dgvProduct = new System.Windows.Forms.DataGridView();
        this.pnlForm = new System.Windows.Forms.Panel();
        this.lblBarcode = new System.Windows.Forms.Label();
        this.txtBarcode = new System.Windows.Forms.TextBox();
        this.lblName = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.lblCategory = new System.Windows.Forms.Label();
        this.cmbCategory = new System.Windows.Forms.ComboBox();
        this.lblSupplier = new System.Windows.Forms.Label();
        this.cmbSupplier = new System.Windows.Forms.ComboBox();
        this.lblInitialStock = new System.Windows.Forms.Label();
        this.numInitialStock = new System.Windows.Forms.NumericUpDown();
        this.lblSaleUnit = new System.Windows.Forms.Label();
        this.txtSaleUnit = new System.Windows.Forms.TextBox();
        this.lblPurchaseUnit = new System.Windows.Forms.Label();
        this.txtPurchaseUnit = new System.Windows.Forms.TextBox();
        this.lblConversion = new System.Windows.Forms.Label();
        this.numConversion = new System.Windows.Forms.NumericUpDown();
        this.lblSalePrice = new System.Windows.Forms.Label();
        this.numSalePrice = new System.Windows.Forms.NumericUpDown();
        this.lblPurchasePrice = new System.Windows.Forms.Label();
        this.numPurchasePrice = new System.Windows.Forms.NumericUpDown();
        this.lblAvgCostValue = new System.Windows.Forms.Label();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numInitialStock)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numConversion)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
        this.pnlForm.SuspendLayout();
        this.SuspendLayout();
        //
        // dgvProduct
        //
        this.dgvProduct.AllowUserToAddRows = false;
        this.dgvProduct.AllowUserToDeleteRows = false;
        this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvProduct.MultiSelect = false;
        this.dgvProduct.Name = "dgvProduct";
        this.dgvProduct.ReadOnly = true;
        this.dgvProduct.RowHeadersVisible = false;
        this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvProduct.TabIndex = 0;
        this.dgvProduct.SelectionChanged += new System.EventHandler(this.dgvProduct_SelectionChanged);
        //
        // pnlForm
        //
        this.pnlForm.Controls.Add(this.lblBarcode);
        this.pnlForm.Controls.Add(this.txtBarcode);
        this.pnlForm.Controls.Add(this.lblName);
        this.pnlForm.Controls.Add(this.txtName);
        this.pnlForm.Controls.Add(this.lblCategory);
        this.pnlForm.Controls.Add(this.cmbCategory);
        this.pnlForm.Controls.Add(this.lblSupplier);
        this.pnlForm.Controls.Add(this.cmbSupplier);
        this.pnlForm.Controls.Add(this.lblInitialStock);
        this.pnlForm.Controls.Add(this.numInitialStock);
        this.pnlForm.Controls.Add(this.lblSaleUnit);
        this.pnlForm.Controls.Add(this.txtSaleUnit);
        this.pnlForm.Controls.Add(this.lblPurchaseUnit);
        this.pnlForm.Controls.Add(this.txtPurchaseUnit);
        this.pnlForm.Controls.Add(this.lblConversion);
        this.pnlForm.Controls.Add(this.numConversion);
        this.pnlForm.Controls.Add(this.lblSalePrice);
        this.pnlForm.Controls.Add(this.numSalePrice);
        this.pnlForm.Controls.Add(this.lblPurchasePrice);
        this.pnlForm.Controls.Add(this.numPurchasePrice);
        this.pnlForm.Controls.Add(this.lblAvgCostValue);
        this.pnlForm.Controls.Add(this.btnSave);
        this.pnlForm.Controls.Add(this.btnDelete);
        this.pnlForm.Controls.Add(this.btnClear);
        this.pnlForm.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlForm.Name = "pnlForm";
        this.pnlForm.Size = new System.Drawing.Size(700, 240);
        this.pnlForm.TabIndex = 1;
        //
        // left column
        //
        this.lblBarcode.AutoSize = true;
        this.lblBarcode.Location = new System.Drawing.Point(12, 18);
        this.lblBarcode.Text = "Barcode";
        this.txtBarcode.Location = new System.Drawing.Point(110, 15);
        this.txtBarcode.Size = new System.Drawing.Size(190, 23);
        this.txtBarcode.TabIndex = 0;

        this.lblName.AutoSize = true;
        this.lblName.Location = new System.Drawing.Point(12, 48);
        this.lblName.Text = "Nama Produk";
        this.txtName.Location = new System.Drawing.Point(110, 45);
        this.txtName.Size = new System.Drawing.Size(190, 23);
        this.txtName.TabIndex = 1;

        this.lblCategory.AutoSize = true;
        this.lblCategory.Location = new System.Drawing.Point(12, 78);
        this.lblCategory.Text = "Kategori";
        this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbCategory.Location = new System.Drawing.Point(110, 75);
        this.cmbCategory.Size = new System.Drawing.Size(190, 23);
        this.cmbCategory.TabIndex = 2;

        this.lblSupplier.AutoSize = true;
        this.lblSupplier.Location = new System.Drawing.Point(12, 108);
        this.lblSupplier.Text = "Supplier";
        this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbSupplier.Location = new System.Drawing.Point(110, 105);
        this.cmbSupplier.Size = new System.Drawing.Size(190, 23);
        this.cmbSupplier.TabIndex = 3;

        this.lblInitialStock.AutoSize = true;
        this.lblInitialStock.Location = new System.Drawing.Point(12, 138);
        this.lblInitialStock.Text = "Stok Awal";
        this.numInitialStock.Location = new System.Drawing.Point(110, 135);
        this.numInitialStock.Size = new System.Drawing.Size(190, 23);
        this.numInitialStock.Maximum = 1000000;
        this.numInitialStock.TabIndex = 4;
        //
        // right column
        //
        this.lblSaleUnit.AutoSize = true;
        this.lblSaleUnit.Location = new System.Drawing.Point(330, 18);
        this.lblSaleUnit.Text = "Satuan Jual";
        this.txtSaleUnit.Location = new System.Drawing.Point(440, 15);
        this.txtSaleUnit.Size = new System.Drawing.Size(160, 23);
        this.txtSaleUnit.Text = "PCS";
        this.txtSaleUnit.TabIndex = 5;

        this.lblPurchaseUnit.AutoSize = true;
        this.lblPurchaseUnit.Location = new System.Drawing.Point(330, 48);
        this.lblPurchaseUnit.Text = "Satuan Beli";
        this.txtPurchaseUnit.Location = new System.Drawing.Point(440, 45);
        this.txtPurchaseUnit.Size = new System.Drawing.Size(160, 23);
        this.txtPurchaseUnit.Text = "PCS";
        this.txtPurchaseUnit.TabIndex = 6;

        this.lblConversion.AutoSize = true;
        this.lblConversion.Location = new System.Drawing.Point(330, 78);
        this.lblConversion.Text = "Faktor Konversi";
        this.numConversion.Location = new System.Drawing.Point(440, 75);
        this.numConversion.Size = new System.Drawing.Size(160, 23);
        this.numConversion.Minimum = 1;
        this.numConversion.Maximum = 100000;
        this.numConversion.Value = 1;
        this.numConversion.TabIndex = 7;

        this.lblSalePrice.AutoSize = true;
        this.lblSalePrice.Location = new System.Drawing.Point(330, 108);
        this.lblSalePrice.Text = "Harga Jual";
        this.numSalePrice.Location = new System.Drawing.Point(440, 105);
        this.numSalePrice.Size = new System.Drawing.Size(160, 23);
        this.numSalePrice.Maximum = 1000000000;
        this.numSalePrice.ThousandsSeparator = true;
        this.numSalePrice.TabIndex = 8;

        this.lblPurchasePrice.AutoSize = true;
        this.lblPurchasePrice.Location = new System.Drawing.Point(330, 138);
        this.lblPurchasePrice.Text = "Harga Beli";
        this.numPurchasePrice.Location = new System.Drawing.Point(440, 135);
        this.numPurchasePrice.Size = new System.Drawing.Size(160, 23);
        this.numPurchasePrice.Maximum = 1000000000;
        this.numPurchasePrice.ThousandsSeparator = true;
        this.numPurchasePrice.TabIndex = 9;
        //
        // lblAvgCostValue
        //
        this.lblAvgCostValue.AutoSize = true;
        this.lblAvgCostValue.ForeColor = System.Drawing.Color.DimGray;
        this.lblAvgCostValue.Location = new System.Drawing.Point(12, 172);
        this.lblAvgCostValue.Text = "HPP (Average Cost): -";
        //
        // buttons
        //
        this.btnSave.Location = new System.Drawing.Point(330, 195);
        this.btnSave.Size = new System.Drawing.Size(85, 30);
        this.btnSave.Text = "Simpan";
        this.btnSave.TabIndex = 10;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

        this.btnDelete.Location = new System.Drawing.Point(423, 195);
        this.btnDelete.Size = new System.Drawing.Size(85, 30);
        this.btnDelete.Text = "Hapus";
        this.btnDelete.TabIndex = 11;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        this.btnClear.Location = new System.Drawing.Point(516, 195);
        this.btnClear.Size = new System.Drawing.Size(85, 30);
        this.btnClear.Text = "Bersihkan";
        this.btnClear.TabIndex = 12;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
        //
        // ProductForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(700, 520);
        this.Controls.Add(this.dgvProduct);
        this.Controls.Add(this.pnlForm);
        this.MinimumSize = new System.Drawing.Size(716, 559);
        this.Name = "ProductForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Kelola Produk";
        this.Load += new System.EventHandler(this.ProductForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numInitialStock)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numConversion)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
        this.pnlForm.ResumeLayout(false);
        this.pnlForm.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.DataGridView dgvProduct;
    private System.Windows.Forms.Panel pnlForm;
    private System.Windows.Forms.Label lblBarcode;
    private System.Windows.Forms.TextBox txtBarcode;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.ComboBox cmbCategory;
    private System.Windows.Forms.Label lblSupplier;
    private System.Windows.Forms.ComboBox cmbSupplier;
    private System.Windows.Forms.Label lblInitialStock;
    private System.Windows.Forms.NumericUpDown numInitialStock;
    private System.Windows.Forms.Label lblSaleUnit;
    private System.Windows.Forms.TextBox txtSaleUnit;
    private System.Windows.Forms.Label lblPurchaseUnit;
    private System.Windows.Forms.TextBox txtPurchaseUnit;
    private System.Windows.Forms.Label lblConversion;
    private System.Windows.Forms.NumericUpDown numConversion;
    private System.Windows.Forms.Label lblSalePrice;
    private System.Windows.Forms.NumericUpDown numSalePrice;
    private System.Windows.Forms.Label lblPurchasePrice;
    private System.Windows.Forms.NumericUpDown numPurchasePrice;
    private System.Windows.Forms.Label lblAvgCostValue;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnClear;
}

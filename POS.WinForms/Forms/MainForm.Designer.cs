namespace POS.WinForms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Button btnCategory;
    private System.Windows.Forms.Button btnSupplier;
    private System.Windows.Forms.Button btnCustomer;

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
        this.btnCategory = new System.Windows.Forms.Button();
        this.btnSupplier = new System.Windows.Forms.Button();
        this.btnCustomer = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // btnCategory
        //
        this.btnCategory.Location = new System.Drawing.Point(40, 40);
        this.btnCategory.Name = "btnCategory";
        this.btnCategory.Size = new System.Drawing.Size(200, 45);
        this.btnCategory.TabIndex = 0;
        this.btnCategory.Text = "Kelola Kategori";
        this.btnCategory.UseVisualStyleBackColor = true;
        this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
        //
        // btnSupplier
        //
        this.btnSupplier.Location = new System.Drawing.Point(40, 100);
        this.btnSupplier.Name = "btnSupplier";
        this.btnSupplier.Size = new System.Drawing.Size(200, 45);
        this.btnSupplier.TabIndex = 1;
        this.btnSupplier.Text = "Kelola Supplier";
        this.btnSupplier.UseVisualStyleBackColor = true;
        this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
        //
        // btnCustomer
        //
        this.btnCustomer.Location = new System.Drawing.Point(40, 160);
        this.btnCustomer.Name = "btnCustomer";
        this.btnCustomer.Size = new System.Drawing.Size(200, 45);
        this.btnCustomer.TabIndex = 2;
        this.btnCustomer.Text = "Kelola Customer";
        this.btnCustomer.UseVisualStyleBackColor = true;
        this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(280, 250);
        this.Controls.Add(this.btnCustomer);
        this.Controls.Add(this.btnSupplier);
        this.Controls.Add(this.btnCategory);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "POS - Menu Utama";
        this.ResumeLayout(false);
    }

    #endregion
}

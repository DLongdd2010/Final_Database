namespace Databases_ASM1
{
    partial class WarehouseManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbWarehousseManageFeatures = new System.Windows.Forms.GroupBox();
            this.btnManageProduct = new System.Windows.Forms.Button();
            this.gbWarehousseManageFeatures.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbWarehousseManageFeatures
            // 
            this.gbWarehousseManageFeatures.Controls.Add(this.btnManageProduct);
            this.gbWarehousseManageFeatures.Location = new System.Drawing.Point(12, 12);
            this.gbWarehousseManageFeatures.Name = "gbWarehousseManageFeatures";
            this.gbWarehousseManageFeatures.Size = new System.Drawing.Size(534, 362);
            this.gbWarehousseManageFeatures.TabIndex = 0;
            this.gbWarehousseManageFeatures.TabStop = false;
            this.gbWarehousseManageFeatures.Text = "Warehouse manage features";
            // 
            // btnManageProduct
            // 
            this.btnManageProduct.Location = new System.Drawing.Point(38, 39);
            this.btnManageProduct.Name = "btnManageProduct";
            this.btnManageProduct.Size = new System.Drawing.Size(178, 88);
            this.btnManageProduct.TabIndex = 0;
            this.btnManageProduct.Text = "Manage  product";
            this.btnManageProduct.UseVisualStyleBackColor = true;
            this.btnManageProduct.Click += new System.EventHandler(this.btnManageProduct_Click);
            // 
            // WarehouseManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 386);
            this.Controls.Add(this.gbWarehousseManageFeatures);
            this.Name = "WarehouseManagerForm";
            this.Text = "WarehouseManagerForm";
            this.gbWarehousseManageFeatures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbWarehousseManageFeatures;
        private System.Windows.Forms.Button btnManageProduct;
    }
}
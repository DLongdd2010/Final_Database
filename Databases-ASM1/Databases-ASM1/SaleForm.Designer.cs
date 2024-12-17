namespace Databases_ASM1
{
    partial class SaleForm
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
            this.gbSaleFeature = new System.Windows.Forms.GroupBox();
            this.btnManageOrder = new System.Windows.Forms.Button();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.gbSaleFeature.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSaleFeature
            // 
            this.gbSaleFeature.Controls.Add(this.btnManageOrder);
            this.gbSaleFeature.Controls.Add(this.btnManageCustomer);
            this.gbSaleFeature.Location = new System.Drawing.Point(12, 12);
            this.gbSaleFeature.Name = "gbSaleFeature";
            this.gbSaleFeature.Size = new System.Drawing.Size(587, 356);
            this.gbSaleFeature.TabIndex = 0;
            this.gbSaleFeature.TabStop = false;
            this.gbSaleFeature.Text = "Sale Feature";
            // 
            // btnManageOrder
            // 
            this.btnManageOrder.Location = new System.Drawing.Point(370, 62);
            this.btnManageOrder.Name = "btnManageOrder";
            this.btnManageOrder.Size = new System.Drawing.Size(163, 84);
            this.btnManageOrder.TabIndex = 1;
            this.btnManageOrder.Text = "Manage Order";
            this.btnManageOrder.UseVisualStyleBackColor = true;
            this.btnManageOrder.Click += new System.EventHandler(this.btnManageOrder_Click);
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Location = new System.Drawing.Point(67, 63);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(163, 83);
            this.btnManageCustomer.TabIndex = 0;
            this.btnManageCustomer.Text = "Manage Customer";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            this.btnManageCustomer.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 380);
            this.Controls.Add(this.gbSaleFeature);
            this.Name = "SaleForm";
            this.Text = "SaleForm";
            this.gbSaleFeature.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSaleFeature;
        private System.Windows.Forms.Button btnManageOrder;
        private System.Windows.Forms.Button btnManageCustomer;
    }
}
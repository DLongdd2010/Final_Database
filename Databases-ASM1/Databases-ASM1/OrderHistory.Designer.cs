namespace Databases_ASM1
{
    partial class OrderHistory
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
            this.gbParchaseHistory = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.dtgOrderHistory = new System.Windows.Forms.DataGridView();
            this.gbParchaseHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrderHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // gbParchaseHistory
            // 
            this.gbParchaseHistory.Controls.Add(this.btnBack);
            this.gbParchaseHistory.Controls.Add(this.dtgOrderHistory);
            this.gbParchaseHistory.Location = new System.Drawing.Point(12, 12);
            this.gbParchaseHistory.Name = "gbParchaseHistory";
            this.gbParchaseHistory.Size = new System.Drawing.Size(510, 388);
            this.gbParchaseHistory.TabIndex = 0;
            this.gbParchaseHistory.TabStop = false;
            this.gbParchaseHistory.Text = "Purchase History";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(429, 359);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtgOrderHistory
            // 
            this.dtgOrderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOrderHistory.Location = new System.Drawing.Point(6, 19);
            this.dtgOrderHistory.Name = "dtgOrderHistory";
            this.dtgOrderHistory.Size = new System.Drawing.Size(498, 334);
            this.dtgOrderHistory.TabIndex = 0;
            // 
            // OrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 412);
            this.Controls.Add(this.gbParchaseHistory);
            this.Name = "OrderHistory";
            this.Text = "OrderHistory";
            this.Load += new System.EventHandler(this.OrderHistory_Load);
            this.gbParchaseHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrderHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParchaseHistory;
        private System.Windows.Forms.DataGridView dtgOrderHistory;
        private System.Windows.Forms.Button btnBack;
    }
}
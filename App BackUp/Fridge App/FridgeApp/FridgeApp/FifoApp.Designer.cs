namespace FridgeApp
{
    partial class FifoApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FifoApp));
            this.MenuButtonProducts = new System.Windows.Forms.Button();
            this.MenuButtonScan = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.MenuButtonDelete = new System.Windows.Forms.Button();
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuButtonProducts
            // 
            this.MenuButtonProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButtonProducts.FlatAppearance.BorderSize = 0;
            this.MenuButtonProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButtonProducts.ForeColor = System.Drawing.Color.White;
            this.MenuButtonProducts.Location = new System.Drawing.Point(150, 0);
            this.MenuButtonProducts.Margin = new System.Windows.Forms.Padding(0);
            this.MenuButtonProducts.Name = "MenuButtonProducts";
            this.MenuButtonProducts.Size = new System.Drawing.Size(150, 100);
            this.MenuButtonProducts.TabIndex = 1;
            this.MenuButtonProducts.Text = "Producten";
            this.MenuButtonProducts.UseVisualStyleBackColor = true;
            this.MenuButtonProducts.Click += new System.EventHandler(this.MenuButtonProducts_Click);
            // 
            // MenuButtonScan
            // 
            this.MenuButtonScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButtonScan.FlatAppearance.BorderSize = 0;
            this.MenuButtonScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButtonScan.ForeColor = System.Drawing.Color.White;
            this.MenuButtonScan.Location = new System.Drawing.Point(0, 0);
            this.MenuButtonScan.Margin = new System.Windows.Forms.Padding(0);
            this.MenuButtonScan.Name = "MenuButtonScan";
            this.MenuButtonScan.Size = new System.Drawing.Size(150, 100);
            this.MenuButtonScan.TabIndex = 0;
            this.MenuButtonScan.Text = "Scan";
            this.MenuButtonScan.UseVisualStyleBackColor = true;
            this.MenuButtonScan.Click += new System.EventHandler(this.MenuButtonScan_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.MenuPanel.Controls.Add(this.MenuButtonDelete);
            this.MenuPanel.Controls.Add(this.MenuButtonProducts);
            this.MenuPanel.Controls.Add(this.MenuButtonScan);
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(920, 100);
            this.MenuPanel.TabIndex = 1;
            // 
            // MenuButtonDelete
            // 
            this.MenuButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButtonDelete.FlatAppearance.BorderSize = 0;
            this.MenuButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButtonDelete.ForeColor = System.Drawing.Color.White;
            this.MenuButtonDelete.Location = new System.Drawing.Point(300, 0);
            this.MenuButtonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.MenuButtonDelete.Name = "MenuButtonDelete";
            this.MenuButtonDelete.Size = new System.Drawing.Size(150, 100);
            this.MenuButtonDelete.TabIndex = 2;
            this.MenuButtonDelete.Text = "Delete";
            this.MenuButtonDelete.UseVisualStyleBackColor = true;
            this.MenuButtonDelete.Visible = false;
            this.MenuButtonDelete.Click += new System.EventHandler(this.MenuButtonDelete_Click);
            // 
            // ViewPanel
            // 
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewPanel.Location = new System.Drawing.Point(0, 0);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(920, 578);
            this.ViewPanel.TabIndex = 2;
            // 
            // FifoApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 578);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.ViewPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FifoApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FifoApp";
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button MenuButtonScan;
        private System.Windows.Forms.Button MenuButtonProducts;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel ViewPanel;
        public System.Windows.Forms.Button MenuButtonDelete;
    }
}
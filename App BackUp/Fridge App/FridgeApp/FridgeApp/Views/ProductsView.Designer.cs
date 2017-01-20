namespace FridgeApp.Views
{
    partial class ProductsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanelProducts = new System.Windows.Forms.Panel();
            this.GridViewProducts = new System.Windows.Forms.DataGridView();
            this.MainPanelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanelProducts
            // 
            this.MainPanelProducts.Controls.Add(this.GridViewProducts);
            this.MainPanelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanelProducts.Location = new System.Drawing.Point(0, 0);
            this.MainPanelProducts.Name = "MainPanelProducts";
            this.MainPanelProducts.Size = new System.Drawing.Size(727, 403);
            this.MainPanelProducts.TabIndex = 2;
            // 
            // GridViewProducts
            // 
            this.GridViewProducts.AllowUserToAddRows = false;
            this.GridViewProducts.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewProducts.Location = new System.Drawing.Point(0, 0);
            this.GridViewProducts.Name = "GridViewProducts";
            this.GridViewProducts.ReadOnly = true;
            this.GridViewProducts.Size = new System.Drawing.Size(727, 403);
            this.GridViewProducts.TabIndex = 0;
            this.GridViewProducts.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.GridViewProducts_UserDeletingRow);
            // 
            // ProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanelProducts);
            this.Name = "ProductsView";
            this.Size = new System.Drawing.Size(727, 403);
            this.MainPanelProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanelProducts;
        private System.Windows.Forms.DataGridView GridViewProducts;
    }
}

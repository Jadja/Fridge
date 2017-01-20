namespace FridgeApp.Views
{
    partial class ScanView
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
            this.ShowAddForm = new System.Windows.Forms.Panel();
            this.TextBoxScan = new System.Windows.Forms.TextBox();
            this.ViewExistingProduct = new System.Windows.Forms.Panel();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.CheckDirectAdd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ShowAddForm
            // 
            this.ShowAddForm.Location = new System.Drawing.Point(366, 122);
            this.ShowAddForm.Name = "ShowAddForm";
            this.ShowAddForm.Size = new System.Drawing.Size(373, 100);
            this.ShowAddForm.TabIndex = 0;
            // 
            // TextBoxScan
            // 
            this.TextBoxScan.Location = new System.Drawing.Point(88, 19);
            this.TextBoxScan.Name = "TextBoxScan";
            this.TextBoxScan.Size = new System.Drawing.Size(168, 20);
            this.TextBoxScan.TabIndex = 1;
            this.TextBoxScan.TextChanged += new System.EventHandler(this.TextBoxScan_TextChanged);
            // 
            // ViewExistingProduct
            // 
            this.ViewExistingProduct.Location = new System.Drawing.Point(366, 228);
            this.ViewExistingProduct.Name = "ViewExistingProduct";
            this.ViewExistingProduct.Size = new System.Drawing.Size(373, 100);
            this.ViewExistingProduct.TabIndex = 1;
            // 
            // LogoPanel
            // 
            this.LogoPanel.Location = new System.Drawing.Point(366, 16);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(373, 100);
            this.LogoPanel.TabIndex = 1;
            // 
            // CheckDirectAdd
            // 
            this.CheckDirectAdd.AutoSize = true;
            this.CheckDirectAdd.Location = new System.Drawing.Point(88, 46);
            this.CheckDirectAdd.Name = "CheckDirectAdd";
            this.CheckDirectAdd.Size = new System.Drawing.Size(230, 17);
            this.CheckDirectAdd.TabIndex = 2;
            this.CheckDirectAdd.Text = "Direct toevoegen als het product al bestaat";
            this.CheckDirectAdd.UseVisualStyleBackColor = true;
            this.CheckDirectAdd.CheckedChanged += new System.EventHandler(this.CheckDirectAdd_CheckedChanged);
            // 
            // ScanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckDirectAdd);
            this.Controls.Add(this.LogoPanel);
            this.Controls.Add(this.ViewExistingProduct);
            this.Controls.Add(this.TextBoxScan);
            this.Controls.Add(this.ShowAddForm);
            this.Name = "ScanView";
            this.Size = new System.Drawing.Size(742, 409);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ShowAddForm;
        private System.Windows.Forms.TextBox TextBoxScan;
        private System.Windows.Forms.Panel ViewExistingProduct;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.CheckBox CheckDirectAdd;
    }
}

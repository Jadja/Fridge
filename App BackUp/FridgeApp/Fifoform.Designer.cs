namespace FridgeApp
{
    partial class Fifoform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fifoform));
            this.scanbtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.barcodetxt = new System.Windows.Forms.TextBox();
            this.barcodelbl = new System.Windows.Forms.Label();
            this.testbtn = new System.Windows.Forms.Button();
            this.stopbtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scanmenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.fridgemenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentlist = new System.Windows.Forms.ListView();
            this.pname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pcategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exp_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.daycount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deletebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanbtn
            // 
            this.scanbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scanbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.scanbtn.Font = new System.Drawing.Font("Yu Mincho Demibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanbtn.Location = new System.Drawing.Point(84, 121);
            this.scanbtn.Name = "scanbtn";
            this.scanbtn.Size = new System.Drawing.Size(298, 104);
            this.scanbtn.TabIndex = 0;
            this.scanbtn.Text = "Start scanning";
            this.scanbtn.UseVisualStyleBackColor = true;
            this.scanbtn.Click += new System.EventHandler(this.scanbtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbtn.Enabled = false;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelbtn.Font = new System.Drawing.Font("Yu Mincho Demibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.Location = new System.Drawing.Point(31, 291);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(184, 89);
            this.cancelbtn.TabIndex = 1;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exitbtn.Font = new System.Drawing.Font("Yu Mincho Demibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.Location = new System.Drawing.Point(244, 291);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(184, 89);
            this.exitbtn.TabIndex = 2;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // barcodetxt
            // 
            this.barcodetxt.Font = new System.Drawing.Font("Yu Mincho", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodetxt.Location = new System.Drawing.Point(84, 164);
            this.barcodetxt.Name = "barcodetxt";
            this.barcodetxt.ReadOnly = true;
            this.barcodetxt.Size = new System.Drawing.Size(298, 28);
            this.barcodetxt.TabIndex = 3;
            this.barcodetxt.Visible = false;
            this.barcodetxt.TextChanged += new System.EventHandler(this.barcodetxt_TextChanged);
            // 
            // barcodelbl
            // 
            this.barcodelbl.AutoSize = true;
            this.barcodelbl.Font = new System.Drawing.Font("Yu Mincho", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodelbl.Location = new System.Drawing.Point(81, 145);
            this.barcodelbl.Name = "barcodelbl";
            this.barcodelbl.Size = new System.Drawing.Size(143, 16);
            this.barcodelbl.TabIndex = 4;
            this.barcodelbl.Text = "Barcode will appear here:";
            this.barcodelbl.Visible = false;
            // 
            // testbtn
            // 
            this.testbtn.Location = new System.Drawing.Point(54, 248);
            this.testbtn.Name = "testbtn";
            this.testbtn.Size = new System.Drawing.Size(121, 23);
            this.testbtn.TabIndex = 5;
            this.testbtn.Text = "Random Test Number";
            this.testbtn.UseVisualStyleBackColor = true;
            this.testbtn.Click += new System.EventHandler(this.testbtn_Click);
            // 
            // stopbtn
            // 
            this.stopbtn.Font = new System.Drawing.Font("Yu Mincho", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopbtn.Location = new System.Drawing.Point(163, 73);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(121, 30);
            this.stopbtn.TabIndex = 6;
            this.stopbtn.Text = "Stop scanning";
            this.stopbtn.UseVisualStyleBackColor = true;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanmenuitem,
            this.fridgemenuitem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(462, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // scanmenuitem
            // 
            this.scanmenuitem.Name = "scanmenuitem";
            this.scanmenuitem.Size = new System.Drawing.Size(94, 20);
            this.scanmenuitem.Text = "Scan Products";
            this.scanmenuitem.Click += new System.EventHandler(this.scanmenuitem_Click);
            // 
            // fridgemenuitem
            // 
            this.fridgemenuitem.Name = "fridgemenuitem";
            this.fridgemenuitem.Size = new System.Drawing.Size(98, 20);
            this.fridgemenuitem.Text = "Fridge Content";
            this.fridgemenuitem.Click += new System.EventHandler(this.fridgemenuitem_Click);
            // 
            // contentlist
            // 
            this.contentlist.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.contentlist.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.contentlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentlist.CheckBoxes = true;
            this.contentlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pname,
            this.pcategory,
            this.exp_date,
            this.daycount});
            this.contentlist.FullRowSelect = true;
            this.contentlist.GridLines = true;
            this.contentlist.HoverSelection = true;
            this.contentlist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contentlist.Location = new System.Drawing.Point(12, 43);
            this.contentlist.Name = "contentlist";
            this.contentlist.Size = new System.Drawing.Size(438, 372);
            this.contentlist.TabIndex = 8;
            this.contentlist.UseCompatibleStateImageBehavior = false;
            this.contentlist.View = System.Windows.Forms.View.Details;
            this.contentlist.Visible = false;
            // 
            // pname
            // 
            this.pname.Text = "Product Name";
            this.pname.Width = 125;
            // 
            // pcategory
            // 
            this.pcategory.Text = "Category";
            this.pcategory.Width = 96;
            // 
            // exp_date
            // 
            this.exp_date.Text = "Expiration Date";
            this.exp_date.Width = 131;
            // 
            // daycount
            // 
            this.daycount.Text = "Days in fridge";
            this.daycount.Width = 76;
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(142, 421);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(167, 31);
            this.deletebtn.TabIndex = 9;
            this.deletebtn.Text = "Delete selected";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Visible = false;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(249, 240);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(133, 31);
            this.addbtn.TabIndex = 10;
            this.addbtn.Text = "Add product manually";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // Fifoform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CancelButton = this.cancelbtn;
            this.ClientSize = new System.Drawing.Size(462, 474);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.contentlist);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.testbtn);
            this.Controls.Add(this.barcodelbl);
            this.Controls.Add(this.barcodetxt);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.scanbtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Fifoform";
            this.Text = "Fifo ScanApp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanbtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.TextBox barcodetxt;
        private System.Windows.Forms.Label barcodelbl;
        private System.Windows.Forms.Button testbtn;
        private System.Windows.Forms.Button stopbtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem scanmenuitem;
        private System.Windows.Forms.ToolStripMenuItem fridgemenuitem;
        private System.Windows.Forms.ColumnHeader pname;
        private System.Windows.Forms.ColumnHeader pcategory;
        private System.Windows.Forms.ColumnHeader exp_date;
        private System.Windows.Forms.ColumnHeader daycount;
        private System.Windows.Forms.ListView contentlist;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button addbtn;
    }
}
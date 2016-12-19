namespace FridgeApp
{
    partial class Addingform
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
            this.barcodelbl = new System.Windows.Forms.Label();
            this.namelbl = new System.Windows.Forms.Label();
            this.explbl = new System.Windows.Forms.Label();
            this.desclbl = new System.Windows.Forms.Label();
            this.catlbl = new System.Windows.Forms.Label();
            this.barcodetxt = new System.Windows.Forms.TextBox();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.desctxt = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.cattxt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.starlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exptxt1 = new System.Windows.Forms.ComboBox();
            this.exptxt2 = new System.Windows.Forms.ComboBox();
            this.exptxt3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // barcodelbl
            // 
            this.barcodelbl.AutoSize = true;
            this.barcodelbl.Font = new System.Drawing.Font("Yu Mincho", 9F);
            this.barcodelbl.Location = new System.Drawing.Point(29, 36);
            this.barcodelbl.Name = "barcodelbl";
            this.barcodelbl.Size = new System.Drawing.Size(52, 16);
            this.barcodelbl.TabIndex = 0;
            this.barcodelbl.Text = "Barcode";
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Font = new System.Drawing.Font("Yu Mincho", 9F);
            this.namelbl.Location = new System.Drawing.Point(29, 82);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(40, 16);
            this.namelbl.TabIndex = 1;
            this.namelbl.Text = "Name";
            // 
            // explbl
            // 
            this.explbl.AutoSize = true;
            this.explbl.Font = new System.Drawing.Font("Yu Mincho", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.explbl.Location = new System.Drawing.Point(29, 126);
            this.explbl.Name = "explbl";
            this.explbl.Size = new System.Drawing.Size(89, 16);
            this.explbl.TabIndex = 2;
            this.explbl.Text = "Expiration time";
            // 
            // desclbl
            // 
            this.desclbl.AutoSize = true;
            this.desclbl.Font = new System.Drawing.Font("Yu Mincho", 9F);
            this.desclbl.Location = new System.Drawing.Point(29, 162);
            this.desclbl.Name = "desclbl";
            this.desclbl.Size = new System.Drawing.Size(70, 16);
            this.desclbl.TabIndex = 3;
            this.desclbl.Text = "Description";
            // 
            // catlbl
            // 
            this.catlbl.AutoSize = true;
            this.catlbl.Font = new System.Drawing.Font("Yu Mincho", 9F);
            this.catlbl.Location = new System.Drawing.Point(29, 209);
            this.catlbl.Name = "catlbl";
            this.catlbl.Size = new System.Drawing.Size(56, 16);
            this.catlbl.TabIndex = 4;
            this.catlbl.Text = "Category";
            // 
            // barcodetxt
            // 
            this.barcodetxt.Location = new System.Drawing.Point(147, 32);
            this.barcodetxt.MaxLength = 15;
            this.barcodetxt.Name = "barcodetxt";
            this.barcodetxt.Size = new System.Drawing.Size(153, 20);
            this.barcodetxt.TabIndex = 5;
            this.barcodetxt.TextChanged += new System.EventHandler(this.barcodetxt_TextChanged);
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(147, 78);
            this.nametxt.MaxLength = 100;
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(153, 20);
            this.nametxt.TabIndex = 6;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // desctxt
            // 
            this.desctxt.Location = new System.Drawing.Point(147, 163);
            this.desctxt.MaxLength = 100;
            this.desctxt.Name = "desctxt";
            this.desctxt.Size = new System.Drawing.Size(153, 20);
            this.desctxt.TabIndex = 8;
            this.desctxt.TextChanged += new System.EventHandler(this.desctxt_TextChanged);
            // 
            // addbtn
            // 
            this.addbtn.Font = new System.Drawing.Font("Yu Mincho", 9F);
            this.addbtn.Location = new System.Drawing.Point(32, 255);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(104, 34);
            this.addbtn.TabIndex = 10;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Font = new System.Drawing.Font("Yu Mincho", 9F);
            this.cancelbtn.Location = new System.Drawing.Point(195, 255);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(105, 34);
            this.cancelbtn.TabIndex = 11;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // cattxt
            // 
            this.cattxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cattxt.FormattingEnabled = true;
            this.cattxt.Items.AddRange(new object[] {
            "Drinken",
            "Rood Vlees",
            "Eieren",
            "Zuivel",
            "Gevogelte",
            "Groente",
            "Kant-en-klaar",
            "(Brood)beleg",
            "Vega",
            "Vis",
            "Overige"});
            this.cattxt.Location = new System.Drawing.Point(147, 207);
            this.cattxt.Name = "cattxt";
            this.cattxt.Size = new System.Drawing.Size(153, 21);
            this.cattxt.TabIndex = 12;
            this.cattxt.SelectedIndexChanged += new System.EventHandler(this.cattxt_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "max 15 cijfers";
            // 
            // starlbl
            // 
            this.starlbl.AutoSize = true;
            this.starlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starlbl.Location = new System.Drawing.Point(96, 161);
            this.starlbl.Name = "starlbl";
            this.starlbl.Size = new System.Drawing.Size(12, 15);
            this.starlbl.TabIndex = 14;
            this.starlbl.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "* = optional";
            // 
            // exptxt1
            // 
            this.exptxt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exptxt1.FormattingEnabled = true;
            this.exptxt1.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.exptxt1.Location = new System.Drawing.Point(146, 121);
            this.exptxt1.Name = "exptxt1";
            this.exptxt1.Size = new System.Drawing.Size(43, 21);
            this.exptxt1.TabIndex = 16;
            // 
            // exptxt2
            // 
            this.exptxt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exptxt2.FormattingEnabled = true;
            this.exptxt2.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.exptxt2.Location = new System.Drawing.Point(195, 121);
            this.exptxt2.Name = "exptxt2";
            this.exptxt2.Size = new System.Drawing.Size(43, 21);
            this.exptxt2.TabIndex = 17;
            // 
            // exptxt3
            // 
            this.exptxt3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exptxt3.FormattingEnabled = true;
            this.exptxt3.Items.AddRange(new object[] {
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035"});
            this.exptxt3.Location = new System.Drawing.Point(244, 121);
            this.exptxt3.Name = "exptxt3";
            this.exptxt3.Size = new System.Drawing.Size(56, 21);
            this.exptxt3.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Mincho", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "DD      -    MM   -       YYYY";
            // 
            // Addingform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(331, 335);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exptxt3);
            this.Controls.Add(this.exptxt2);
            this.Controls.Add(this.exptxt1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.starlbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cattxt);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.desctxt);
            this.Controls.Add(this.nametxt);
            this.Controls.Add(this.barcodetxt);
            this.Controls.Add(this.catlbl);
            this.Controls.Add(this.desclbl);
            this.Controls.Add(this.explbl);
            this.Controls.Add(this.namelbl);
            this.Controls.Add(this.barcodelbl);
            this.Name = "Addingform";
            this.Text = "Addingform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label barcodelbl;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Label explbl;
        private System.Windows.Forms.Label desclbl;
        private System.Windows.Forms.Label catlbl;
        private System.Windows.Forms.TextBox barcodetxt;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.TextBox desctxt;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.ComboBox cattxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label starlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox exptxt1;
        private System.Windows.Forms.ComboBox exptxt2;
        private System.Windows.Forms.ComboBox exptxt3;
        private System.Windows.Forms.Label label3;
    }
}
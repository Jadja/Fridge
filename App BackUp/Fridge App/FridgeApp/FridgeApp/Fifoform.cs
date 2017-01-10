using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;

namespace FridgeApp
{
    public partial class Fifoform : Form
    {
        public DatabaseController Database { get; set; }
        public Addingform Adding { get; set; }
        public Fifoform()
        {
            Adding = new Addingform();
            Database = new DatabaseController();
            InitializeComponent();
        }

        private void scanbtn_Click(object sender, EventArgs e)
        {
            scanbtn.Visible = false;
            barcodelbl.Visible = true;
            barcodetxt.Visible = true;
            ActiveControl = barcodetxt;
            addbtn.Visible = true;
        }

        private void cancelbtn_Click(object sender, EventArgs e) //TODO change
        {
            barcodetxt.Clear();//to change
            cancelbtn.Enabled = false;
            addbtn.Enabled = true;
            doesntexistlbl.Visible = false;
            //todo
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void barcodetxt_TextChanged(object sender, EventArgs e) //TODO TEST 
        {
            if (barcodetxt.Text.All(char.IsWhiteSpace)) return;
            cancelbtn.Enabled = true;
            addsuccesslbl.Visible = false;

            MySqlDataReader reader;
            //check if barcode exists in database
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM product WHERE (ID = @ID)", Database.Connection);
            cmd.Parameters.AddWithValue("@ID", barcodetxt.Text);

            reader = cmd.ExecuteReader();
            //if it exists user can press 'add'
            if (reader.HasRows)
            {
                //TODO give product info in the listbox
                addbtn.Enabled = true;
                doesntexistlbl.Visible = false;
                reader.Close();
            }
            //else user will be asked to add it manually
            else
            {
                addsuccesslbl.Visible = false;
                addbtn.Enabled = false;
                doesntexistlbl.Visible = true;
                reader.Close();
            }
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            //screen will go back to start screen
            cancelbtn.Enabled = false;
            scanbtn.Visible = true;
            barcodetxt.Text = String.Empty;
            barcodelbl.Visible = false;
            barcodetxt.Visible = false;
            doesntexistlbl.Visible = false;
            addbtn.Visible = false;
        }

        private void scanmenuitem_Click(object sender, EventArgs e)
        {
            //everything in the scanmenu will be shown
            contentlist.Items.Clear();
            HideContent(sender);
        }

        private void foodmenuitem_Click(object sender, EventArgs e)
        {
            //everything database of the user will be shown
            contentlist.Items.Clear();
            HideContent(sender);
            Database.GetProducts(Database, this);
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in contentlist.CheckedItems)
            {
                //subitem 4 is the location of the ID from the product
                var subitem = item.SubItems[4];
                Database.Deletedata(subitem, Database);
                contentlist.Items.Remove(item);
            }
        }

        /// <summary>
        /// Hides the listview when scan products is clicked, otherwise hides everything else
        /// </summary>
        /// <param name="sender"></param>
        private void HideContent(object sender)
        {
            if (sender.ToString() == "Scan Products")
            {
                contentlist.Hide();
                stopbtn.Show();
                scanbtn.Show();
                exitbtn.Show();
                cancelbtn.Show();
                deletebtn.Hide();
                addmanbtn.Show();
                productinfobox.Show();
            }
            else
            {
                stopbtn.Hide();
                scanbtn.Hide();
                exitbtn.Hide();
                cancelbtn.Hide();
                barcodetxt.Hide();
                barcodelbl.Hide();
                productinfobox.Hide();
                contentlist.Show();
                deletebtn.Show();
                addmanbtn.Hide();
                addbtn.Hide();
            }
        }

        private void addmanbtn_Click(object sender, EventArgs e)
        {
            //manual add form will appear
            doesntexistlbl.Visible = false;
            addbtn.Enabled = true;
            Adding.barcodetxt.Text = barcodetxt.Text;
            Adding.ShowDialog();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            //wont check if barcode textbox is empty
            if (!barcodetxt.Text.All(char.IsDigit)) return;

            //if product add is succesful, label will be shown and barcode will dissapear
            if (Database.Addproducttofridge(this))
            {
                addsuccesslbl.Visible = true;
                barcodetxt.Clear();
            }
        }
    }
}

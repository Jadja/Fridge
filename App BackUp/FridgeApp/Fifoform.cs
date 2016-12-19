using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FridgeApp
{
    public partial class Fifoform : Form
    {
        public DBConnection Database { get; set; }
        public Addingform Adding { get; set; }
        public Fifoform()
        {
            Adding = new Addingform();
            Database = new DBConnection();
            InitializeComponent();
            Connect();
        }

        private void scanbtn_Click(object sender, EventArgs e)
        {
            scanbtn.Visible = false;
            barcodelbl.Visible = true;
            barcodetxt.Visible = true;
            ActiveControl = barcodetxt;//focusing on txt to get barcode
            Console.WriteLine(barcodetxt.Focused);//testing purposes
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            barcodetxt.Text = String.Empty;//to change
            cancelbtn.Enabled = false;
            //todo
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void barcodetxt_TextChanged(object sender, EventArgs e)
        {
            cancelbtn.Enabled = true;
            //todo
        }

        private void testbtn_Click(object sender, EventArgs e)
        {
            Random x = new Random();
            int randomnum = x.Next(1, 10000);
            barcodetxt.Text = randomnum.ToString();
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            cancelbtn.Enabled = false;
            scanbtn.Visible = true;
            barcodetxt.Text = String.Empty;
            barcodelbl.Visible = false;
            barcodetxt.Visible = false;
        }

        private void scanmenuitem_Click(object sender, EventArgs e)
        {   
            contentlist.Items.Clear();
            HideContent(sender);
        }

        private void fridgemenuitem_Click(object sender, EventArgs e)
        {
            HideContent(sender);
            Connect();
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
                testbtn.Show();
                deletebtn.Hide();
                addbtn.Show();
            }
            else
            {
                stopbtn.Hide();
                scanbtn.Hide();
                exitbtn.Hide();
                cancelbtn.Hide();
                barcodetxt.Hide();
                barcodelbl.Hide();
                testbtn.Hide();
                contentlist.Show();
                deletebtn.Show();
                addbtn.Hide();       
            }        
        }

        /// <summary>
        /// Connects to the fifo db and only reads out category name for now
        /// </summary>
        private void Connect()
        {
            if (Database.IsConnected())
            {
                string query = "SELECT p.Name, p.Category, p.Expiration_time, curdate() - f.Add_date as 'daysinfridge', f.rowID FROM fridge as f join product p on p.ID = f.Product order by p.Expiration_time, curdate() - f.Add_date desc";
                var cmd = new MySqlCommand(query, Database.Connection);
                Readdata(cmd);
            }
        }

        /// <summary>
        /// Reads data from query in Connect
        /// </summary>
        /// <param name="cmd"></param>
        private void Readdata(MySqlCommand cmd)
        {
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var listitem = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if(i == 2) listitem[i] = reader.GetDateTime(i).ToShortDateString();
                    else listitem[i] = reader.GetString(i);
                }
                ListViewItem test = new ListViewItem(listitem);
                contentlist.Items.Add(test);            
            }
            reader.Close();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {        
            //TODO: figure out how to get it removed from the DB with this btn
            foreach (ListViewItem item in contentlist.CheckedItems)
            {
                var subitem = item.SubItems[4];
                Deletedata(subitem);
                contentlist.Items.Remove(item);
            }   
        }

        private void Updatedate()
        {
            
           /* string query = "update fridge"; //TODO
            MySqlCommand cmd = new MySqlCommand(query, database.Connection);
            MySqlDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        } //TODO

        private void Deletedata(ListViewItem.ListViewSubItem item)
        {
            string query = "delete from fridge where rowID = @rowID"; 
            MySqlCommand cmd = new MySqlCommand(query, Database.Connection);
            cmd.Parameters.AddWithValue("@rowID", item.Text);
            MySqlDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            Adding.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FridgeApp
{
    public partial class Addingform : Form
    {
        public DBConnection MyDatabase { get; set; }
        public NotifyIcon NotifyIcon { get; set; }
        public Addingform()
        {
            MyDatabase = new DBConnection();
           
            InitializeComponent();

            barcodetxt.Text = "123412341234";
            nametxt.Text = "testproduct";
            exptxt1.Text = "01";
            exptxt2.Text = "01";
            exptxt3.Text = "2016";
            cattxt.Text = "Drinken";

            NotifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Exclamation,
                BalloonTipTitle = "Product added",
                BalloonTipText = "Product has been added to the fridge.",
                BalloonTipIcon = ToolTipIcon.Info
            };
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            barcodetxt.Clear();
            nametxt.Clear();
            desctxt.Clear();
            Close();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader;
            //if the barcode exists in the database the product will only be added to the fridge
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM product WHERE (ID = @ID)", MyDatabase.Connection);
            cmd.Parameters.AddWithValue("@ID", barcodetxt.Text);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("exists.");
                reader.Close();
            }
            else
            {
                MessageBox.Show("dont exist.");
                reader.Close();

                #region productadding

                string queryproduct =
                    "INSERT INTO product (ID, Name, Expiration_time, Description, Category) VALUES (@ID, @Name, @Expiration_time, @Description, @Category)";
                cmd = new MySqlCommand(queryproduct, MyDatabase.Connection);
                cmd.Parameters.AddWithValue("@ID", barcodetxt.Text);
                cmd.Parameters.AddWithValue("@Name", nametxt.Text);
                cmd.Parameters.AddWithValue("@Expiration_time", exptxt3.Text + "-" + exptxt2.Text + "-" + exptxt1.Text);
                cmd.Parameters.AddWithValue("@Description", desctxt.Text);
                cmd.Parameters.AddWithValue("@Category", cattxt.Text);

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
                    MessageBox.Show("Graag de verplichte velden vullen." + ex);
                    return;
                }
                #endregion
            }

            #region fridgeadding
            string queryfridge = "INSERT INTO fridge (`ID`, `Add_date`, `Product`) VALUES('111', curdate(),"+ barcodetxt.Text +")";

            cmd = new MySqlCommand(queryfridge, MyDatabase.Connection);

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }

                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Graag de verplichte velden vullen.");
                return;
            }
            #endregion
            
            NotifyIcon.Visible = true;           
            NotifyIcon.ShowBalloonTip(1000);

            Close();
        }

        private void barcodetxt_TextChanged(object sender, EventArgs e)
        {
            Checkdata();
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            Checkdata();
        }

        private void desctxt_TextChanged(object sender, EventArgs e)
        {
            Checkdata();
        }

        private void cattxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Checkdata();
        }

        private void Checkdata()
        {
            if (barcodetxt.Text.Equals(String.Empty) || nametxt.Text.Equals(String.Empty) || nametxt.Text.All(char.IsWhiteSpace) ||
                barcodetxt.Text.All(char.IsWhiteSpace) || barcodetxt.TextLength < 12) addbtn.Enabled = false;
            else addbtn.Enabled = true;           
        }
    }
}

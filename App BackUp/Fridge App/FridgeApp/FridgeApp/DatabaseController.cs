using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FridgeApp.Entities;

namespace FridgeApp
{
    public class DatabaseController
    {
        public MySqlConnection Connection { get; set; }

        private bool Connect()
        {
            try
            {
                Connection = new MySqlConnection(Config.GetConnectionString());
                if (Connection != null && Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Logger.GetInstance().Log("Cannot connect to server.  Contact administrator");
                        break;
                    case 1042:
                        Logger.GetInstance().Log("Unable to connect to specified MySQL host");
                        break;
                    case 1045:
                        Logger.GetInstance().Log("Invalid username/password, please try again");
                        break;
                }
            }
            // Probably unnecessary since the switch already checks, but I guess we'll see when a failed connection happens
            if (Connection == null)
            {
                Logger.GetInstance().Log("Connection Failed");
            }
            return false;
        }

        private void Close()
        {
            if (IsConnected())
            {
                Connection.Close();
                Logger.GetInstance().Log("Closed Connection");
            }
        }

        public bool IsConnected()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                return true;
            }
            return false;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                Connect();

                string getString = @"SELECT * FROM product";
                MySqlCommand cmd = new MySqlCommand(getString, Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Product product = new Product
                    {
                        ID = dataReader.GetChar("ID"),
                        Name = dataReader.GetString("Naam"),
                        Expiration_time = dataReader.GetDateTime("Geboortedatum"),
                        Description = dataReader.GetString("Telefoon"),
                        Category = dataReader.GetString("Telefoon")
                    };
                    products.Add(product);
                }

            }
            catch (MySqlException e)
            {
                Logger.GetInstance().Log(e.Message);
            }
            finally
            {
                Close();
            }
            return products;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                Connect();

                string getString = @"SELECT * FROM category";
                MySqlCommand cmd = new MySqlCommand(getString, Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Category product = new Category
                    {
                        Name = dataReader.GetString("Naam"),
                        GeneralDaysToExpire = dataReader.GetInt32("General_exp_date")
                    };
                    categories.Add(product);
                }

            }
            catch (MySqlException e)
            {
                Logger.GetInstance().Log(e.Message);
            }
            finally
            {
                Close();
            }
            return categories;
        }

        public List<ProductInHouse> GetProductsInHouse()
        {
            List<ProductInHouse> productsInHouse = new List<ProductInHouse>();
            try
            {
                Connect();

                string getString = @"SELECT * FROM food";
                MySqlCommand cmd = new MySqlCommand(getString, Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    ProductInHouse productInHouse = new ProductInHouse
                    {
                        ID = dataReader.GetChar("ID"),
                        Add_date = dataReader.GetDateTime("Add_date"),
                        Product = dataReader.GetString("Product")
                    };
                    productsInHouse.Add(productInHouse);
                }

            }
            catch (MySqlException e)
            {
                Logger.GetInstance().Log(e.Message);
            }
            finally
            {
                Close();
            }
            return productsInHouse;
        }
        
        /*public List<string>[] Get(string tableName, params string[] columns)
        {
            string sql = "SELECT ";
            if (columns.Count() < 1)
            {
                sql += "*";
            }
            else
            {
                foreach (string column in columns)
                {
                    sql += column + ", ";
                }
                sql = sql.Substring(0, sql.Length - 2);
            }
            sql += " FROM " + tableName;
            return Query(sql);
        }*/

        public void NonQuery(string sql, params string[] values)
        {
            if (Connect())
            {
                MySqlCommand cmd = new MySqlCommand(sql, Connection);
                cmd.Prepare();
                if (values != null && values.Length != 0)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        cmd.Parameters.Add(new MySqlParameter("@val" + i, values[i]));
                    }
                }
                cmd.ExecuteNonQuery();
                Close();
                Logger.GetInstance().Log("Successfully executed command.");
            }
        }

        public DatabaseController()
        {
            Connection = null;
            Connect();
        }

        /// <summary>
        /// Adds the scanned or manually added product to the fridge
        /// </summary>
        public bool Addproducttofridge(dynamic form)
        {
            MySqlDataReader reader;       
            string queryfridge = "INSERT INTO food (`Add_date`, `Product`) VALUES(curdate()," + form.barcodetxt.Text + ")";

            MySqlCommand cmd = new MySqlCommand(queryfridge, Connection);

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                
                reader.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Graag de verplichte velden vullen.");
                return false;
            }
        }

        /// <summary>
        /// Reads data from query in Connect
        /// </summary>
        /// <param name="cmd">the query</param>
        /// <param name="form">fifoform</param>
        private void Readdata(MySqlCommand cmd, Fifoform form)
        {
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var listitem = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (i == 2) listitem[i] = reader.GetDateTime(i).ToShortDateString();
                    listitem[i] = reader.GetString(i);
                }
                ListViewItem test = new ListViewItem(listitem);
                form.contentlist.Items.Add(test);
            }
            reader.Close();
        }

        /// <summary>
        /// Connects to the fifo db and only reads out info of the products
        /// </summary>
        public void GetProducts(DatabaseController database, Fifoform form)
        {
            if (database.IsConnected())
            {
                string query = "SELECT p.Name, p.Category, p.Expiration_time, DATEDIFF(curdate(), Add_date) as daysinfridge, f.ID FROM food as f join product p on p.ID = f.Product order by p.Expiration_time, daysinfridge desc";
                var cmd = new MySqlCommand(query, database.Connection);
                Readdata(cmd, form);
            }
        }

        /// <summary>
        /// Deletes selected data from the food tabel in the database
        /// </summary>
        /// <param name="item">ID of selected item</param>
        /// <param name="database">the database connection</param>
        public void Deletedata(ListViewItem.ListViewSubItem item, DatabaseController database)
        {
            //sql query to delete the item with the given ID
            string query = "delete from food where ID = @ID";
            MySqlCommand cmd = new MySqlCommand(query, database.Connection);
            cmd.Parameters.AddWithValue("@ID", item.Text);

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

        /// <summary>
        /// Allows user to edit info from existing products
        /// </summary>
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
        } //TODO welp kelvin
    }
}
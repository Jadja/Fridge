using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FridgeApp.Entities;

namespace FridgeApp
{
    public class DatabaseController
    {
        public MySqlConnection Connection { get; set; }
        
        public DatabaseController()
        {
            Connection = null;
        }
        /// <summary>
        /// Executes a non query (Insert/Update/Delete)
        /// </summary>
        /// <param name="sql">the query</param>
        /// <param name="values">the values to use</param>
        public void NonQuery(string sql, params string[] values)
        {
            //Only runs if its connected to the database
            if (Connect())
            {
                //MySqlTransaction trans = Connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand(sql, Connection);
                //cmd.Transaction = trans;
                if (values != null && values.Length != 0)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        cmd.Parameters.Add(new MySqlParameter("@val" + i, values[i]));
                    }
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    //trans.Commit();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    //trans.Rollback();
                }
                finally
                {
                    Close();
                    Logger.GetInstance().Log("Successfully executed command.");
                }
            }
        }

        /// <summary>
        /// Makes a connection with the database
        /// </summary>
        /// <returns></returns>
        private bool Connect()
        {
            try
            {
                //Uses the config for the db name/server/password/username
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

        /// <summary>
        /// Closes the connection with the database
        /// </summary>
        private void Close()
        {
            if (IsConnected())
            {
                Connection.Close();
                Connection = null;
                Logger.GetInstance().Log("Closed Connection");
            }
        }

        /// <summary>
        /// Checks if the the app is connected to the database
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the products from the 'product' table
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                //Connect to database
                Connect();
                
                string getString = @"SELECT * FROM product";
                MySqlCommand cmd = new MySqlCommand(getString, Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //Makes a product of each row in the mysql table and adds it to the list of existing products
                    Product product = new Product
                    {
                        ID = dataReader.GetString("ID"),
                        Name = dataReader.GetString("Name"),
                        Expiration_time = dataReader.GetInt32("Expiration_time"),
                        Description = dataReader.GetString("Description"),
                        Category = dataReader.GetString("Category")
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

        /// <summary>
        /// Gets the categories from the 'category' table
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                //Connect to database
                Connect();

                string getString = @"SELECT * FROM category";
                MySqlCommand cmd = new MySqlCommand(getString, Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //Makes a category of each row in the mysql table and adds it to the list of existing categories
                    Category product = new Category
                    {
                        Name = dataReader.GetString("Name"),
                        GeneralDaysToExpire = dataReader.GetInt32("General_exp_time")
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

        /// <summary>
        /// Gets the products from the 'food' table
        /// </summary>
        /// <returns></returns>
        public List<ProductInHouse> GetProductsInHouse()
        {
            List<ProductInHouse> productsInHouse = new List<ProductInHouse>();
            try
            {
                //Connect to database
                Connect();

                string getString = @"SELECT * FROM food";
                MySqlCommand cmd = new MySqlCommand(getString, Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //Makes a productinhouse of each row in the mysql table and adds it to the list of existing products in the house
                    ProductInHouse productInHouse = new ProductInHouse
                    {
                        ID = dataReader.GetString("ID"),
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
    }
}
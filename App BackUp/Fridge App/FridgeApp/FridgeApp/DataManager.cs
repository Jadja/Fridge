using System.Collections.Generic;
using FridgeApp.Entities;

namespace FridgeApp
{
    public class DataManager
    {
        private static DataManager _instance;
        public static DataManager Instance
        {
            //To make it singleton
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }

        public List<Product> Products { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<ProductInHouse> ProductsInHouse { get; private set; }

        /// <summary>
        /// Gets the data from every table in the Fifo DB schema
        /// </summary>
        public void GetData()
        {
            DatabaseController database = new DatabaseController();
            if (Products != null)
            {
                Products.Clear();
            }
            Products = database.GetProducts();
            if (Categories != null)
            {
                Categories.Clear();
            }
            Categories = database.GetCategories();
            if (ProductsInHouse != null)
            {
                ProductsInHouse.Clear();
            }
            ProductsInHouse = database.GetProductsInHouse();
        }

        private DataManager()
        {
            //Private because singleton
            GetData();
        }
    }
}

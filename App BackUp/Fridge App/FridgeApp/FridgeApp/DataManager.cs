using System.Collections.Generic;
using FridgeApp.Entities;

namespace FridgeApp
{
    public class DataManager
    {
        private static DataManager _instance;
        public static DataManager Instance
        {
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

        private DataManager()
        {
            DatabaseController database = new DatabaseController();
            Products = database.GetProducts();
            Categories = database.GetCategories();
            ProductsInHouse = database.GetProductsInHouse();
        }
    }
}

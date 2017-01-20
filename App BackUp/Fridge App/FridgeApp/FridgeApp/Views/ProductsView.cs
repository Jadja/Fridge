using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FridgeApp.Entities;

namespace FridgeApp.Views
{
    public partial class ProductsView : UserControl
    {
        public List<Product> Products;
        public List<ProductInHouse> ProductsInHouse;
        public List<Category> Categories;

        public void OnPanelClick(object sender, EventArgs e)
        {
            MainPanelProducts.BackColor = Color.Black;
        }

        public ProductsView(Rectangle size)
        {
            InitializeComponent();
            Products = DataManager.Instance.Products;
            ProductsInHouse = DataManager.Instance.ProductsInHouse;
            Categories = DataManager.Instance.Categories;
            GridViewProducts.Location = new Point(0, 100);
            GridViewProducts.Size = new Size(size.Width, size.Height - 100);
            GridViewProducts.Font = new Font("Arial", 20);
            GridViewProducts.RowTemplate.Height = 40;
            GridViewProducts.ColumnHeadersDefaultCellStyle.Font = new Font(GridViewProducts.Font, FontStyle.Bold);

            DataTable table = new DataTable();
            GridViewProducts.DataSource = table;
            table.Columns.Add("Naam");
            table.Columns.Add("Houdbaar tot");
            table.Columns.Add("Dagen over", Type.GetType("System.Int32"));
            table.Columns.Add("Beschrijving");
            table.Columns.Add("Categorie");
            table.Columns.Add("ID");
            GridViewProducts.Columns["ID"].Visible = false;
            GridViewProducts.Sort(GridViewProducts.Columns[2], ListSortDirection.Ascending);

            for (int i = 0; i < table.Columns.Count; i++)
            {
                GridViewProducts.Columns[i].Width = size.Width / 5;
            }

            for (int i = 0; i < ProductsInHouse.Count; i++)
            {
                int daysLeft = Convert.ToInt32((ProductsInHouse[i].Add_date - DateTime.Today).TotalDays) + Products.First(p => p.ID == ProductsInHouse[i].Product).Expiration_time;
                if (daysLeft == 0)
                {
                    daysLeft = Convert.ToInt32((ProductsInHouse[i].Add_date - DateTime.Today).TotalDays) + Categories.First(c => c.Name == Products.First(p => p.ID == ProductsInHouse[i].Product).Category).GeneralDaysToExpire;
                }
                string expDate = ProductsInHouse[i].Add_date.AddDays(Products.First(p => p.ID == ProductsInHouse[i].Product).Expiration_time).ToString("dd/MM/yyyy");
                table.Rows.Add(
                    Products.First(p => p.ID == ProductsInHouse[i].Product).Name,
                    expDate,
                    daysLeft,
                    Products.First(p => p.ID == ProductsInHouse[i].Product).Description,
                    Products.First(p => p.ID == ProductsInHouse[i].Product).Category,
                    ProductsInHouse[i].ID
                );
            }       
        }
        /// <summary>
        /// To make the delete key in FiFoApp work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SimulateDeleteKey(object sender, EventArgs e)
        {
            GridViewProducts.Focus();
            SendKeys.Send("{DEL}");
        }

        private void GridViewProducts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DatabaseController db = new DatabaseController();
            //deletes the product with the selected ID
            for (int i = 0; i < GridViewProducts.SelectedRows.Count; i++)
            {
                db.NonQuery("DELETE FROM food WHERE ID = @val0", GridViewProducts.SelectedRows[i].Cells["ID"].Value.ToString());
            }
            DataManager.Instance.GetData();
        }
    }
}

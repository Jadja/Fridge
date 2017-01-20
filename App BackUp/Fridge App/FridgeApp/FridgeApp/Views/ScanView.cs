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
    public partial class ScanView : UserControl
    {
        private List<Product> Products;
        private List<ProductInHouse> ProductsInHouse;
        private List<Category> Categories;
        private Font _Font;

        public ScanView(Rectangle size)
        {
            InitializeComponent();
            _Font = new Font("Arial", 21, FontStyle.Regular);
            //The textbox for the barcode
            TextBoxScan.Size = new Size(size.Width / 4, TextBoxScan.Size.Height);
            TextBoxScan.Location = new Point(size.Width / 4 - TextBoxScan.Width / 2, 110);
            TextBoxScan.Font = _Font;
            CheckDirectAdd.Location = new Point(TextBoxScan.Location.X, TextBoxScan.Location.Y + TextBoxScan.Size.Height + 10);
            //The tables from the MySQL database
            Products = DataManager.Instance.Products;
            Categories = DataManager.Instance.Categories;
            ProductsInHouse = DataManager.Instance.ProductsInHouse;
            //Add form when product doesn't exist
            ShowAddForm.BackColor = Color.AliceBlue;
            ShowAddForm.Location = new Point(size.Width / 2, 0);
            ShowAddForm.Size = new Size(size.Width / 2, size.Height);
            ShowAddForm.Hide();
            AddControlsToAddForm(ShowAddForm);
            //Add form when product does exist
            ViewExistingProduct.BackColor = Color.LightSkyBlue;
            ViewExistingProduct.Location = new Point(size.Width / 2, 0);
            ViewExistingProduct.Size = new Size(size.Width / 2, size.Height);
            ViewExistingProduct.Hide();
            AddControlsToViewForm(ViewExistingProduct);
            //The logo on the right
            LogoPanel.BackgroundImage = Image.FromFile("..\\..\\Content\\logo.png");
            LogoPanel.Size = new Size(size.Width / 2, size.Height);
            LogoPanel.Location = new Point(size.Width / 2, 0);
            LogoPanel.BackgroundImageLayout = ImageLayout.Stretch;
            //Manual add button
            Button AddButton = new Button();
            AddButton.Font = _Font;
            AddButton.Text = "Toevoegen";
            AddButton.Location = new Point(ViewExistingProduct.Controls[10].Location.X, ViewExistingProduct.Controls[10].Location.Y + 70);
            AddButton.Size = ViewExistingProduct.Controls[10].Size;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.TabStop = false;
            AddButton.Click += AddButtonManuallyClick;
            ViewExistingProduct.Controls.Add(AddButton);
        }

        /// <summary>
        /// After adding a new product, the existing-product form will be filled with the info of the new product to edit if needed
        /// </summary>
        private void FillExistingProductView()
        {
            DateTime addedDate = DateTime.Today;
            int daysToExpire = Products.First(p => p.ID == TextBoxScan.Text).Expiration_time;

            addedDate = addedDate.AddDays(daysToExpire);

            //The name/category/barcode will be shown in the form when the product exists
            ViewExistingProduct.Controls[1].Text = Products.First(p => p.ID == TextBoxScan.Text).ID;
            ViewExistingProduct.Controls[3].Text = Products.First(p => p.ID == TextBoxScan.Text).Name;
            ViewExistingProduct.Controls[5].Text = Products.First(p => p.ID == TextBoxScan.Text).Description;
            //The calculated expiration date will be shown in 'Einddatum'
            (ViewExistingProduct.Controls[7] as ComboBox).SelectedItem = addedDate.Day;
            (ViewExistingProduct.Controls[8] as ComboBox).SelectedItem = addedDate.Month;
            (ViewExistingProduct.Controls[9] as ComboBox).SelectedItem = addedDate.Year;
            (ViewExistingProduct.Controls[11] as ComboBox).SelectedItem = Products.First(p => p.ID == TextBoxScan.Text).Category;
            ViewExistingProduct.Show();
        }

        private void TextBoxScan_TextChanged(object sender, EventArgs e)
        {
            ViewExistingProduct.Hide();
            ShowAddForm.Hide();
            //Goes into the if when the text is only numbers
            if (TextBoxScan.Text.All(char.IsDigit) && TextBoxScan.Text != "")
            {
                LogoPanel.Hide();
                //if the barcode already exists in the database, it gets the expiration time that has been added to the product
                if (Products.Exists(p => p.ID == TextBoxScan.Text))
                {
                    FillExistingProductView();
                    //Product will be added to the food table
                    AddToProductsInHouse();
                }
                else
                {
                    //If it doesnt exist, addform will be shown with the barcode already added.
                    ShowAddForm.Show();
                    ShowAddForm.Controls[1].Text = TextBoxScan.Text;
                }
            }
            else
            {
                //Fifo logo will be shown when textbox is empty.
                LogoPanel.Show();
            }
        }
        /// <summary>
        /// Adds the scanned product to the food table.
        /// </summary>
        private void AddToProductsInHouse()
        {
            //If the checkbox to add directly is checked, product will be added right away.
            if (CheckDirectAdd.Checked)
            {
                AddProductToProductsInHouse();
            }
        }
        /// <summary>
        /// Inserts the new product into the food table
        /// </summary>
        private void AddProductToProductsInHouse()
        {
            DatabaseController db = new DatabaseController();
            string sql = "INSERT INTO food (Add_date, Product) VALUES (@val0, @val1)";
            db.NonQuery(sql,
                DateTime.Today.ToString("yyyy-MM-dd"),
                ViewExistingProduct.Controls[1].Text
            );
            //To update the table 
            DataManager.Instance.GetData();
            Products = DataManager.Instance.Products;
            Categories = DataManager.Instance.Categories;
            ProductsInHouse = DataManager.Instance.ProductsInHouse;
            TextBoxScan.Clear();
            TextBoxScan.Focus();
        }

        private void AddButtonManuallyClick(object sender, EventArgs e)
        {
            AddProductToProductsInHouse();
        }

        private void AddNewProduct(object sender, EventArgs e)
        {
            DatabaseController db = new DatabaseController();
            string expTime = "0";

            if (ShowAddForm.Controls[9].Text != string.Empty && ShowAddForm.Controls[8].Text != string.Empty && ShowAddForm.Controls[7].Text != string.Empty)
            {
                //Converts Einddatum to amount of days and then into a string
                expTime = (new DateTime(int.Parse(ShowAddForm.Controls[9].Text), int.Parse(ShowAddForm.Controls[8].Text), int.Parse(ShowAddForm.Controls[7].Text)) - DateTime.Today).Days.ToString();
            }

            //if the exp date is unknown (days till expiring is 0 or elss than 0), the product will get the general exp date from its given category.
            if (int.Parse(expTime) <= 0)
            {
                expTime = Categories.First(c => ShowAddForm.Controls[11].Text.Equals(c.Name)).GeneralDaysToExpire.ToString();
            }

            //First inserts the product into the table with all products in our database
            string sql = "INSERT INTO product (ID, Name, Expiration_time, Description, Category) VALUES (@val0, @val1, @val2, @val3, @val4)";
            db.NonQuery(sql,
                ShowAddForm.Controls[1].Text, //the ID
                ShowAddForm.Controls[3].Text, //The name
                expTime, //The expiration time
                ShowAddForm.Controls[5].Text, //The description
                ShowAddForm.Controls[11].Text //The category
            );
            //Then inserts it into the food table of the client
            sql = "INSERT INTO food (Add_date, Product) VALUES (@val0, @val1)";
            db.NonQuery(sql,
                DateTime.Today.ToString("yyyy-MM-dd"),
                ShowAddForm.Controls[1].Text
            );
            //Addform gets emptied again
            ShowAddForm.Controls[1].Text = "";
            ShowAddForm.Controls[3].Text = "";
            ShowAddForm.Controls[5].Text = "";
            (ShowAddForm.Controls[7] as ComboBox).SelectedItem = null;
            (ShowAddForm.Controls[8] as ComboBox).SelectedItem = null;
            (ShowAddForm.Controls[9] as ComboBox).SelectedItem = null;
            (ShowAddForm.Controls[11] as ComboBox).SelectedItem = null;
            DataManager.Instance.GetData();
            Products = DataManager.Instance.Products;
            Categories = DataManager.Instance.Categories;
            ProductsInHouse = DataManager.Instance.ProductsInHouse;
            FillExistingProductView();
            ShowAddForm.Hide();
            ViewExistingProduct.Show();
        }

        /// <summary>
        /// Adds controls to the (non)existing-product forms
        /// </summary>
        /// <param name="form">the (non)existing-product form</param>
        /// <param name="padding">the amount of space between everything</param>
        private void AddControls(Panel form, int padding)
        {
            #region Adding Control Options
            //lblBarcode
            Label lblBarcode = new Label();
            lblBarcode.Font = _Font;
            lblBarcode.Text = "Barcode*";
            lblBarcode.Location = new Point(padding, form.Height / 10);
            lblBarcode.Size = new Size(form.Width / 3, 50);
            form.Controls.Add(lblBarcode);
            //textBarcode
            TextBox textBarcode = new TextBox();
            textBarcode.Font = _Font;
            textBarcode.Location = new Point(padding + lblBarcode.Size.Width, form.Height / 10);
            textBarcode.Size = new Size(form.Width / 3, 50);
            form.Controls.Add(textBarcode);
            //lblProductName
            Label lblProductName = new Label();
            lblProductName.Font = _Font;
            lblProductName.Text = "Product naam*";
            lblProductName.Location = new Point(padding, form.Height / 10 + padding);
            lblProductName.Size = new Size(form.Width / 3, 50);
            form.Controls.Add(lblProductName);
            //textProductName
            TextBox textProductName = new TextBox();
            textProductName.Font = _Font;
            textProductName.Location = new Point(padding + lblBarcode.Size.Width, form.Height / 10 + padding);
            textProductName.Size = new Size(form.Width / 3, 50);
            form.Controls.Add(textProductName);
            //lblDescription
            Label lblDescription = new Label();
            lblDescription.Font = _Font;
            lblDescription.Text = "Beschrijving";
            lblDescription.Location = new Point(padding, form.Height / 10 + padding * 2);
            lblDescription.Size = new Size(form.Width / 3, 50);
            form.Controls.Add(lblDescription);
            //textDescription
            TextBox textDescription = new TextBox();
            textDescription.Font = _Font;
            textDescription.Location = new Point(padding + lblBarcode.Size.Width, form.Height / 10 + padding * 2);
            textDescription.Multiline = true;
            textDescription.Size = new Size(form.Width / 3, 150);
            form.Controls.Add(textDescription);
            //lblExpDate
            Label lblExpDate = new Label();
            lblExpDate.Font = _Font;
            lblExpDate.Text = "Einddatum";
            lblExpDate.Location = new Point(padding, form.Height / 10 + padding * 5);
            lblExpDate.Size = new Size(form.Width / 3, 50);
            form.Controls.Add(lblExpDate);
            //comboExpDateDay
            ComboBox comboExpDateDay = new ComboBox();
            comboExpDateDay.Font = _Font;
            comboExpDateDay.Location = new Point(padding + lblBarcode.Size.Width, form.Height / 10 + padding * 5);
            comboExpDateDay.Size = new Size((form.Width / 3) / 3, 50);
            comboExpDateDay.DropDownStyle = ComboBoxStyle.DropDownList;
            comboExpDateDay.DropDownHeight = 300;
            for (int i = 1; i <= 31; i++)
            {
                comboExpDateDay.Items.Add(i);
            }
            form.Controls.Add(comboExpDateDay);
            //comboExpDateMonth
            ComboBox comboExpDateMonth = new ComboBox();
            comboExpDateMonth.Font = _Font;
            comboExpDateMonth.Location = new Point(comboExpDateDay.Location.X + comboExpDateDay.Size.Width, comboExpDateDay.Location.Y);
            comboExpDateMonth.Size = new Size(comboExpDateDay.Size.Width, comboExpDateDay.Size.Height);
            comboExpDateMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            comboExpDateMonth.DropDownHeight = 300;
            for (int i = 1; i <= 12; i++)
            {
                comboExpDateMonth.Items.Add(i);
            }
            form.Controls.Add(comboExpDateMonth);
            //comboExpDateYear
            ComboBox comboExpDateYear = new ComboBox();
            comboExpDateYear.Font = _Font;
            comboExpDateYear.Location = new Point(comboExpDateMonth.Location.X + comboExpDateMonth.Size.Width, comboExpDateMonth.Location.Y);
            comboExpDateYear.Size = new Size(comboExpDateMonth.Size.Width, comboExpDateMonth.Size.Height);
            comboExpDateYear.DropDownStyle = ComboBoxStyle.DropDownList;
            comboExpDateYear.DropDownHeight = 300;
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 50; i++)
            {
                comboExpDateYear.Items.Add(i);
            }
            form.Controls.Add(comboExpDateYear);
            //lblCategory
            Label lblCategory = new Label();
            lblCategory.Font = _Font;
            lblCategory.Text = "Categorie*";
            lblCategory.Location = new Point(padding, form.Height / 10 + padding * 6);
            lblCategory.Size = new Size(form.Width / 3, 50);
            form.Controls.Add(lblCategory);
            //comboCategory
            ComboBox comboCategory = new ComboBox();
            comboCategory.Font = _Font;
            comboCategory.Location = new Point(padding + lblBarcode.Size.Width, form.Height / 10 + padding * 6);
            comboCategory.Size = new Size(form.Width / 3, 50);
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.DropDownHeight = 300;
            for (int i = 0; i < Categories.Count; i++)
            {
                comboCategory.Items.Add(Categories[i].Name);
            }
            form.Controls.Add(comboCategory);
            #endregion
        }

        /// <summary>
        /// Adds controls to the non-existing-product addform
        /// </summary>
        /// <param name="form">the non-existing-product add form</param>
        private void AddControlsToAddForm(Panel form)
        {
            int padding = 70;
            AddControls(form, padding);
            //btnAdd
            Button btnAdd = new Button();
            btnAdd.Font = _Font;
            btnAdd.Text = "Toevoegen";
            btnAdd.Location = new Point(padding + form.Width / 3, form.Height / 10 + padding * 7);
            btnAdd.Size = new Size(form.Width / 3, 50);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.TabStop = false;
            btnAdd.Click += AddNewProduct;
            form.Controls.Add(btnAdd);
        }

        private void UpdateProductClick(object sender, EventArgs e)
        {
            //updates the edited product in the database
            DatabaseController db = new DatabaseController();
            string date = "0";
            //converts the given new exp date to an amount of days
            if (ViewExistingProduct.Controls[9].Text != string.Empty && ViewExistingProduct.Controls[8].Text != string.Empty && ViewExistingProduct.Controls[7].Text != string.Empty)
            {
                date = (new DateTime(int.Parse(ViewExistingProduct.Controls[9].Text), int.Parse(ViewExistingProduct.Controls[8].Text), int.Parse(ViewExistingProduct.Controls[7].Text)) - DateTime.Today).ToString();
                date = date.Substring(0, date.IndexOf(":"));
            }
            string sql = "UPDATE product SET Name = @val0, Expiration_time = @val1, Description = @val2, Category = @val3 WHERE ID = @val4";
            db.NonQuery(sql,
                ViewExistingProduct.Controls[3].Text, //the name
                date, //the exp time
                ViewExistingProduct.Controls[5].Text, //the description
                ViewExistingProduct.Controls[11].Text, //the category
                ViewExistingProduct.Controls[1].Text //the barcode of the product that should be edited
            );
            //Updates the the products table in the app
            DataManager.Instance.GetData();
        }
        /// <summary>
        /// Adds controls to the existing-product addform
        /// </summary>
        /// <param name="form">the existing-product add form</param>
        private void AddControlsToViewForm(Panel form)
        {
            int padding = 70;
            AddControls(form, padding);
            //btnUpdate
            Button btnAdd = new Button();
            btnAdd.Font = _Font;
            btnAdd.Text = "Bijwerken";
            btnAdd.Location = new Point(padding + form.Width / 3, form.Height / 10 + padding * 7);
            btnAdd.Size = new Size(form.Width / 3, 50);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.TabStop = false;
            btnAdd.Click += UpdateProductClick;
            form.Controls.Add(btnAdd);
        }

        private void CheckDirectAdd_CheckedChanged(object sender, EventArgs e)
        {
            //Keeps focus on the textbox to be able to scan
            ActiveControl = TextBoxScan;
        }
    }
}

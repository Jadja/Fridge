using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FridgeApp.Views;

namespace FridgeApp
{
    public partial class FifoApp : Form
    {
        private Rectangle WorkingArea;

        public FifoApp()
        {
            InitializeComponent();
            WorkingArea = Screen.PrimaryScreen.WorkingArea;
            MinimumSize = new Size(WorkingArea.Width, WorkingArea.Height);
            ScanView scanView = new ScanView(WorkingArea);
            SwitchView(scanView);
            ActiveControl = scanView.Controls[3];
            MenuButtonScan.BackColor = Color.DarkSlateBlue;
            MenuPanel.Size = new Size(WorkingArea.Width / 2, 100);
            MenuButtonDelete.Location = new Point(WorkingArea.Width - MenuButtonDelete.Width, 0);
        }
        /// <summary>
        /// todo add commenting here
        /// </summary>
        /// <param name="view"></param>
        private void SwitchView(UserControl view)
        {
            if (MenuPanel.Controls.Count > 0)
            {
                for (int i = 0; i < MenuPanel.Controls.Count; i++)
                {
                    MenuPanel.Controls[i].BackColor = Color.RoyalBlue;
                }
            }
            if (ViewPanel.Controls.Count > 0)
            {
                UserControl oldView = ViewPanel.Controls[0] as UserControl;
                ViewPanel.Controls.Remove(oldView);
                oldView.Dispose();
            }
            ViewPanel.Controls.Add(view);
            view.Dock = DockStyle.Fill;
        }

        private void MenuButtonScan_Click(object sender, EventArgs e)
        {
            //Switches to the scan screen
            ScanView scanView = new ScanView(WorkingArea);
            SwitchView(scanView);
            ActiveControl = scanView.Controls[3];
            MenuButtonScan.BackColor = Color.DarkSlateBlue;
            MenuPanel.Size = new Size(WorkingArea.Width / 2, 100);
            MenuButtonDelete.Hide();
        }

        private void MenuButtonProducts_Click(object sender, EventArgs e)
        {
            //Switches to the product screen
            ProductsView productsView = new ProductsView(WorkingArea);
            MenuButtonDelete.Show();
            MenuButtonDelete.Click += productsView.SimulateDeleteKey;
            //productsView
            SwitchView(productsView);
            MenuButtonProducts.BackColor = Color.DarkSlateBlue;
            MenuPanel.Size = new Size(WorkingArea.Width, 100);
        }

        private void MenuButtonDelete_Click(object sender, EventArgs e)
        {
            //Deletes the selected product(s)
        }
    }
}

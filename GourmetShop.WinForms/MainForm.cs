using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GourmetShop.DataAccess;
using GourmetShop.DataAccess.Repositories;


namespace GourmetShop.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
     
        }

        private void MainForm_Load(object sender, EventArgs e)
        { 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["prod"].ConnectionString;
            ProductRepository p = new ProductRepository(connectionString);
            var prods = p.GetAll();
            dgv.DataSource = prods;

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["prod"].ConnectionString;
            SupplierRepository sr = new SupplierRepository(connectionString);
             var supp = sr.GetAll();
            dgv.DataSource = supp;
        }
    }
}

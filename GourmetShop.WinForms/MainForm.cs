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
using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;


namespace GourmetShop.WinForms
{
    public partial class MainForm : Form
    {
        private string connectionString;
        public MainForm()
        {
            InitializeComponent();
     
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           this.connectionString = ConfigurationManager.ConnectionStrings["prod"].ConnectionString;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductRepository p = new ProductRepository(connectionString);
            var prods = p.GetAll();
            dgv.DataSource = prods;

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierRepository sr = new SupplierRepository(connectionString);
            var supp = sr.GetAll();
            dgv.DataSource = supp;
        }

        private void addSupplier_Click(object sender, EventArgs e)
        {
            using (SupplierForm f = new SupplierForm())
            {
                var result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Supplier s = new Supplier();
                    s.CompanyName = f.CompanyName;
                    s.ContactName = f.ContactName;
                    s.ContactTitle = f.ContactTitle;
                    s.City = f.City;
                    s.Country = f.Country;
                    s.Phone = f.Phone;
                    s.Fax = f.Fax;

                    SupplierRepository sr = new SupplierRepository(connectionString);
                    sr.Add(s);
                    dgv.DataSource = sr.GetAll();
                }
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (ProductForm f = new ProductForm())
            {
                var result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Product p = new Product();
                    p.ProductName = f.ProductName;
                    p.SupplierId = f.SupplierId;
                    p.UnitPrice = f.UnitPrice;
                    p.Package = f.Package;
                    p.IsDiscontinued = f.IsDiscontinued;

                    ProductRepository pr = new ProductRepository(connectionString);

                    pr.Add(p);
                    dgv.DataSource = pr.GetAll();
                }
            }
        }
    }
}

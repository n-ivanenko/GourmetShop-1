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

    enum State
    {
        Product,
        Supplier,
    }
    public partial class MainForm : Form
    {
        private string connectionString;
        private int clickedRow;
        private State s;
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
            this.s = State.Product;
            ProductRepository p = new ProductRepository(connectionString);
            var prods = p.GetAll();
            dgv.DataSource = prods;

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.s = State.Supplier;
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
                    this.s = State.Product;
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
                    this.s = State.Product;
                }
            }
        }

        private void dgv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            this.clickedRow = e.RowIndex;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this should be refactored to use polymorphism more to repalce this duplicate code
            if (this.s == State.Product)
            {
                using (ProductForm f = new ProductForm(Convert.ToInt32(dgv[0, this.clickedRow].Value),
                                                       Convert.ToString(dgv[1, this.clickedRow].Value),
                                                       Convert.ToInt32(dgv[2, this.clickedRow].Value.ToString()),
                                                       Convert.ToDecimal(dgv[3, this.clickedRow].Value.ToString()),
                                                       Convert.ToString(dgv[4, this.clickedRow].Value),
                                                       Convert.ToBoolean(dgv[5, this.clickedRow].Value)
                                                       ))
                {
                    var result = f.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Product p = new Product();
                        p.Id = f.Id;
                        p.ProductName = f.ProductName;
                        p.SupplierId = f.SupplierId;
                        p.UnitPrice = f.UnitPrice;
                        p.Package = f.Package;
                        p.IsDiscontinued = f.IsDiscontinued;

                        ProductRepository pr = new ProductRepository(connectionString);

                        pr.Update(p);
                        dgv.DataSource = pr.GetAll();
                    }
                }
            } else if(this.s == State.Supplier)
            {
                using (SupplierForm f = new SupplierForm(Convert.ToInt32(dgv[0, this.clickedRow].Value),
                                                         Convert.ToString(dgv[1, this.clickedRow].Value),
                                                         Convert.ToString(dgv[2, this.clickedRow].Value),
                                                         Convert.ToString(dgv[3, this.clickedRow].Value),
                                                         Convert.ToString(dgv[4, this.clickedRow].Value),
                                                         Convert.ToString(dgv[5, this.clickedRow].Value),
                                                         Convert.ToString(dgv[6, this.clickedRow].Value),
                                                         Convert.ToString(dgv[7, this.clickedRow].Value)))

                {
                    var result = f.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Supplier s = new Supplier();
                        s.Id = f.Id;
                        s.CompanyName = f.CompanyName;
                        s.ContactName = f.ContactName;
                        s.ContactTitle = f.ContactTitle;
                        s.City = f.City;
                        s.Country = f.Country;
                        s.Phone = f.Phone;
                        s.Fax = f.Fax;

                        SupplierRepository sr = new SupplierRepository(connectionString);

                        sr.Update(s);
                        dgv.DataSource = sr.GetAll();
                    }
                }
            }
        
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(String.Format("Are you sure you wanted to delete record ID {0} {1}?",
                                                   dgv[0, this.clickedRow].Value,
                                                   dgv[1, this.clickedRow].Value),
                                                   "Delete",
                                                   MessageBoxButtons.YesNo);
             if (r == DialogResult.Yes)
             {
                if (this.s == State.Product)
                {
                    ProductRepository pr = new ProductRepository(connectionString);
                    pr.Delete(Convert.ToInt32(dgv[0, this.clickedRow].Value));
                    dgv.DataSource = pr.GetAll();
                }
                else if (this.s == State.Supplier)
                {
                    SupplierRepository sr = new SupplierRepository(connectionString);
                    sr.Delete(Convert.ToInt32(dgv[0, this.clickedRow].Value));
                    dgv.DataSource = sr.GetAll();
                }
             } 
            
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        // added viewCustomers and viewOrders to MainForms -Nina (02/08)
        private void viewCustomersToolStripMenuItem(object sender, EventArgs e)
        {
            CustomerRepository cr = new CustomerRepository(connectionString);

            try
            {
                var customers = cr.GetAll();
                dgv.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void viewOrdersToolStripMenuItem(object sender, EventArgs e)
        {
            OrderRepository or = new OrderRepository(connectionString);

            try
            {
                var orders = or.GetAll();
                dgv.DataSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }
    }
}

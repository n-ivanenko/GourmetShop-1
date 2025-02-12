using GourmetShop.DataAccess.Repositories;
using GourmetShop.DataAccess.Entities;
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
using System.Dynamic;
using static System.Windows.Forms.AxHost;
using System.Windows.Data;
using FastMember;

namespace GourmetShop.CustomerView
{
    enum GridType {
        Product,
        Cart
    }
    public partial class MainForm : Form
    {
        private string connectionString;
        private Customer customer;
        private Boolean formInit = false;
        private int clickedRow;
        private GridType gt = GridType.Product;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["prod"].ConnectionString;
            CustomerRepository cr = new CustomerRepository(connectionString);

            using (LoginForm lf = new LoginForm(cr))
            {
               var result =  lf.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else if (result == DialogResult.OK)
                {
                    this.customer = lf.customer;
                    this.FetchProdData();
                }
            }
            this.formInit = true;
        }

        private void FetchProdData()
        {
            this.gt = GridType.Product;
            txtFilter.Clear();
            this.formInit = false;
            dgvProd.Visible = true;
            dgvCart.Visible = false;
            ProductRepository pr = new ProductRepository(connectionString);
            
            var prods = pr.GetAllCurrent();

            //we need a DataTable to be able to filter and 
            // annoyingly the best way to turn an IEnumberable like a list
            // into a dt is by using the FastMember library
            DataTable dt = new DataTable();

            using (var reader = ObjectReader.Create(prods, "Id", 
                                                           "CompanyName", 
                                                           "ProductName", 
                                                           "SupplierId", 
                                                           "IsDiscontinued",
                                                           "UnitPrice",
                                                           "Package"))
            {
                dt.Load(reader);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            dgvProd.DataSource = bs;
            dgvProd.ReadOnly = true;
            dgvProd.Columns["CompanyName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProd.Columns["Id"].Visible = false;
            dgvProd.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProd.Columns["SupplierId"].Visible = false;
            dgvProd.Columns["IsDiscontinued"].Visible = false;

            foreach (DataGridViewColumn column in dgvProd.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            this.formInit = true;

        }

        private void FetchCartData()
        {
            this.gt = GridType.Cart;
            txtFilter.Clear();
            CartRepository cr = new CartRepository(connectionString);
            this.formInit = false;
            dgvCart.Visible = true;
            dgvProd.Visible = false;
            var mycart = cr.GetMyCart(this.customer.Id);

            //we need a DataTable to be able to filter and 
            // annoyingly the best way to turn an IEnumberable like a list
            // into a dt is by using the FastMember library
            DataTable dt = new DataTable();

            using (var reader = ObjectReader.Create(mycart, "Id",
                                                            "CustomerId",
                                                            "ProductId",
                                                            "CompanyName",
                                                            "ProductName",
                                                            "Package",
                                                            "UnitPrice",
                                                            "Quantity"))
            {
                dt.Load(reader);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            dgvCart.DataSource = bs;
            dgvCart.ReadOnly = false;
            dgvCart.Columns["Id"].Visible = false;
            dgvCart.Columns["CustomerId"].Visible = false;
            dgvCart.Columns["ProductId"].Visible = false;
            dgvCart.Columns["CompanyName"].ReadOnly = true;
            dgvCart.Columns["CompanyName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCart.Columns["ProductName"].ReadOnly = true;
            dgvCart.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCart.Columns["Package"].ReadOnly = true;
            dgvCart.Columns["UnitPrice"].ReadOnly = true;
            //allow editing quanity
            dgvCart.Columns["Quantity"].ReadOnly = false;

            this.formInit = true;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FetchProdData();
        }

        private void viewMyCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FetchCartData();

        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(formInit)
            {
                CartRepository cr = new CartRepository(connectionString);
                var id = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["Id"].Value);
                var quant = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                cr.UpdateCartQuantity(id, quant);
            }
        }

        private void deleteFromCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //lil weird here but you can call up this menu on the header row which is not what we want.
            if (this.clickedRow >= 0)
            {
                var r = MessageBox.Show(String.Format("Are you sure you wanted to delete {0} from your cart?",
                                           dgvCart.Rows[this.clickedRow].Cells["ProductName"].Value),
                                           "Delete",
                                           MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    CartRepository cr = new CartRepository(connectionString);
                    cr.Delete(Convert.ToInt32(dgvCart.Rows[this.clickedRow].Cells["Id"].Value));
                    this.FetchCartData();
                }
            }
        }

        private void dgvCart_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            this.clickedRow = e.RowIndex;
        }

        private void addToCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartRepository cr = new CartRepository(connectionString);
            Cart c = new Cart();
            var row = dgvProd.Rows[this.clickedRow];
            c.CustomerId = this.customer.Id;
            c.ProductId = Convert.ToInt32(row.Cells["Id"].Value);
            c.UnitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
            c.Quantity = 1;

            cr.Add(c);
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvCart.Visible = true;
            dgvProd.Visible = false;

            decimal sum = 0;

            for (int i = 0; i < dgvCart.Rows.Count; i++)
            {

                sum += (Convert.ToDecimal(dgvCart.Rows[i].Cells["UnitPrice"].Value)
                        * Convert.ToInt32(dgvCart.Rows[i].Cells["Quantity"].Value));

            }

            var r = MessageBox.Show(String.Format("Are you ready to checkout? Your total will be {0}", sum),
                                    "Checkout",
                                    MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                CartRepository cr = new CartRepository(connectionString);
                
                cr.Checkout(this.customer.Id, 0);
                MessageBox.Show("Order placed!");
                this.FetchCartData();
            }

        }

        //private void txtFilter_TextChanged(object sender, EventArgs e)
//{
//    string filter = String.Format("CompanyName LIKE '%{0}%' or ProductName LIKE '%{0}%'", txtFilter.Text);

//    if (this.gt == GridType.Product)
//    {
//        ((BindingSource)dgvProd.DataSource).Filter = filter;
//    }
//    else if (this.gt == GridType.Cart)
//    {
//       ((BindingSource)dgvCart.DataSource).Filter = filter; 
//    }
//}
private void txtFilter_TextChanged(object sender, EventArgs e)
{
    string filter = String.Format("CompanyName LIKE '%{0}%' or ProductName LIKE '%{0}%'", txtFilter.Text);

    if (this.gt == GridType.Product)
    {
        ((BindingSource)dgvProd.DataSource).Filter = filter;
    }
    else if (this.gt == GridType.Cart)
    {
        string cartFilter = String.Format("CompanyName LIKE '%{0}%' or ProductName LIKE '%{0}%' or CustomerId LIKE '%{0}%' or ProductName LIKE '%{0}%'", txtFilter.Text);

        ((BindingSource)dgvCart.DataSource).Filter = cartFilte
    }
}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.AdminView
{
    public partial class ProductForm : Form
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(int Id, string ProductName, int SupplierId, decimal UnitPrice, string Package, bool IsDiscontinued)
        {
            InitializeComponent();

            txtId.Text = Id.ToString();
            txtProductName.Text = ProductName;
            txtSupplierId.Text = SupplierId.ToString();
            txtUnitPrice.Text = UnitPrice.ToString();
            txtPackage.Text = Package;
            chkDiscontinued.Checked = IsDiscontinued;
            this.Text = "Edit Product";
            this.btnAdd.Text = "Save";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                this.Id = Convert.ToInt32(txtId.Text);
            }
            this.ProductName = txtProductName.Text;
            this.SupplierId = Convert.ToInt32(txtSupplierId.Text);
            this.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            this.Package = txtPackage.Text;
            this.IsDiscontinued = chkDiscontinued.Checked;
        }
    }
}

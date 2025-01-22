using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.WinForms
{
    public partial class ProductForm : Form
    {

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ProductName = txtProductName.Text;
            this.SupplierId = Convert.ToInt32(txtSupplierId.Text);
            this.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            this.Package = txtPackage.Text;
            this.IsDiscontinued = chkDiscontinued.Checked;
        }
    }
}

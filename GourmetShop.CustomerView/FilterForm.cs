using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.CustomerView
{
    public partial class FilterForm : Form
    {
        public string Supplier;
        public FilterForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Supplier = txtSupplier.Text;
        }
    }
}

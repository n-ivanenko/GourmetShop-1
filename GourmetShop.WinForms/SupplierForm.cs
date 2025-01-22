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
    public partial class SupplierForm : Form
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City {  get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public SupplierForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.CompanyName = txtCompanyName.Text;
            this.ContactName = txtContactName.Text;
            this.ContactTitle = txtContactTitle.Text;
            this.City = txtCity.Text;
            this.Country = txtCountry.Text;
            this.Phone = txtPhone.Text;
            this.Fax = txtFax.Text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.AdminView
{
    public partial class SupplierForm : Form
    {
        public int Id { get; set; }
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

        public SupplierForm(int Id, string CompanyName, string ContactName, string ContactTitle, string City, string Country, string Phone, string Fax)
        {
            InitializeComponent();

            txtId.Text = Id.ToString();
            txtCompanyName.Text = CompanyName;
            txtContactName.Text = ContactName;
            txtContactTitle.Text = ContactTitle;
            txtCity.Text = City;
            txtCountry.Text = Country;
            txtPhone.Text = Phone;
            txtFax.Text = Fax;
            this.Text = "Edit Supplier";
            btnAdd.Text = "Save";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                this.Id = Convert.ToInt32(txtId.Text);
            }
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

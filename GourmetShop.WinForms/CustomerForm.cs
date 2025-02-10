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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }


        /// Event handler for the "Add" button.
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Retrieve data from fields
            string name = txtCustomerName.Text;
            string contact = txtContactName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            bool isActive = chkIsActive.Checked;

            // Example: simple validation
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid Customer Name.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Demonstrate a successful "add"
            MessageBox.Show(
                $"Customer '{name}' added.\nContact: {contact}\nPhone: {phone}\nEmail: {email}\nActive: {isActive}",
                "Customer Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// Event handler for the "Cancel" button.
        private void BtnCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

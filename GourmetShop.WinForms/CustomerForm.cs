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
            // Calls the InitializeComponent method in the Designer file
            InitializeComponent();
        }

        // Event handler for the "Add" button
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Gather the input values
            string customerName = txtCustomerName.Text;
            string contactName = txtContactName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            bool isActive = chkIsActive.Checked;

            // Show a simple message with the entered data
            MessageBox.Show(
                $"Customer Name: {customerName}\n" +
                $"Contact Name: {contactName}\n" +
                $"Phone: {phone}\n" +
                $"Email: {email}\n" +
                $"Active? {isActive}",
                "Customer Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
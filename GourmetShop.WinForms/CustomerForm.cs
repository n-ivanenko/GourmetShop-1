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
    public partial class CustomerForm : Form
    {
      
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

      
        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(int id, string firstName, string lastName,
                            string phone, string email, bool isActive)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtPhone.Text = phone;
            txtEmail.Text = email;
            chkIsActive.Checked = isActive;

            this.Text = "Edit Customer";
            this.btnAdd.Text = "Save";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            this.FirstName = txtFirstName.Text;
            this.LastName = txtLastName.Text;
            this.Phone = txtPhone.Text;
            this.Email = txtEmail.Text;
            this.IsActive = chkIsActive.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
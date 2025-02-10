using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;

namespace GourmetShop.CustomerView
{
    public partial class LoginForm : Form
    {
        private CustomerRepository cr;
        public Customer customer;
        public LoginForm(CustomerRepository cr)
        {
            InitializeComponent();
            this.cr = cr;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                customer = cr.Login(txtUserName.Text, txtPassword.Text);
          
                this.DialogResult = DialogResult.OK;
                this.Close();

            } catch(AuthenticationException ae)
            {
                MessageBox.Show("Invalid Username or Password");
            }

        }
    }
}

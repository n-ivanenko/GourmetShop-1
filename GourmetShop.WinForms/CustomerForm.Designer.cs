using System.ComponentModel;
using System.Windows.Forms;

namespace GourmetShop.WinForms
{
    partial class CustomerForm
    {
        private IContainer components = null;

        // Controls on the form
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private Label lblContactName;
        private TextBox txtContactName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblIsActive;
        private CheckBox chkIsActive;
        private Button btnAdd;
        private Button btnCancel;

        /// <summary>
        /// Clean up resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 
            // lblCustomerName
            // 
            this.lblCustomerName = new Label();
            this.lblCustomerName.Text = "Customer Name:";
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 20);

            // 
            // txtCustomerName
            // 
            this.txtCustomerName = new TextBox();
            this.txtCustomerName.Location = new System.Drawing.Point(150, 17);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(220, 26);
            this.txtCustomerName.TabIndex = 0;

            // 
            // lblContactName
            // 
            this.lblContactName = new Label();
            this.lblContactName.Text = "Contact Name:";
            this.lblContactName.AutoSize = true;
            this.lblContactName.Location = new System.Drawing.Point(20, 60);

            // 
            // txtContactName
            // 
            this.txtContactName = new TextBox();
            this.txtContactName.Location = new System.Drawing.Point(150, 57);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(220, 26);
            this.txtContactName.TabIndex = 1;

            // 
            // lblPhone
            // 
            this.lblPhone = new Label();
            this.lblPhone.Text = "Phone:";
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 100);

            // 
            // txtPhone
            // 
            this.txtPhone = new TextBox();
            this.txtPhone.Location = new System.Drawing.Point(150, 97);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(220, 26);
            this.txtPhone.TabIndex = 2;

            // 
            // lblEmail
            // 
            this.lblEmail = new Label();
            this.lblEmail.Text = "Email:";
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 140);

            // 
            // txtEmail
            // 
            this.txtEmail = new TextBox();
            this.txtEmail.Location = new System.Drawing.Point(150, 137);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 26);
            this.txtEmail.TabIndex = 3;

            // 
            // lblIsActive
            // 
            this.lblIsActive = new Label();
            this.lblIsActive.Text = "Active?";
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(20, 180);

            // 
            // chkIsActive
            // 
            this.chkIsActive = new CheckBox();
            this.chkIsActive.Location = new System.Drawing.Point(150, 177);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(18, 17);
            this.chkIsActive.TabIndex = 4;

            // 
            // btnAdd
            // 
            this.btnAdd = new Button();
            this.btnAdd.Location = new System.Drawing.Point(20, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // Wire up the click event to BtnAdd_Click in CustomerForm.cs
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // 
            // btnCancel
            // 
            this.btnCancel = new Button();
            this.btnCancel.Location = new System.Drawing.Point(110, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // This button will close the form automatically if you set DialogResult
            this.btnCancel.DialogResult = DialogResult.Cancel;

            // 
            // CustomerForm
            // 
            this.AcceptButton = this.btnAdd;    // Press Enter → triggers Add
            this.CancelButton = this.btnCancel; // Press Esc → triggers Cancel
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblContactName);
            this.Controls.Add(this.txtContactName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblIsActive);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Name = "CustomerForm";
            this.Text = "Add Customer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
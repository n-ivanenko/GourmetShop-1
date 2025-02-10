using System.ComponentModel;
using System.Windows.Forms;

namespace GourmetShop.WinForms
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        // Declare all controls upfront
        private Button btnAdd;
        private Button btnCancel;
        private TextBox txtCustomerName;
        private TextBox txtContactName;
        private MaskedTextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtId;
        private CheckBox chkIsActive;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // 
            // Suspend layout during control init
            // 
            this.SuspendLayout();

            // 
            // btnAdd
            // 
            this.btnAdd = new Button
            {
                DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(279, 273),
                Name = "btnAdd",
                Size = new System.Drawing.Size(75, 34),
                TabIndex = 6,
                Text = "Add",
                UseVisualStyleBackColor = true
            };
            // Optional: Wire up an event in CustomerForm.cs like:
            // this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // 
            // btnCancel
            // 
            this.btnCancel = new Button
            {
                DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(376, 273),
                Name = "btnCancel",
                Size = new System.Drawing.Size(75, 34),
                TabIndex = 7,
                Text = "Cancel",
                UseVisualStyleBackColor = true
            };

            // 
            // txtCustomerName
            // 
            this.txtCustomerName = new TextBox
            {
                Location = new System.Drawing.Point(187, 40),
                Name = "txtCustomerName",
                Size = new System.Drawing.Size(264, 26),
                TabIndex = 1
            };

            // 
            // txtContactName
            // 
            this.txtContactName = new TextBox
            {
                Location = new System.Drawing.Point(187, 81),
                Name = "txtContactName",
                Size = new System.Drawing.Size(264, 26),
                TabIndex = 2
            };

            // 
            // txtPhone
            // 
            this.txtPhone = new MaskedTextBox
            {
                Location = new System.Drawing.Point(187, 126),
                Name = "txtPhone",
                Size = new System.Drawing.Size(264, 26),
                TabIndex = 3
            };

            // 
            // txtEmail
            // 
            this.txtEmail = new TextBox
            {
                Location = new System.Drawing.Point(187, 173),
                Name = "txtEmail",
                Size = new System.Drawing.Size(264, 26),
                TabIndex = 4
            };

            // 
            // txtId
            // 
            this.txtId = new TextBox
            {
                Location = new System.Drawing.Point(187, 8),
                Name = "txtId",
                ReadOnly = true,
                Size = new System.Drawing.Size(100, 26),
                TabIndex = 8,
                Visible = false
            };

            // 
            // chkIsActive
            // 
            this.chkIsActive = new CheckBox
            {
                Location = new System.Drawing.Point(187, 220),
                Name = "chkIsActive",
                Size = new System.Drawing.Size(85, 24),
                TabIndex = 5,
                Text = "Active?",
                UseVisualStyleBackColor = true
            };

            // 
            // CustomerForm
            // 
            this.AcceptButton = this.btnAdd;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(488, 325);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtContactName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.chkIsActive);
            this.Name = "CustomerForm";
            this.Text = "Add Customer";

            // 
            // Resume layout
            // 
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

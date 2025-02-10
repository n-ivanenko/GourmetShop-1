namespace GourmetShop.CustomerView
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvProd = new System.Windows.Forms.DataGridView();
            this.cmsProd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMyCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.cmsCart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteFromCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).BeginInit();
            this.cmsProd.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.cmsCart.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProd
            // 
            this.dgvProd.AllowUserToAddRows = false;
            this.dgvProd.AllowUserToDeleteRows = false;
            this.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd.ContextMenuStrip = this.cmsProd;
            this.dgvProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProd.Location = new System.Drawing.Point(0, 33);
            this.dgvProd.Name = "dgvProd";
            this.dgvProd.ReadOnly = true;
            this.dgvProd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvProd.RowTemplate.Height = 28;
            this.dgvProd.Size = new System.Drawing.Size(1156, 574);
            this.dgvProd.TabIndex = 0;
            this.dgvProd.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvCart_CellContextMenuStripNeeded);
            // 
            // cmsProd
            // 
            this.cmsProd.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsProd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToCartToolStripMenuItem});
            this.cmsProd.Name = "cmsProd";
            this.cmsProd.Size = new System.Drawing.Size(178, 36);
            // 
            // addToCartToolStripMenuItem
            // 
            this.addToCartToolStripMenuItem.Name = "addToCartToolStripMenuItem";
            this.addToCartToolStripMenuItem.Size = new System.Drawing.Size(177, 32);
            this.addToCartToolStripMenuItem.Text = "Add to Cart";
            this.addToCartToolStripMenuItem.Click += new System.EventHandler(this.addToCartToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.myCartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(148, 34);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewProductsToolStripMenuItem});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // viewProductsToolStripMenuItem
            // 
            this.viewProductsToolStripMenuItem.Name = "viewProductsToolStripMenuItem";
            this.viewProductsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.viewProductsToolStripMenuItem.Text = "View Products";
            this.viewProductsToolStripMenuItem.Click += new System.EventHandler(this.viewProductsToolStripMenuItem_Click);
            // 
            // myCartToolStripMenuItem
            // 
            this.myCartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMyCartToolStripMenuItem,
            this.checkoutToolStripMenuItem});
            this.myCartToolStripMenuItem.Name = "myCartToolStripMenuItem";
            this.myCartToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.myCartToolStripMenuItem.Text = "My Cart";
            // 
            // viewMyCartToolStripMenuItem
            // 
            this.viewMyCartToolStripMenuItem.Name = "viewMyCartToolStripMenuItem";
            this.viewMyCartToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.viewMyCartToolStripMenuItem.Text = "View My Cart";
            this.viewMyCartToolStripMenuItem.Click += new System.EventHandler(this.viewMyCartToolStripMenuItem_Click);
            // 
            // checkoutToolStripMenuItem
            // 
            this.checkoutToolStripMenuItem.Name = "checkoutToolStripMenuItem";
            this.checkoutToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.checkoutToolStripMenuItem.Text = "Checkout";
            this.checkoutToolStripMenuItem.Click += new System.EventHandler(this.checkoutToolStripMenuItem_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.ContextMenuStrip = this.cmsCart;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(0, 33);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersWidth = 62;
            this.dgvCart.RowTemplate.Height = 28;
            this.dgvCart.Size = new System.Drawing.Size(1156, 574);
            this.dgvCart.TabIndex = 2;
            this.dgvCart.Visible = false;
            this.dgvCart.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvCart_CellContextMenuStripNeeded);
            this.dgvCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            // 
            // cmsCart
            // 
            this.cmsCart.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsCart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteFromCartToolStripMenuItem});
            this.cmsCart.Name = "cmsCart";
            this.cmsCart.Size = new System.Drawing.Size(219, 36);
            // 
            // deleteFromCartToolStripMenuItem
            // 
            this.deleteFromCartToolStripMenuItem.Name = "deleteFromCartToolStripMenuItem";
            this.deleteFromCartToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
            this.deleteFromCartToolStripMenuItem.Text = "Delete From Cart";
            this.deleteFromCartToolStripMenuItem.Click += new System.EventHandler(this.deleteFromCartToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 607);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.dgvProd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Gourmet Shop";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).EndInit();
            this.cmsProd.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.cmsCart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMyCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkoutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.ContextMenuStrip cmsCart;
        private System.Windows.Forms.ToolStripMenuItem deleteFromCartToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsProd;
        private System.Windows.Forms.ToolStripMenuItem addToCartToolStripMenuItem;
    }
}


namespace InvoiceManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            customerToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem = new ToolStripMenuItem();
            invoicesToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            pnlMenu = new Panel();
            btnExit = new Button();
            btnSettings = new Button();
            btnInvoices = new Button();
            btnProducts = new Button();
            btnCustomers = new Button();
            pnlContent = new Panel();
            panel2 = new Panel();
            lblRevenueCount = new Label();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            panel1 = new Panel();
            lblProductsCount = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            lblInvoicesCount = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            pnlOverviewCustomers = new Panel();
            lblCustomersCount = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblOverview = new Label();
            menuStrip1.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlOverviewCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1125, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerToolStripMenuItem, productsToolStripMenuItem, invoicesToolStripMenuItem, settingsToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(73, 29);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new Size(199, 34);
            customerToolStripMenuItem.Text = "Customers";
            customerToolStripMenuItem.Click += customerToolStripMenuItem_Click;
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(199, 34);
            productsToolStripMenuItem.Text = "Products";
            productsToolStripMenuItem.Click += productsToolStripMenuItem_Click;
            // 
            // invoicesToolStripMenuItem
            // 
            invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            invoicesToolStripMenuItem.Size = new Size(199, 34);
            invoicesToolStripMenuItem.Text = "Invoices";
            invoicesToolStripMenuItem.Click += invoicesToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(199, 34);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlMenu.Controls.Add(btnExit);
            pnlMenu.Controls.Add(btnSettings);
            pnlMenu.Controls.Add(btnInvoices);
            pnlMenu.Controls.Add(btnProducts);
            pnlMenu.Controls.Add(btnCustomers);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 33);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(220, 496);
            pnlMenu.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.White;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 115, 240);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F);
            btnExit.Location = new Point(15, 376);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(15, 5, 15, 5);
            btnExit.Size = new Size(180, 70);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.White;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 115, 240);
            btnSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F);
            btnSettings.Location = new Point(15, 285);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 5, 15, 5);
            btnSettings.Size = new Size(180, 70);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnInvoices
            // 
            btnInvoices.BackColor = Color.White;
            btnInvoices.FlatAppearance.BorderSize = 0;
            btnInvoices.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 115, 240);
            btnInvoices.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btnInvoices.FlatStyle = FlatStyle.Flat;
            btnInvoices.Font = new Font("Segoe UI", 12F);
            btnInvoices.Location = new Point(15, 195);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Padding = new Padding(15, 5, 15, 5);
            btnInvoices.Size = new Size(180, 70);
            btnInvoices.TabIndex = 2;
            btnInvoices.Text = "Invoices";
            btnInvoices.UseVisualStyleBackColor = false;
            btnInvoices.Click += btnInvoices_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.White;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 115, 240);
            btnProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 12F);
            btnProducts.Location = new Point(15, 105);
            btnProducts.Name = "btnProducts";
            btnProducts.Padding = new Padding(15, 5, 15, 5);
            btnProducts.Size = new Size(180, 70);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.White;
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 115, 240);
            btnCustomers.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI", 12F);
            btnCustomers.Location = new Point(15, 15);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(15, 5, 15, 5);
            btnCustomers.Size = new Size(180, 70);
            btnCustomers.TabIndex = 0;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // pnlContent
            // 
            pnlContent.BorderStyle = BorderStyle.FixedSingle;
            pnlContent.Controls.Add(panel2);
            pnlContent.Controls.Add(panel1);
            pnlContent.Controls.Add(panel3);
            pnlContent.Controls.Add(pnlOverviewCustomers);
            pnlContent.Controls.Add(lblOverview);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 33);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(905, 496);
            pnlContent.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblRevenueCount);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox4);
            panel2.Location = new Point(672, 105);
            panel2.Name = "panel2";
            panel2.Size = new Size(180, 150);
            panel2.TabIndex = 8;
            // 
            // lblRevenueCount
            // 
            lblRevenueCount.AutoSize = true;
            lblRevenueCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRevenueCount.Location = new Point(76, 68);
            lblRevenueCount.Name = "lblRevenueCount";
            lblRevenueCount.Size = new Size(33, 38);
            lblRevenueCount.TabIndex = 4;
            lblRevenueCount.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label4.Location = new Point(76, 13);
            label4.Name = "label4";
            label4.Size = new Size(66, 19);
            label4.TabIndex = 3;
            label4.Text = "Revenue";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(66, 66);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblProductsCount);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(246, 105);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 150);
            panel1.TabIndex = 6;
            // 
            // lblProductsCount
            // 
            lblProductsCount.AutoSize = true;
            lblProductsCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProductsCount.Location = new Point(76, 68);
            lblProductsCount.Name = "lblProductsCount";
            lblProductsCount.Size = new Size(33, 38);
            lblProductsCount.TabIndex = 4;
            lblProductsCount.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label2.Location = new Point(76, 13);
            label2.Name = "label2";
            label2.Size = new Size(68, 19);
            label2.TabIndex = 2;
            label2.Text = "Products";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(66, 66);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(lblInvoicesCount);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(460, 105);
            panel3.Name = "panel3";
            panel3.Size = new Size(180, 150);
            panel3.TabIndex = 7;
            // 
            // lblInvoicesCount
            // 
            lblInvoicesCount.AutoSize = true;
            lblInvoicesCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblInvoicesCount.Location = new Point(76, 68);
            lblInvoicesCount.Name = "lblInvoicesCount";
            lblInvoicesCount.Size = new Size(33, 38);
            lblInvoicesCount.TabIndex = 4;
            lblInvoicesCount.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label3.Location = new Point(76, 13);
            label3.Name = "label3";
            label3.Size = new Size(63, 19);
            label3.TabIndex = 3;
            label3.Text = "Invoices";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(66, 66);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pnlOverviewCustomers
            // 
            pnlOverviewCustomers.BackColor = Color.White;
            pnlOverviewCustomers.Controls.Add(lblCustomersCount);
            pnlOverviewCustomers.Controls.Add(label1);
            pnlOverviewCustomers.Controls.Add(pictureBox1);
            pnlOverviewCustomers.Location = new Point(34, 105);
            pnlOverviewCustomers.Name = "pnlOverviewCustomers";
            pnlOverviewCustomers.Size = new Size(180, 150);
            pnlOverviewCustomers.TabIndex = 5;
            // 
            // lblCustomersCount
            // 
            lblCustomersCount.AutoSize = true;
            lblCustomersCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCustomersCount.Location = new Point(76, 68);
            lblCustomersCount.Name = "lblCustomersCount";
            lblCustomersCount.Size = new Size(33, 38);
            lblCustomersCount.TabIndex = 3;
            lblCustomersCount.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label1.Location = new Point(76, 13);
            label1.Name = "label1";
            label1.Size = new Size(79, 19);
            label1.TabIndex = 1;
            label1.Text = "Customers";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.iconCustomer;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 66);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblOverview
            // 
            lblOverview.AutoSize = true;
            lblOverview.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOverview.Location = new Point(34, 15);
            lblOverview.Name = "lblOverview";
            lblOverview.Size = new Size(140, 38);
            lblOverview.TabIndex = 3;
            lblOverview.Text = "Overview";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 529);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "InvoiceManager";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlOverviewCustomers.ResumeLayout(false);
            pnlOverviewCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem customerToolStripMenuItem;
        private ToolStripMenuItem invoicesToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Panel pnlMenu;
        private Panel pnlContent;
        private Button btnCustomers;
        private Button btnProducts;
        private Button btnSettings;
        private Button btnInvoices;
        private Button btnExit;
        private Label lblOverview;
        private Panel panel1;
        private Panel pnlOverviewCustomers;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblCustomersCount;
        private Label lblRevenueCount;
        private Label lblProductsCount;
        private Label lblInvoicesCount;
    }
}

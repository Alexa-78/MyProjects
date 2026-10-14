namespace InvoiceManager.Forms
{
    partial class CustomerForm
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
            tlpMain = new TableLayoutPanel();
            tlpInput = new TableLayoutPanel();
            txtEmail = new TextBox();
            txtCity = new TextBox();
            txtZip = new TextBox();
            txtStreet = new TextBox();
            txtContact = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtCompany = new TextBox();
            panel1 = new Panel();
            btnDelete = new Button();
            btnSave = new Button();
            btnNew = new Button();
            dgvCustomers = new DataGridView();
            tlpMain.SuspendLayout();
            tlpInput.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(tlpInput, 0, 0);
            tlpMain.Controls.Add(panel1, 0, 1);
            tlpMain.Controls.Add(dgvCustomers, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1191, 597);
            tlpMain.TabIndex = 0;
            // 
            // tlpInput
            // 
            tlpInput.ColumnCount = 3;
            tlpInput.ColumnStyles.Add(new ColumnStyle());
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpInput.Controls.Add(txtEmail, 1, 5);
            tlpInput.Controls.Add(txtCity, 1, 4);
            tlpInput.Controls.Add(txtZip, 1, 3);
            tlpInput.Controls.Add(txtStreet, 1, 2);
            tlpInput.Controls.Add(txtContact, 1, 1);
            tlpInput.Controls.Add(label1, 0, 0);
            tlpInput.Controls.Add(label2, 0, 1);
            tlpInput.Controls.Add(label3, 0, 2);
            tlpInput.Controls.Add(label4, 0, 3);
            tlpInput.Controls.Add(label5, 0, 4);
            tlpInput.Controls.Add(label6, 0, 5);
            tlpInput.Controls.Add(txtCompany, 1, 0);
            tlpInput.Dock = DockStyle.Top;
            tlpInput.Location = new Point(3, 3);
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(10);
            tlpInput.RowCount = 6;
            tlpInput.RowStyles.Add(new RowStyle());
            tlpInput.RowStyles.Add(new RowStyle());
            tlpInput.RowStyles.Add(new RowStyle());
            tlpInput.RowStyles.Add(new RowStyle());
            tlpInput.RowStyles.Add(new RowStyle());
            tlpInput.RowStyles.Add(new RowStyle());
            tlpInput.Size = new Size(1185, 232);
            tlpInput.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(108, 198);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(422, 31);
            txtEmail.TabIndex = 7;
            // 
            // txtCity
            // 
            txtCity.Dock = DockStyle.Fill;
            txtCity.Location = new Point(108, 161);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(422, 31);
            txtCity.TabIndex = 7;
            // 
            // txtZip
            // 
            txtZip.Dock = DockStyle.Fill;
            txtZip.Location = new Point(108, 124);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(422, 31);
            txtZip.TabIndex = 7;
            // 
            // txtStreet
            // 
            txtStreet.Dock = DockStyle.Fill;
            txtStreet.Location = new Point(108, 87);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(422, 31);
            txtStreet.TabIndex = 7;
            // 
            // txtContact
            // 
            txtContact.Dock = DockStyle.Fill;
            txtContact.Location = new Point(108, 50);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(422, 31);
            txtContact.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 0;
            label1.Text = "Company";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 47);
            label2.Name = "label2";
            label2.Size = new Size(73, 25);
            label2.TabIndex = 1;
            label2.Text = "Contact";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 84);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 2;
            label3.Text = "Street";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 121);
            label4.Name = "label4";
            label4.Size = new Size(37, 25);
            label4.TabIndex = 3;
            label4.Text = "ZIP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 158);
            label5.Name = "label5";
            label5.Size = new Size(42, 25);
            label5.TabIndex = 4;
            label5.Text = "City";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 195);
            label6.Name = "label6";
            label6.Size = new Size(54, 25);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // txtCompany
            // 
            txtCompany.Dock = DockStyle.Fill;
            txtCompany.Location = new Point(108, 13);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(422, 31);
            txtCompany.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnNew);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 241);
            panel1.Name = "panel1";
            panel1.Size = new Size(1185, 53);
            panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(443, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(276, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(111, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(120, 40);
            btnNew.TabIndex = 0;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(3, 300);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 62;
            dgvCustomers.Size = new Size(1185, 294);
            dgvCustomers.TabIndex = 2;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 597);
            Controls.Add(tlpMain);
            Name = "CustomerForm";
            Text = "Customers";
            Load += CustomerForm_Load;
            tlpMain.ResumeLayout(false);
            tlpInput.ResumeLayout(false);
            tlpInput.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tlpInput;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtCompany;
        private TextBox txtEmail;
        private TextBox txtCity;
        private TextBox txtZip;
        private TextBox txtStreet;
        private TextBox txtContact;
        private Panel panel1;
        private Button btnNew;
        private DataGridView dgvCustomers;
        private Button btnSave;
        private Button btnDelete;
    }
}
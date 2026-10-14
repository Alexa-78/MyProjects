namespace InvoiceManager.Forms
{
    partial class InvoiceForm
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
            tlpInvoice = new TableLayoutPanel();
            grpbxInvoice = new GroupBox();
            txtInvoiceNumber = new TextBox();
            dtInvoiceDate = new DateTimePicker();
            lblDate = new Label();
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            grpbxAddPosition = new GroupBox();
            btnAddPosition = new Button();
            nudQuantity = new NumericUpDown();
            lblAmount = new Label();
            cmbProduct = new ComboBox();
            lblProduct = new Label();
            dgvItems = new DataGridView();
            pnlSum = new Panel();
            lblGross = new Label();
            label5 = new Label();
            lblVat = new Label();
            label3 = new Label();
            lblNet = new Label();
            label1 = new Label();
            pnlButtons = new Panel();
            btnSave = new Button();
            btnNew = new Button();
            tlpInvoice.SuspendLayout();
            grpbxInvoice.SuspendLayout();
            grpbxAddPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            pnlSum.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlpInvoice
            // 
            tlpInvoice.ColumnCount = 1;
            tlpInvoice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpInvoice.Controls.Add(grpbxInvoice, 0, 0);
            tlpInvoice.Controls.Add(grpbxAddPosition, 0, 1);
            tlpInvoice.Controls.Add(dgvItems, 0, 2);
            tlpInvoice.Controls.Add(pnlSum, 0, 3);
            tlpInvoice.Controls.Add(pnlButtons, 0, 4);
            tlpInvoice.Dock = DockStyle.Fill;
            tlpInvoice.Location = new Point(0, 0);
            tlpInvoice.Name = "tlpInvoice";
            tlpInvoice.RowCount = 5;
            tlpInvoice.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpInvoice.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpInvoice.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlpInvoice.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpInvoice.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpInvoice.Size = new Size(1191, 597);
            tlpInvoice.TabIndex = 0;
            // 
            // grpbxInvoice
            // 
            grpbxInvoice.Controls.Add(txtInvoiceNumber);
            grpbxInvoice.Controls.Add(dtInvoiceDate);
            grpbxInvoice.Controls.Add(lblDate);
            grpbxInvoice.Controls.Add(lblCustomer);
            grpbxInvoice.Controls.Add(cmbCustomer);
            grpbxInvoice.Dock = DockStyle.Fill;
            grpbxInvoice.Location = new Point(3, 3);
            grpbxInvoice.Name = "grpbxInvoice";
            grpbxInvoice.Size = new Size(1185, 113);
            grpbxInvoice.TabIndex = 0;
            grpbxInvoice.TabStop = false;
            grpbxInvoice.Text = "Invoice";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(892, 17);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(239, 31);
            txtInvoiceNumber.TabIndex = 5;
            // 
            // dtInvoiceDate
            // 
            dtInvoiceDate.Location = new Point(369, 67);
            dtInvoiceDate.Name = "dtInvoiceDate";
            dtInvoiceDate.Size = new Size(300, 31);
            dtInvoiceDate.TabIndex = 4;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(369, 36);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(49, 25);
            lblDate.TabIndex = 3;
            lblDate.Text = "Date";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(17, 34);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(89, 25);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Customer";
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(17, 65);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(300, 33);
            cmbCustomer.TabIndex = 0;
            // 
            // grpbxAddPosition
            // 
            grpbxAddPosition.Controls.Add(btnAddPosition);
            grpbxAddPosition.Controls.Add(nudQuantity);
            grpbxAddPosition.Controls.Add(lblAmount);
            grpbxAddPosition.Controls.Add(cmbProduct);
            grpbxAddPosition.Controls.Add(lblProduct);
            grpbxAddPosition.Dock = DockStyle.Fill;
            grpbxAddPosition.Location = new Point(3, 122);
            grpbxAddPosition.Name = "grpbxAddPosition";
            grpbxAddPosition.Size = new Size(1185, 83);
            grpbxAddPosition.TabIndex = 1;
            grpbxAddPosition.TabStop = false;
            grpbxAddPosition.Text = "Add Position";
            // 
            // btnAddPosition
            // 
            btnAddPosition.Location = new Point(626, 35);
            btnAddPosition.Name = "btnAddPosition";
            btnAddPosition.Size = new Size(141, 34);
            btnAddPosition.TabIndex = 5;
            btnAddPosition.Text = "Add Position";
            btnAddPosition.UseVisualStyleBackColor = true;
            btnAddPosition.Click += btnAddPosition_Click;
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(417, 39);
            nudQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(129, 31);
            nudQuantity.TabIndex = 4;
            nudQuantity.ThousandsSeparator = true;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(324, 40);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(77, 25);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "Amount";
            // 
            // cmbProduct
            // 
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(108, 37);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(182, 33);
            cmbProduct.TabIndex = 1;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(15, 39);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(74, 25);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Product";
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Dock = DockStyle.Fill;
            dgvItems.Location = new Point(3, 211);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersWidth = 62;
            dgvItems.Size = new Size(1185, 262);
            dgvItems.TabIndex = 2;
            // 
            // pnlSum
            // 
            pnlSum.Controls.Add(lblGross);
            pnlSum.Controls.Add(label5);
            pnlSum.Controls.Add(lblVat);
            pnlSum.Controls.Add(label3);
            pnlSum.Controls.Add(lblNet);
            pnlSum.Controls.Add(label1);
            pnlSum.Dock = DockStyle.Fill;
            pnlSum.Location = new Point(3, 479);
            pnlSum.Name = "pnlSum";
            pnlSum.Size = new Size(1185, 53);
            pnlSum.TabIndex = 3;
            // 
            // lblGross
            // 
            lblGross.BackColor = Color.White;
            lblGross.Location = new Point(617, 15);
            lblGross.Name = "lblGross";
            lblGross.Size = new Size(59, 25);
            lblGross.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(508, 13);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 4;
            label5.Text = "GrossTotal";
            // 
            // lblVat
            // 
            lblVat.BackColor = Color.White;
            lblVat.Location = new Point(367, 15);
            lblVat.Name = "lblVat";
            lblVat.Size = new Size(59, 25);
            lblVat.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(258, 13);
            label3.Name = "label3";
            label3.Size = new Size(37, 25);
            label3.TabIndex = 2;
            label3.Text = "Vat";
            // 
            // lblNet
            // 
            lblNet.BackColor = Color.White;
            lblNet.Location = new Point(124, 13);
            lblNet.Name = "lblNet";
            lblNet.Size = new Size(59, 25);
            lblNet.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 0;
            label1.Text = "NetTotal";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnNew);
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.Location = new Point(3, 538);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1185, 56);
            pnlButtons.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(163, 14);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(32, 14);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(112, 34);
            btnNew.TabIndex = 0;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 597);
            Controls.Add(tlpInvoice);
            Name = "InvoiceForm";
            Text = "Invoice";
            Load += InvoiceForm_Load;
            tlpInvoice.ResumeLayout(false);
            grpbxInvoice.ResumeLayout(false);
            grpbxInvoice.PerformLayout();
            grpbxAddPosition.ResumeLayout(false);
            grpbxAddPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            pnlSum.ResumeLayout(false);
            pnlSum.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpInvoice;
        private GroupBox grpbxInvoice;
        private GroupBox grpbxAddPosition;
        private DataGridView dgvItems;
        private Panel pnlSum;
        private Panel pnlButtons;
        private ComboBox cmbCustomer;
        private Label lblCustomer;
        private Label lblDate;
        private DateTimePicker dtInvoiceDate;
        private TextBox txtInvoiceNumber;
        private ComboBox cmbProduct;
        private Label lblProduct;
        private NumericUpDown nudQuantity;
        private Label lblAmount;
        private Button btnAddPosition;
        private Button btnNew;
        private Button btnSave;
        private Label lblNet;
        private Label label1;
        private Label lblGross;
        private Label label5;
        private Label lblVat;
        private Label label3;
    }
}
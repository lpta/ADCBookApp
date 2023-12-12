namespace ADCBookApp
{
    partial class AddEditOrderFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditOrderFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddNewOrder = new System.Windows.Forms.Button();
            this.txtIdOrder = new System.Windows.Forms.TextBox();
            this.txtOrderName = new System.Windows.Forms.TextBox();
            this.numericBillTotal = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericBillTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn hàng: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đơn hàng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tổng thanh toán:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(262, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnAddNewOrder
            // 
            this.btnAddNewOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewOrder.Image")));
            this.btnAddNewOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewOrder.Location = new System.Drawing.Point(96, 384);
            this.btnAddNewOrder.Name = "btnAddNewOrder";
            this.btnAddNewOrder.Size = new System.Drawing.Size(132, 32);
            this.btnAddNewOrder.TabIndex = 8;
            this.btnAddNewOrder.Text = "Thêm mới";
            this.btnAddNewOrder.UseVisualStyleBackColor = true;
            this.btnAddNewOrder.Click += new System.EventHandler(this.BtnAddOrderClick);
            // 
            // txtIdOrder
            // 
            this.txtIdOrder.Enabled = false;
            this.txtIdOrder.Location = new System.Drawing.Point(192, 149);
            this.txtIdOrder.Name = "txtIdOrder";
            this.txtIdOrder.ReadOnly = true;
            this.txtIdOrder.Size = new System.Drawing.Size(201, 26);
            this.txtIdOrder.TabIndex = 10;
            this.txtIdOrder.Text = "0";
            // 
            // txtOrderName
            // 
            this.txtOrderName.Location = new System.Drawing.Point(192, 190);
            this.txtOrderName.Name = "txtOrderName";
            this.txtOrderName.Size = new System.Drawing.Size(201, 26);
            this.txtOrderName.TabIndex = 12;
            // 
            // numericBillTotal
            // 
            this.numericBillTotal.Location = new System.Drawing.Point(192, 232);
            this.numericBillTotal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericBillTotal.Name = "numericBillTotal";
            this.numericBillTotal.Size = new System.Drawing.Size(201, 26);
            this.numericBillTotal.TabIndex = 16;
            // 
            // AddEditOrderFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 441);
            this.Controls.Add(this.numericBillTotal);
            this.Controls.Add(this.txtOrderName);
            this.Controls.Add(this.txtIdOrder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewOrder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditOrderFrm";
            this.Text = "THÊM MỚI ĐƠN HÀNG";
            ((System.ComponentModel.ISupportInitialize)(this.numericBillTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddNewOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtIdOrder;
        private System.Windows.Forms.TextBox txtOrderName;
        private System.Windows.Forms.NumericUpDown numericBillTotal;
    }
}
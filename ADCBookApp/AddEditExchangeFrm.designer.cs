namespace ADC
{
    partial class AddEditExchangeBookFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditExchangeBookFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddNewExchangeBook = new System.Windows.Forms.Button();
            this.txtIdBook = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExchangeName = new System.Windows.Forms.TextBox();
            this.txtExchangeStatus = new System.Windows.Forms.ComboBox();
            this.txtExchangeNumber = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtExchangeReason = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdExchangeBook = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sách:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng:";
            // 
            // btnAddNewExchangeBook
            // 
            this.btnAddNewExchangeBook.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewExchangeBook.Image")));
            this.btnAddNewExchangeBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewExchangeBook.Location = new System.Drawing.Point(80, 346);
            this.btnAddNewExchangeBook.Name = "btnAddNewExchangeBook";
            this.btnAddNewExchangeBook.Size = new System.Drawing.Size(146, 36);
            this.btnAddNewExchangeBook.TabIndex = 5;
            this.btnAddNewExchangeBook.Text = "Thêm mới";
            this.btnAddNewExchangeBook.UseVisualStyleBackColor = true;
            this.btnAddNewExchangeBook.Click += new System.EventHandler(this.BtnAddExchangeBookClick);
            // 
            // txtIdBook
            // 
            this.txtIdBook.Enabled = false;
            this.txtIdBook.Location = new System.Drawing.Point(191, 71);
            this.txtIdBook.Name = "txtIdBook";
            this.txtIdBook.ReadOnly = true;
            this.txtIdBook.Size = new System.Drawing.Size(265, 26);
            this.txtIdBook.TabIndex = 7;
            this.txtIdBook.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Trạng thái";
            // 
            // txtExchangeName
            // 
            this.txtExchangeName.Location = new System.Drawing.Point(191, 112);
            this.txtExchangeName.Name = "txtExchangeName";
            this.txtExchangeName.ReadOnly = true;
            this.txtExchangeName.Size = new System.Drawing.Size(265, 26);
            this.txtExchangeName.TabIndex = 10;
            // 
            // txtExchangeStatus
            // 
            this.txtExchangeStatus.FormattingEnabled = true;
            this.txtExchangeStatus.Items.AddRange(new object[] {
            "Chưa đổi",
            "Đã đổi",
            "Đã trả"});
            this.txtExchangeStatus.Location = new System.Drawing.Point(190, 249);
            this.txtExchangeStatus.Name = "txtExchangeStatus";
            this.txtExchangeStatus.Size = new System.Drawing.Size(265, 28);
            this.txtExchangeStatus.TabIndex = 13;
            // 
            // txtExchangeNumber
            // 
            this.txtExchangeNumber.Location = new System.Drawing.Point(190, 157);
            this.txtExchangeNumber.Name = "txtExchangeNumber";
            this.txtExchangeNumber.Size = new System.Drawing.Size(265, 26);
            this.txtExchangeNumber.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(279, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // txtExchangeReason
            // 
            this.txtExchangeReason.Location = new System.Drawing.Point(190, 201);
            this.txtExchangeReason.Name = "txtExchangeReason";
            this.txtExchangeReason.Size = new System.Drawing.Size(265, 26);
            this.txtExchangeReason.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Lý do đổi trả:";
            // 
            // txtIdExchangeBook
            // 
            this.txtIdExchangeBook.Enabled = false;
            this.txtIdExchangeBook.Location = new System.Drawing.Point(191, 32);
            this.txtIdExchangeBook.Name = "txtIdExchangeBook";
            this.txtIdExchangeBook.ReadOnly = true;
            this.txtIdExchangeBook.Size = new System.Drawing.Size(265, 26);
            this.txtIdExchangeBook.TabIndex = 19;
            this.txtIdExchangeBook.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mã đổi trả:";
            // 
            // AddEditExchangeBookFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 416);
            this.Controls.Add(this.txtIdExchangeBook);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtExchangeReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExchangeNumber);
            this.Controls.Add(this.txtExchangeStatus);
            this.Controls.Add(this.txtExchangeName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdBook);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewExchangeBook);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditExchangeBookFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM SÁCH CẦN ĐỔI TRẢ";
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddNewExchangeBook;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtIdBook;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExchangeName;
        private System.Windows.Forms.ComboBox txtExchangeStatus;
        private System.Windows.Forms.NumericUpDown txtExchangeNumber;
        private System.Windows.Forms.TextBox txtExchangeReason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdExchangeBook;
        private System.Windows.Forms.Label label5;
    }
}
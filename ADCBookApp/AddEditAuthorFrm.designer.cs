namespace ADCBookApp
{
    partial class AddEditAuthorFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditAuthorFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddNewAuthor = new System.Windows.Forms.Button();
            this.txtIdAuthor = new System.Windows.Forms.TextBox();
            this.txtAuthorName = new System.Windows.Forms.TextBox();
            this.birstYearAuthor = new System.Windows.Forms.DateTimePicker();
            this.txtHomeTown = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã tác giả: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tác giả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Năm sinh:";
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
            // btnAddNewAuthor
            // 
            this.btnAddNewAuthor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewAuthor.Image")));
            this.btnAddNewAuthor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewAuthor.Location = new System.Drawing.Point(96, 384);
            this.btnAddNewAuthor.Name = "btnAddNewAuthor";
            this.btnAddNewAuthor.Size = new System.Drawing.Size(132, 32);
            this.btnAddNewAuthor.TabIndex = 8;
            this.btnAddNewAuthor.Text = "Thêm mới";
            this.btnAddNewAuthor.UseVisualStyleBackColor = true;
            this.btnAddNewAuthor.Click += new System.EventHandler(this.BtnAddAuthorClick);
            // 
            // txtIdAuthor
            // 
            this.txtIdAuthor.Enabled = false;
            this.txtIdAuthor.Location = new System.Drawing.Point(193, 103);
            this.txtIdAuthor.Name = "txtIdAuthor";
            this.txtIdAuthor.Size = new System.Drawing.Size(201, 26);
            this.txtIdAuthor.TabIndex = 10;
            this.txtIdAuthor.Text = "0";
            // 
            // txtAuthorName
            // 
            this.txtAuthorName.Location = new System.Drawing.Point(193, 144);
            this.txtAuthorName.Name = "txtAuthorName";
            this.txtAuthorName.Size = new System.Drawing.Size(201, 26);
            this.txtAuthorName.TabIndex = 12;
            // 
            // birstYearAuthor
            // 
            this.birstYearAuthor.CustomFormat = "yyyy";
            this.birstYearAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birstYearAuthor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birstYearAuthor.Location = new System.Drawing.Point(192, 190);
            this.birstYearAuthor.Name = "birstYearAuthor";
            this.birstYearAuthor.ShowUpDown = true;
            this.birstYearAuthor.Size = new System.Drawing.Size(201, 26);
            this.birstYearAuthor.TabIndex = 15;
            // 
            // txtHomeTown
            // 
            this.txtHomeTown.Location = new System.Drawing.Point(193, 235);
            this.txtHomeTown.Name = "txtHomeTown";
            this.txtHomeTown.Size = new System.Drawing.Size(201, 26);
            this.txtHomeTown.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Quê quán:";
            // 
            // AddEditAuthorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 441);
            this.Controls.Add(this.txtHomeTown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.birstYearAuthor);
            this.Controls.Add(this.txtAuthorName);
            this.Controls.Add(this.txtIdAuthor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewAuthor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditAuthorFrm";
            this.Text = "THÊM MỚI TÁC GIẢ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddNewAuthor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtIdAuthor;
        private System.Windows.Forms.TextBox txtAuthorName;
        private System.Windows.Forms.DateTimePicker birstYearAuthor;
        private System.Windows.Forms.TextBox txtHomeTown;
        private System.Windows.Forms.Label label3;
    }
}
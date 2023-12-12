using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class AddEditTypeFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private Type type;

        public AddEditTypeFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditTypeFrm(Type _type = null) : this()
        {
            if (_type != null)
            {
                Text = "CẬP NHẬT THÔNG TIN TL SÁCH";
                btnAddNewType.Text = "Cập nhật";
                type = _type;
                ShowTypeData();
            }
        }

        private void ShowTypeData()
        {
            txtIdType.Text = $"{type.idType}";
            txtTypeName.Text = type.nameType;
        }

        private void BtnAddTypeClick(object sender, EventArgs e)
        {
            var typeId = int.Parse(txtIdType.Text);
            var typeName = txtTypeName.Text;
            try
            {
                if (string.IsNullOrEmpty(typeName))
                {
                    var msg = "Tên thể loại sách không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (btnAddNewType.Text.CompareTo("Cập nhật") == 0)
                {
                    type.idType = typeId;
                    type.nameType = typeName;
                    var msg = "Bạn có chắc chắn muốn lưu lại các thay đổi?";
                    var title = "Xác nhận cập nhật";
                    var ans = ShowConfirmMessage(title, msg);
                    if (ans == DialogResult.Yes)
                    {
                        HomeFrm.hform.UpdateType(type);
                        Dispose();
                    }
                }
                else // thêm mới NXB
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Type (nameType)" +
                        $"VALUES (N'" + typeName + "');";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowType();
                }
                this.Close();
            }
            catch (InvalidCompanyNameException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            var title = "Xác nhận";
            var message = "Bạn có chắc muốn hủy bỏ?";
            var ans = ShowConfirmMessage(title, message);
            if (ans == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private DialogResult ShowConfirmMessage(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}

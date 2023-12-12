using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class AddEditOrderFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private Order order;

        public AddEditOrderFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditOrderFrm(Order _order) : this()
        {
            if (_order.idOrder != 0)
            {
                Text = "CẬP NHẬT THÔNG TIN ĐƠN HÀNG";
                btnAddNewOrder.Text = "Cập nhật";
                order = _order;
                ShowOrderData();
            }
        }

        private void ShowOrderData()
        {
            txtIdOrder.Text = $"{order.idOrder}";
            txtOrderName.Text = order.nameOrder;
            numericBillTotal.Text = $"{order.BillTotal}";
        }

        private void BtnAddOrderClick(object sender, EventArgs e)
        {
            var OrderName = txtOrderName.Text;
            var OrderBillTotal = int.Parse(numericBillTotal.Text);
            var StatusOrder = "Chưa thanh toan";
            try
            {
                if (string.IsNullOrEmpty(OrderName))
                {
                    var msg = "Tên thể loại sách không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO [Order] (nameOrder, BillTotal, CreateDateOrder, StatusOrder)" +
                    $"VALUES (N'" + OrderName + "', " + OrderBillTotal + ", '" + DateTime.Now + "', '" + StatusOrder + "');";
                command.ExecuteNonQuery();
                HomeFrm.hform.ShowOrder();
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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class AddEditDiscountFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private Discount discount;

        public AddEditDiscountFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditDiscountFrm(Discount _discount = null) : this()
        {
            if (_discount != null)
            {
                Text = "CẬP NHẬT THÔNG TIN KHUYẾN MÃI";
                btnAddNew.Text = "Cập nhật";
                discount = _discount;
                ShowDiscountData();
            }
        }

        private void ShowDiscountData()
        {
            txtDiscountId.Text = $"{discount.idDiscount}";
            txtDiscountName.Text = discount.nameDiscount;
            dtPickerStart.Text = discount.StartDiscountDate.ToString();
            dtPickerEnd.Text = discount.EndDiscountDate.ToString();
            numericDiscountAmount.Text = discount.DiscountValue.ToString();
        }

        private void BtnAddDiscountClick(object sender, EventArgs e)
        {
            var discountId = int.Parse(txtDiscountId.Text);
            var discountName = txtDiscountName.Text;
            var discountStartDay = dtPickerStart.Value;
            var discountEndDay = dtPickerEnd.Value;
            var discountAmount = int.Parse(numericDiscountAmount.Text);
            try
            {
                if (string.IsNullOrEmpty(discountName))
                {
                    var msg = "Tên nhà xuất bản không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (btnAddNew.Text.CompareTo("Cập nhật") == 0)
                {
                    discount.idDiscount = discountId;
                    discount.nameDiscount = discountName;
                    discount.StartDiscountDate = discountStartDay;
                    discount.EndDiscountDate = discountEndDay;
                    discount.DiscountValue = discountAmount;
                    var msg = "Bạn có chắc chắn muốn lưu lại các thay đổi?";
                    var title = "Xác nhận cập nhật";
                    var ans = ShowConfirmMessage(title, msg);
                    if (ans == DialogResult.Yes)
                    {
                        HomeFrm.hform.UpdateDiscount(discount);
                        Dispose();
                    }
                }
                else
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Discount (nameDiscount, StartDiscountDate, EndDiscountDate, DiscountValue)" +
                        $"VALUES (N'" + discountName + "', '" + discountStartDay + "', '" + discountEndDay + "', " + discountAmount + ");";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowDiscount();
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

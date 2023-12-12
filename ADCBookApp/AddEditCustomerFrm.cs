using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class AddEditCustommerFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private Custommer custommer;

        public AddEditCustommerFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditCustommerFrm(Custommer _custommer = null) : this()
        {
            if (_custommer != null)
            {
                Text = "CẬP NHẬT THÔNG TIN KHÁCH HÀNG";
                btnAddNew.Text = "Cập nhật";
                custommer = _custommer;
                ShowCustommerData();
            }
        }

        private void ShowCustommerData()
        {
            txtCustomerId.Text = $"{custommer.idCustommer}";
            txtFullName.Text = custommer.nameCustommer;
            datePickerBirthDate.Text = custommer.BirstDay.ToString();
            txtAddress.Text = custommer.Address;
            txtPhoneNumber.Text = custommer.phoneNumber;
            txtEmail.Text = custommer.Email;
        }

        private void BtnAddCustommerClick(object sender, EventArgs e)
        {
            var custommerId = int.Parse(txtCustomerId.Text);
            var custommerName = txtFullName.Text;
            var custommerBirstDay = datePickerBirthDate.Value;
            var address = txtAddress.Text;
            var phoneNumber = txtPhoneNumber.Text;
            var email = txtEmail.Text;
            try
            {
                if (string.IsNullOrEmpty(custommerName))
                {
                    var msg = "Tên nhà xuất bản không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (btnAddNew.Text.CompareTo("Cập nhật") == 0)
                {
                    custommer.idCustommer = custommerId;
                    custommer.nameCustommer = custommerName;
                    custommer.BirstDay = custommerBirstDay;
                    custommer.Address = address;
                    custommer.phoneNumber = phoneNumber;
                    custommer.Email = email;
                    var msg = "Bạn có chắc chắn muốn lưu lại các thay đổi?";
                    var title = "Xác nhận cập nhật";
                    var ans = ShowConfirmMessage(title, msg);
                    if (ans == DialogResult.Yes)
                    {
                        HomeFrm.hform.UpdateCustommer(custommer);
                        Dispose();
                    }
                }
                else
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Custommer (nameCustommer, BirstDay, [Address], phoneNumber, Email, CreateAccount)" +
                        $"VALUES (N'" + custommerName + "', '" + custommerBirstDay + "', N'" + address + "', N'" + phoneNumber + "', N'" + email + "', '" + DateTime.Now.ToString("yyyy/MM/dd") + "');";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowCustommer();
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

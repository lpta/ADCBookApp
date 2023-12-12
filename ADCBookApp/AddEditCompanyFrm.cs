using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class AddEditCompanyFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private Company company;

        public AddEditCompanyFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditCompanyFrm(Company _company = null) : this()
        {
            if (_company != null)
            {
                Text = "CẬP NHẬT THÔNG TIN NXB";
                btnAddNew.Text = "Cập nhật";
                company = _company;
                ShowCompanyData();
            }
        }

        private void ShowCompanyData()
        {
            txtId.Text = $"{company.companyId}";
            txtCompanyName.Text = company.companyName;
            txtAddress.Text = company.address;
            txtPhoneNumber.Text = company.phoneNumber;
        }

        private void BtnAddCompanyClick(object sender, EventArgs e)
        {
            var companyId = int.Parse(txtId.Text);
            var companyName = txtCompanyName.Text;
            var address = txtAddress.Text;
            var phoneNumber = txtPhoneNumber.Text;
            try
            {
                if (string.IsNullOrEmpty(companyName))
                {
                    var msg = "Tên nhà xuất bản không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (string.IsNullOrEmpty(address))
                {
                    var msg = "Địa chỉ nhà xuất bản không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    var msg = "Số điện thoại nhà xuất bản không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (btnAddNew.Text.CompareTo("Cập nhật") == 0)
                {
                    company.companyId = companyId;
                    company.companyName = companyName;
                    company.address = address;
                    company.phoneNumber = phoneNumber;
                    var msg = "Bạn có chắc chắn muốn lưu lại các thay đổi?";
                    var title = "Xác nhận cập nhật";
                    var ans = ShowConfirmMessage(title, msg);
                    if (ans == DialogResult.Yes)
                    {
                        HomeFrm.hform.UpdateCompany(company);
                        Dispose();
                    }
                }
                else
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Company (nameCompany, addressCompany, phoneNumber)" +
                        $"VALUES (N'" + txtCompanyName.Text + "', N'" + txtAddress.Text + "', N'" + txtPhoneNumber.Text + "');";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowCompany();
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

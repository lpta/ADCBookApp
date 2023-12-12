using ADCBookApp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADC
{
    public partial class AddEditExchangeBookFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private ExchangeBook exchangeBook;

        public AddEditExchangeBookFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditExchangeBookFrm(ExchangeBook _exchangeBook) : this()
        {
            if (_exchangeBook.number != 0)
            {
                Text = "CẬP NHẬT THÔNG TIN SÁCH ĐỔI TRẢ";
                btnAddNewExchangeBook.Text = "Cập nhật";
                exchangeBook = _exchangeBook;
                ShowExchangeBookData();
            }
            else
            {
                exchangeBook = _exchangeBook;
                ShowExchangeBookData();
            }
        }

        private void ShowExchangeBookData()
        {
            txtIdExchangeBook.Text = $"{exchangeBook.idExchangeBook}";
            txtIdBook.Text = $"{exchangeBook.idBook}";
            txtExchangeName.Text = exchangeBook.nameBook;
            txtExchangeNumber.Text = $"{exchangeBook.number}";
            txtExchangeReason.Text = exchangeBook.reason;
            txtExchangeStatus.Text = exchangeBook.status;
        }

        private void BtnAddExchangeBookClick(object sender, EventArgs e)
        {
            var ExchangeBookId = int.Parse(txtIdExchangeBook.Text);
            var BookId = int.Parse(txtIdBook.Text);
            var ExchangeBookName = txtExchangeName.Text;
            var ExchangeBookNumber = int.Parse(txtExchangeNumber.Text);
            var ExchangeBookReason = txtExchangeReason.Text;
            var ExchangeBookStatus = txtExchangeStatus.Text;

            try
            {
                if (string.IsNullOrEmpty(ExchangeBookName))
                {
                    var msg = "Tên thể loại sách không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (btnAddNewExchangeBook.Text.CompareTo("Cập nhật") == 0)
                {
                    exchangeBook.idExchangeBook = ExchangeBookId;
                    exchangeBook.idBook = BookId;
                    exchangeBook.nameBook = ExchangeBookName;
                    exchangeBook.number = ExchangeBookNumber;
                    exchangeBook.reason = ExchangeBookReason;
                    exchangeBook.status = ExchangeBookStatus;
                    var msg = "Bạn có chắc chắn muốn lưu lại các thay đổi?";
                    var title = "Xác nhận cập nhật";
                    var ans = ShowConfirmMessage(title, msg);
                    if (ans == DialogResult.Yes)
                    {
                        HomeFrm.hform.UpdateExchangeBook(exchangeBook);
                        Dispose();
                    }
                }
                else if (ExchangeBookStatus == "Chưa đổi")
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO ExchangeBook (idBook, nameBook, number, reason, [status], startDay)" +
                        $"VALUES (" + BookId + ", N'" + ExchangeBookName + "', " + ExchangeBookNumber + ", N'" + ExchangeBookReason + "', N'" + ExchangeBookStatus + "', '" + DateTime.Now + "');";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowExchangeBook();
                }
                else
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO ExchangeBook (idBook, nameBook, number, reason, [status], startDay, endDay)" +
                        $"VALUES (" + BookId + ", N'" + ExchangeBookName + "', " + ExchangeBookNumber + ", N'" + ExchangeBookReason + "', N'" + ExchangeBookStatus + "', '" + DateTime.Now + "', '" + DateTime.Now + "');";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowExchangeBook();
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

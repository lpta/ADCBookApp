using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class AddEditBookFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private Book book;

        public AddEditBookFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public void AddEditBookFrmLoad(object sender, EventArgs e)
        {
            comboCompanyShow();
            comboTypeShow();
            comboAuthorShow();
        }

        public AddEditBookFrm(Book _book = null) : this()
        {
            if (_book != null)
            {
                Text = "CẬP NHẬT THÔNG TIN SÁCH";
                btnAddNewBook.Text = "Cập nhật";
                book = _book;
                ShowBookData();
            }
        }

        private void ShowBookData()
        {
            txtIdBook.Text = $"{book.idBook}";
            txtBookName.Text = book.nameBook;
            comboCompany.Text = book.nameCompany;
            comboType.Text = book.nameType;
            comboAuthor.Text = book.nameAuthor;
            numericNumber.Text = book.number.ToString();
            numericPrice.Text = book.price.ToString();
        }

        public void BtnAddBookClick(object sender, EventArgs e)
        {
            var bookId = int.Parse(txtIdBook.Text);
            var bookName = txtBookName.Text;
            var bookCompany = comboCompany.Text;
            var bookType = comboType.Text;
            var bookAuthor = comboAuthor.Text;
            var bookNumber = int.Parse(numericNumber.Text);
            var bookPrice = int.Parse(numericPrice.Text);
            try
            {
                if (string.IsNullOrEmpty(bookName))
                {
                    var msg = "Tên sách không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (btnAddNewBook.Text.CompareTo("Cập nhật") == 0)
                {
                    book.idBook = bookId;
                    book.nameBook = bookName;
                    book.nameCompany = bookCompany;
                    book.nameType = bookType;
                    book.nameAuthor = bookAuthor;
                    book.number = bookNumber;
                    book.price = bookPrice;
                    var msg = "Bạn có chắc chắn muốn lưu lại các thay đổi?";
                    var title = "Xác nhận cập nhật";
                    var ans = ShowConfirmMessage(title, msg);
                    if (ans == DialogResult.Yes)
                    {
                        HomeFrm.hform.UpdateBook(book);
                        Dispose();
                    }
                }
                else // thêm mới NXB
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Book (nameBook, nameCompany, nameAuthor, nameType, number, price)" +
                        $" VALUES (N'" + bookName + "', N'" + comboCompany.Text + "', N'" + comboAuthor.Text + "', N'" + comboType.Text + "', " + bookNumber + ", " + bookPrice + ");";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowBook();
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

        public void comboCompanyShow()
        {
            comboCompany.Items.Clear();
            foreach (Company i in HomeFrm.hform.getCompany())
            {
                comboCompany.Items.Add(i.companyName.ToString());
            }
        }
        public void comboTypeShow()
        {
            comboType.Items.Clear();
            foreach (Type i in HomeFrm.hform.getType())
            {
                comboType.Items.Add(i.nameType.ToString());
            }
        }
        public void comboAuthorShow()
        {
            comboAuthor.Items.Clear();
            foreach (Author i in HomeFrm.hform.getAuthor())
            {
                comboAuthor.Items.Add(i.authorName.ToString());
            }
        }


    }
}

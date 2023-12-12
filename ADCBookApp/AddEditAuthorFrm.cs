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
    public partial class AddEditAuthorFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private Author author;

        public AddEditAuthorFrm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public AddEditAuthorFrm(Author _author = null) : this()
        {
            if (_author != null)
            {
                Text = "CẬP NHẬT THÔNG TIN TÁC GIẢ";
                btnAddNewAuthor.Text = "Cập nhật";
                author = _author;
                ShowAuthorData();
            }
        }

        private void ShowAuthorData()
        {
            txtIdAuthor.Text = $"{author.authorId}";
            txtAuthorName.Text = author.authorName;
            birstYearAuthor.Value = DateTime.ParseExact(author.birstYear.ToString(), "yyyy", CultureInfo.InvariantCulture);
            txtHomeTown.Text = author.homeTown;
        }

        private void BtnAddAuthorClick(object sender, EventArgs e)
        {
            var authorId = int.Parse(txtIdAuthor.Text);
            var authorName = txtAuthorName.Text;
            var authorBirstYear = birstYearAuthor.Text;
            var authorHomeTown = txtHomeTown.Text;
            try
            {
                if (string.IsNullOrEmpty(authorName))
                {
                    var msg = "Tên tác giả không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (string.IsNullOrEmpty(authorBirstYear))
                {
                    var msg = "Năm sinh tác giả không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (string.IsNullOrEmpty(authorHomeTown))
                {
                    var msg = "Quê quán tác giả không được để trống.";
                    throw new InvalidCompanyNameException(msg);
                }
                if (btnAddNewAuthor.Text.CompareTo("Cập nhật") == 0)
                {
                    author.authorId = authorId;
                    author.authorName = authorName;
                    author.birstYear = Int32.Parse(authorBirstYear);
                    author.homeTown = authorHomeTown;
                    var msg = "Bạn có chắc chắn muốn lưu lại các thay đổi?";
                    var title = "Xác nhận cập nhật";
                    var ans = ShowConfirmMessage(title, msg);
                    if (ans == DialogResult.Yes)
                    {
                        HomeFrm.hform.UpdateAuthor(author);
                        Dispose();
                    }
                }
                else // thêm mới NXB
                {
                    //author = new Author(authorName, Int32.Parse(authorBirstYear), authorHomeTown);
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Author (nameAuthor, birthYear, homeTown)" +
                        $"VALUES (N'" + authorName + "', N'" + authorBirstYear + "', N'" + authorHomeTown + "');";
                    command.ExecuteNonQuery();
                    HomeFrm.hform.ShowAuthor();
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class AddEditBillFrm : Form
    {

        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        int idBill;

        Custommer custommer = new Custommer();
        List<Custommer> custommers;
        List<BookDetal> bookDetals;
        BookDetal bookDetal = new BookDetal();
        public AddEditBillFrm(int id)
        {
            InitializeComponent();
            CenterToParent();
            idBill = id;
        }

        private void ShowSearchedCustommer(List<Custommer> custommers)
        {
            tblSearchedCustomer.Rows.Clear();
            foreach (Custommer i in custommers)
            {
                tblSearchedCustomer.Rows.Add(new object[]
                {
                    i.idCustommer, i.nameCustommer
                });
            }
        }

        private void btnSearchCustomerClick(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Custommer WHERE nameCustommer LIKE N'%" + txtSearchCustomer.Text + "%';";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            custommers = new List<Custommer>();
            HomeFrm.ConvertDataTableCustommer(custommers, table);
            if (custommers.Count == 0)
            {
                var msg = "Không tìm thấy kết quả nào.";
                var title = "Kết quả tìm kiếm";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowSearchedCustommer(custommers);
            }
        }

        public void ShowTotalInfo(int Item, int PriceDiscount, int Price)
        {
            labelTotalItem.Text = $"Tổng SP: {Item:N0}sp";
            labelTotalDiscount.Text = $"Tổng KM: {PriceDiscount:N0}đ";
            labelTotalAmount.Text = $"Tổng tiền: {Price:N0}đ";
        }

        private void tblSearchedCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblSearchedCustomer.Columns["tblCustomerColSelect"].Index)
            {
                custommer.idCustommer = Int32.Parse(tblSearchedCustomer.Rows[tblSearchedCustomer.CurrentRow.Index].Cells[0].Value.ToString());
                custommer.nameCustommer = tblSearchedCustomer.Rows[tblSearchedCustomer.CurrentRow.Index].Cells[1].Value.ToString();
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "UPDATE Bill SET nameCustommer = N'" + custommer.nameCustommer + "' WHERE idBill = " + idBill + "";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                labelCustomerName.Text = $"Tên KH: {custommer.nameCustommer}";
            }
        }

        private void ShowSearchedListSearchedBillBook(List<BookDetal> listSearchedBillBooks)
        {
            tblSearchedBook.Rows.Clear();
            foreach (BookDetal i in listSearchedBillBooks)
            {
                tblSearchedBook.Rows.Add(new object[]
                {
                    i.idBook, i.nameBook, i.numberBook
                });
            }
        }

        private int getDiscountValue()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT CreateDate FROM Bill WHERE idBill = " + idBill + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            DateTime dateBill = DateTime.Parse(table.Rows[0]["CreateDate"].ToString());
            foreach (Discount i in HomeFrm.hform.ShowListDiscount())
            {
                if (i.StartDiscountDate <= dateBill && dateBill <= i.EndDiscountDate)
                {
                    return i.DiscountValue;
                }
            }
            return 0;
        }

        private void ShowBillBook()
        {
            int Item = 0;
            int DiscountPrice;
            int Price = 0;
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT BillBook.idBook, Book.nameBook, BillBook.numberBook, Book.price FROM BillBook, Bill, Book WHERE BillBook.idBook = Book.idBook AND BillBook.idBill = Bill.idBill AND Bill.idBill = " + idBill + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            bookDetals = new List<BookDetal>();
            tblBillDetail.Rows.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tblBillDetail.Rows.Add(new object[]
                {
                    Convert.ToInt32(table.Rows[i]["idBook"]), table.Rows[i]["nameBook"].ToString(), Convert.ToInt32(table.Rows[i]["numberBook"]), Convert.ToInt32(table.Rows[i]["price"])
                });
                Item += Convert.ToInt32(table.Rows[i]["numberBook"]);
                Price += Convert.ToInt32(table.Rows[i]["numberBook"]) * Convert.ToInt32(table.Rows[i]["price"]);
            }
            connection.Close();
            int valueDiscount = getDiscountValue();
            DiscountPrice = (Price * valueDiscount) / 100;
            Price -= DiscountPrice;
            command.CommandText = "UPDATE Bill SET DiscountValue = " + valueDiscount + ", TotalPriceDiscount = " + DiscountPrice + ", PayTotal = " + Price + " WHERE idBill = " + idBill + "";
            command.ExecuteNonQuery();
            ShowTotalInfo(Item, DiscountPrice, Price);
        }

        private void btnSearchBookClick(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT idBook, nameBook, number, price FROM Book WHERE nameBook LIKE N'%" + txtSearchBook.Text + "%';";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            bookDetals = new List<BookDetal>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                BookDetal book = new BookDetal();
                book.idBook = Convert.ToInt32(table.Rows[i]["idBook"]);
                book.nameBook = table.Rows[i]["nameBook"].ToString();
                book.numberBook = Convert.ToInt32(table.Rows[i]["number"]);
                book.price = Convert.ToInt32(table.Rows[i]["price"]);
                bookDetals.Add(book);
            }
            if (bookDetals.Count == 0)
            {
                var msg = "Không tìm thấy kết quả nào.";
                var title = "Kết quả tìm kiếm";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowSearchedListSearchedBillBook(bookDetals);
            }
        }

        private void tblSearchedBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblSearchedBook.Columns["tblBookColSelect"].Index)
            {
                bookDetal.idBook = Int32.Parse(tblSearchedBook.Rows[tblSearchedBook.CurrentRow.Index].Cells[0].Value.ToString());
                bookDetal.nameBook = tblSearchedBook.Rows[tblSearchedBook.CurrentRow.Index].Cells[1].Value.ToString();
                bookDetal.numberBook = Int32.Parse(tblSearchedBook.Rows[tblSearchedBook.CurrentRow.Index].Cells[2].Value.ToString());
            }
        }

        private void btnUpdateSelectedBillBookClick(object sender, EventArgs e)
        {
            if (bookDetal.idBook != 0)
            {
                var newValue = (int)numericSelectedQuantity.Value;
                if (newValue == 0)
                {
                    ShowErrorNumberOfSelectedItem();
                }
                else
                {
                    if (newValue > bookDetal.numberBook)
                    {
                        var title = "Lỗi dữ liệu";
                        var msg = "Số lượng sách cần mua vượt quá số lượng hiện có.";
                        MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bookDetal.numberBook = newValue;

                        connection = new SqlConnection(str);
                        connection.Open();
                        command = connection.CreateCommand();
                        command.CommandText = "INSERT INTO BillBook VALUES (" + idBill + ", " + bookDetal.idBook + ", " + bookDetal.numberBook + ")";
                        adapter.SelectCommand = command;
                        table.Clear();
                        adapter.Fill(table);

                        ShowBillBook();

                        var msg = $"Cập nhật vào hoá đơn thành công.";
                        var title = "Cập nhật thành công";
                        MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ShowErrorNumberOfSelectedItem()
        {
            var title = "Lỗi dữ liệu";
            var msg = "Vui lòng nhập số sách khách chọn khác 0";
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            var tilte = "Xác nhận hủy hóa đơn";
            var msg = "Bạn có chắc muốn hủy bỏ hóa đơn này không?";
            var ans = MessageBox.Show(msg, tilte, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM BillBook WHERE idBill = " + idBill + ";";
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Bill WHERE idBill = " + idBill + ";";
                command.ExecuteNonQuery();
                Dispose();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT idBook, numberBook FROM BillBook WHERE idBill = " + idBill + ";";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                command.CommandText = "UPDATE Book SET number -= " + Convert.ToInt32(table.Rows[i]["numberBook"]) + " WHERE idBook = " + Convert.ToInt32(table.Rows[i]["idBook"]) + "";
                command.ExecuteNonQuery();
            }
            command.CommandText = "UPDATE Bill SET [status] = N'Đã thanh toán' WHERE idBill = " + idBill + "";
            command.ExecuteNonQuery();
            HomeFrm.hform.ShowBill();
            Dispose();
        }

        private void btnNonPayClick(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT idBook, numberBook FROM BillBook WHERE idBill = " + idBill + ";";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                command.CommandText = "UPDATE Book SET number -= " + Convert.ToInt32(table.Rows[i]["numberBook"]) + " WHERE idBook = " + Convert.ToInt32(table.Rows[i]["idBook"]) + "";
                command.ExecuteNonQuery();
            }
            command.CommandText = "UPDATE Bill SET [status] = N'Chưa thanh toán' WHERE idBill = " + idBill + "";
            command.ExecuteNonQuery();
            HomeFrm.hform.ShowBill();
            Dispose();
        }
    }
}

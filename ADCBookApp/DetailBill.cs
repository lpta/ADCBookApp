using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class DetailBill : Form
    {
        Bill bill;

        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public DetailBill(Bill _bill)
        {
            InitializeComponent();
            bill = _bill;
        }

        private void ShowCustommer()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT idCustommer, nameCustommer, BirstDay, Address, phoneNumber, Email FROM Custommer WHERE nameCustommer LIKE N'" + bill.nameCustommer + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            tblSearchedCustomer.Rows.Clear();
            tblSearchedCustomer.Rows.Add(new object[]
            {
                Convert.ToInt32(table.Rows[0]["idCustommer"]), table.Rows[0]["nameCustommer"].ToString(), DateTime.Parse(table.Rows[0]["BirstDay"].ToString()), table.Rows[0]["Address"].ToString(), table.Rows[0]["phoneNumber"].ToString(), table.Rows[0]["Email"].ToString()
            });
        }

        private void ShowBillBook()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT BillBook.idBook, Book.nameBook, BillBook.numberBook, Book.price FROM BillBook, Bill, Book WHERE BillBook.idBook = Book.idBook AND BillBook.idBill = Bill.idBill AND Bill.idBill = " + bill.idBill + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            tblBillDetail.Rows.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tblBillDetail.Rows.Add(new object[]
                {
                    Convert.ToInt32(table.Rows[i]["idBook"]), table.Rows[i]["nameBook"].ToString(), Convert.ToInt32(table.Rows[i]["numberBook"]), Convert.ToInt32(table.Rows[i]["price"])
                });
            }
        }

        private void ShowDetailBill()
        {
            labelCustomerName.Text = $"Khách hàng: {bill.nameCustommer:NO}";
            labelTotalDiscount.Text = $"Tổng KM: {bill.TotalPriceDiscount:N0}đ";
            labelTotalAmount.Text = $"Tổng tiền: {bill.PayTotal:N0}đ";
        }

        private void DetailBillLoad(object sender, System.EventArgs e)
        {
            ShowCustommer();
            ShowBillBook();
            ShowDetailBill();
        }
    }
}

using ADC;


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADCBookApp
{
    public partial class HomeFrm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-VE7NUJM;Initial Catalog=DataADCBook;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public static HomeFrm hform;
        public List<Company> companies;
        public List<Author> authors;
        public List<Type> types;
        public List<Book> books;
        public List<ExchangeBook> exchangeBooks;
        public List<Order> orders;
        public List<Custommer> custommers;
        public List<Discount> discounts;
        public List<Bill> bills;
        public HomeFrm()
        {
            InitializeComponent();
            CenterToScreen();
            hform = this;
        }

        public static void ConvertDataTable(List<Company> companyList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Company company = new Company();
                company.companyId = Convert.ToInt32(table.Rows[i]["idCompany"]);
                company.companyName = table.Rows[i]["nameCompany"].ToString();
                company.address = table.Rows[i]["addressCompany"].ToString();
                company.phoneNumber = table.Rows[i]["phoneNumber"].ToString();
                companyList.Add(company);
            }
        }

        public static void ConvertDataTableAuthor(List<Author> authorList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Author author = new Author();
                author.authorId = Convert.ToInt32(table.Rows[i]["idAuthor"]);
                author.authorName = table.Rows[i]["nameAuthor"].ToString();
                author.birstYear = Convert.ToInt32(table.Rows[i]["birthYear"]);
                author.homeTown = table.Rows[i]["homeTown"].ToString();
                authorList.Add(author);
            }
        }

        public static void ConvertDataTableType(List<Type> typeList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Type type = new Type();
                type.idType = Convert.ToInt32(table.Rows[i]["idType"]);
                type.nameType = table.Rows[i]["nameType"].ToString();
                typeList.Add(type);
            }
        }

        public static void ConvertDataTableBook(List<Book> bookList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Book book = new Book();
                book.idBook = Convert.ToInt32(table.Rows[i]["idBook"]);
                book.nameBook = table.Rows[i]["nameBook"].ToString();
                book.nameCompany = table.Rows[i]["nameCompany"].ToString();
                book.nameType = table.Rows[i]["nameType"].ToString();
                book.nameAuthor = table.Rows[i]["nameAuthor"].ToString();
                book.number = Convert.ToInt32(table.Rows[i]["number"]);
                book.price = Convert.ToInt32(table.Rows[i]["price"]);
                bookList.Add(book);
            }
        }

        public static void ConvertDataTableExchangeBook(List<ExchangeBook> exchangeBookList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ExchangeBook exchangeBook = new ExchangeBook();
                exchangeBook.idExchangeBook = Convert.ToInt32(table.Rows[i]["idExchangeBook"]);
                exchangeBook.idBook = Convert.ToInt32(table.Rows[i]["idBook"]);
                exchangeBook.nameBook = table.Rows[i]["nameBook"].ToString();
                exchangeBook.number = Convert.ToInt32(table.Rows[i]["number"]);
                exchangeBook.reason = table.Rows[i]["reason"].ToString();
                exchangeBook.status = table.Rows[i]["status"].ToString();
                exchangeBook.startDay = DateTime.Parse(table.Rows[i]["startDay"].ToString());
                if (table.Rows[i]["endDay"] != DBNull.Value)
                {
                    exchangeBook.endDay = DateTime.Parse(table.Rows[i]["endDay"].ToString());
                }
                exchangeBookList.Add(exchangeBook);
            }
        }

        public static void ConvertDataTableOrder(List<Order> orderList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Order order = new Order();
                order.idOrder = Convert.ToInt32(table.Rows[i]["idOrder"]);
                order.nameOrder = table.Rows[i]["nameOrder"].ToString();
                order.CreateDateOrder = DateTime.Parse(table.Rows[i]["CreateDateOrder"].ToString());
                order.BillTotal = Convert.ToInt32(table.Rows[i]["BillTotal"]);
                if (table.Rows[i]["BillDate"] != DBNull.Value)
                {
                    order.BillDate = DateTime.Parse(table.Rows[i]["BillDate"].ToString());
                }
                order.StatusOrder = table.Rows[i]["StatusOrder"].ToString();
                orderList.Add(order);
            }
        }

        public static void ConvertDataTableCustommer(List<Custommer> custommerList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Custommer custommer = new Custommer();
                custommer.idCustommer = Convert.ToInt32(table.Rows[i]["idCustommer"]);
                custommer.nameCustommer = table.Rows[i]["nameCustommer"].ToString();
                custommer.BirstDay = DateTime.Parse(table.Rows[i]["BirstDay"].ToString());
                custommer.Address = table.Rows[i]["Address"].ToString();
                custommer.phoneNumber = table.Rows[i]["phoneNumber"].ToString();
                custommer.Email = table.Rows[i]["Email"].ToString();
                custommer.CreateAccount = DateTime.Parse(table.Rows[i]["CreateAccount"].ToString());
                custommerList.Add(custommer);
            }
        }

        public static void ConvertDataTableDiscount(List<Discount> discountList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Discount discount = new Discount();
                discount.idDiscount = Convert.ToInt32(table.Rows[i]["idDiscount"]);
                discount.nameDiscount = table.Rows[i]["nameDiscount"].ToString();
                discount.StartDiscountDate = DateTime.Parse(table.Rows[i]["StartDiscountDate"].ToString());
                discount.EndDiscountDate = DateTime.Parse(table.Rows[i]["EndDiscountDate"].ToString());
                discount.DiscountValue = Convert.ToInt32(table.Rows[i]["DiscountValue"]);
                discountList.Add(discount);
            }
        }

        public static void ConvertDataTableBill(List<Bill> billList, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Bill bill = new Bill();
                bill.idBill = Convert.ToInt32(table.Rows[i]["idBill"]);
                bill.nameCustommer = table.Rows[i]["nameCustommer"].ToString();
                bill.DiscountValue = Convert.ToInt32(table.Rows[i]["DiscountValue"]);
                bill.TotalPriceDiscount = Convert.ToInt32(table.Rows[i]["TotalPriceDiscount"].ToString());
                bill.PayTotal = Convert.ToInt32(table.Rows[i]["PayTotal"].ToString());
                bill.status = table.Rows[i]["status"].ToString();
                bill.CreateDate = DateTime.Parse(table.Rows[i]["CreateDate"].ToString());
                billList.Add(bill);
            }
        }

        public void ShowCompany()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Company";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            companies = new List<Company>();
            tblCompany.Rows.Clear();
            ConvertDataTable(companies, table);
            foreach (Company i in companies)
            {
                tblCompany.Rows.Add(new object[]
                {
                        i.companyId, i.companyName, i.address, i.phoneNumber
                });
            }
            connection.Close();
        }

        public List<Company> getCompany()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Company";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            companies = new List<Company>();
            ConvertDataTable(companies, table);
            return companies;
        }

        public void ShowAuthor()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Author";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            authors = new List<Author>();
            tblAuthor.Rows.Clear();
            ConvertDataTableAuthor(authors, table);
            foreach (Author i in authors)
            {
                tblAuthor.Rows.Add(new object[]
                {
                        i.authorId, i.authorName, i.birstYear, i.homeTown
                });
            }
        }

        public List<Author> getAuthor()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Author";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            authors = new List<Author>();
            ConvertDataTableAuthor(authors, table);
            return authors;
        }

        public void ShowType()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Type";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            types = new List<Type>();
            tblType.Rows.Clear();
            ConvertDataTableType(types, table);
            foreach (Type i in types)
            {
                tblType.Rows.Add(new object[]
                {
                        i.idType, i.nameType
                });
            }
        }

        public List<Type> getType()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Type";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            types = new List<Type>();
            ConvertDataTableType(types, table);
            return types;
        }

        public void ShowBook()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Book";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            books = new List<Book>();
            tblBook.Rows.Clear();
            ConvertDataTableBook(books, table);
            foreach (Book i in books)
            {
                tblBook.Rows.Add(new object[]
                {
                        i.idBook, i.nameBook, i.nameType, i.nameCompany, i.nameAuthor, i.number, i.price
                });
            }
        }

        public void ShowExchangeBook()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ExchangeBook WHERE ExchangeBook.[status] = N'Chưa đổi'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            exchangeBooks = new List<ExchangeBook>();
            tblExchangeBook.Rows.Clear();
            ConvertDataTableExchangeBook(exchangeBooks, table);
            foreach (ExchangeBook i in exchangeBooks)
            {
                tblExchangeBook.Rows.Add(new object[]
                {
                    i.idExchangeBook, i.idBook, i.nameBook, i.number, i.reason, i.status, i.startDay.ToString(), i.endDay.ToString() == "1/1/0001 12:00:00 AM" ? "-" : i.endDay.ToString()
                });
            }
        }

        public void ShowOrder()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Order]";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            orders = new List<Order>();
            tblOrder.Rows.Clear();
            ConvertDataTableOrder(orders, table);
            foreach (Order i in orders)
            {
                tblOrder.Rows.Add(new object[]
                {
                    i.idOrder, i.nameOrder, i.CreateDateOrder, i.BillTotal, i.BillDate.ToString() == "1/1/0001 12:00:00 AM" ? "-" : i.BillDate.ToString(), i.StatusOrder
                });
            }
        }

        public void ShowOrderBill()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Order] WHERE [Order].StatusOrder = N'Chua thanh toan';";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            orders = new List<Order>();
            tblOrderBill.Rows.Clear();
            ConvertDataTableOrder(orders, table);
            foreach (Order i in orders)
            {
                tblOrderBill.Rows.Add(new object[]
                {
                    i.idOrder, i.nameOrder, i.CreateDateOrder, i.BillTotal, i.BillDate.ToString() == "1/1/0001 12:00:00 AM" ? "-" : i.BillDate.ToString(), i.StatusOrder
                });
            }
        }

        public void ShowCustommer()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Custommer";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            custommers = new List<Custommer>();
            tblCustommer.Rows.Clear();
            ConvertDataTableCustommer(custommers, table);
            foreach (Custommer i in custommers)
            {
                tblCustommer.Rows.Add(new object[]
                {
                    i.idCustommer, i.nameCustommer, i.BirstDay.ToString("dd/MM/yyyy"), i.Address, i.phoneNumber, i.Email, i.CreateAccount.ToString("dd/MM/yyyy")
                });
            }
        }

        public void ShowDiscount()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Discount";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            discounts = new List<Discount>();
            tblDiscount.Rows.Clear();
            ConvertDataTableDiscount(discounts, table);
            foreach (Discount i in discounts)
            {
                tblDiscount.Rows.Add(new object[]
                {
                    i.idDiscount, i.nameDiscount, i.StartDiscountDate, i.EndDiscountDate, i.DiscountValue
                });
            }
        }

        public void ShowBill()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Bill;";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            bills = new List<Bill>();
            tblBill.Rows.Clear();
            ConvertDataTableBill(bills, table);
            foreach (Bill i in bills)
            {
                tblBill.Rows.Add(new object[]
                {
                    i.idBill, i.nameCustommer, i.CreateDate, i.DiscountValue, i.TotalPriceDiscount, i.PayTotal, i.status
                });
            }
        }

        public void ShowPayment()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Bill WHERE status = N'Chưa thanh toán';";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            bills = new List<Bill>();
            tblPayment.Rows.Clear();
            ConvertDataTableBill(bills, table);
            foreach (Bill i in bills)
            {
                tblPayment.Rows.Add(new object[]
                {
                    i.idBill, i.nameCustommer, i.CreateDate, i.DiscountValue, i.TotalPriceDiscount, i.PayTotal, i.status
                });
            }
        }

        public List<Discount> ShowListDiscount()
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Discount";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            discounts = new List<Discount>();
            ConvertDataTableDiscount(discounts, table);
            return discounts;
        }

        private void HomeFrm_Load(object sender, EventArgs e)
        {
            ShowCompany();
            ShowAuthor();
            ShowType();
            ShowBook();
            ShowExchangeBook();
        }

        public void UpdateCompany(Company updateCompany)
        {
            var newCompany = updateCompany as Company;
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Company SET nameCompany = N'" + newCompany.companyName + "', addressCompany = N'" + newCompany.address + "', phoneNumber = N'" + newCompany.phoneNumber + "' WHERE idCompany = " + newCompany.companyId + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            tblCompany.Rows.Clear();
            ConvertDataTable(companies, table);
            foreach (Company i in companies)
            {
                tblCompany.Rows.Add(new object[]
                {
                        i.companyId, i.companyName, i.address, i.phoneNumber
                });
            }
        }

        public void UpdateAuthor(Author updateAuthor)
        {
            var newAuthor = updateAuthor as Author;
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Author SET nameAuthor = N'" + newAuthor.authorName + "', birthYear = N'" + newAuthor.birstYear + "', homeTown = N'" + newAuthor.homeTown + "' WHERE idAuthor = " + newAuthor.authorId + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            tblAuthor.Rows.Clear();
            ConvertDataTableAuthor(authors, table);
            foreach (Author i in authors)
            {
                tblAuthor.Rows.Add(new object[]
                {
                        i.authorId, i.authorName, i.birstYear, i.homeTown
                });
            }
        }

        public void UpdateType(Type updateType)
        {
            var newType = updateType as Type;
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Type SET nameType = N'" + newType.nameType + "' WHERE idType = " + newType.idType + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            tblType.Rows.Clear();
            ConvertDataTableType(types, table);
            foreach (Type i in types)
            {
                tblType.Rows.Add(new object[]
                {
                        i.idType, i.nameType
                });
            }
        }

        public void UpdateBook(Book updateBook)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Book SET nameBook = N'" + updateBook.nameBook + "', Company_idCompany = (SELECT idCompany FROM Company WHERE nameCompany = N'" + updateBook.nameCompany + "'), Author_idAuthor = (SELECT idAuthor FROM Author WHERE nameAuthor = N'" + updateBook.nameAuthor + "'), Type_idType = (SELECT idType FROM Type WHERE nameType = N'" + updateBook.nameType + "'), number = " + updateBook.number + ", price = " + updateBook.price + " WHERE idBook = " + updateBook.idBook + ";";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            tblBook.Rows.Clear();
            ConvertDataTableBook(books, table);
            foreach (Book i in books)
            {
                tblBook.Rows.Add(new object[]
                {
                        i.idBook, i.nameBook, i.nameType, i.nameCompany, i.nameAuthor, i.number, i.price
                });
            }
        }

        public void UpdateExchangeBook(ExchangeBook exchangeBook)
        {
            if (exchangeBook.status == "Đã đổi")
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "UPDATE ExchangeBook SET ExchangeBook.number = " + exchangeBook.number + ", ExchangeBook.reason = N'" + exchangeBook.reason + "', ExchangeBook.[status] = N'" + exchangeBook.status + "', ExchangeBook.endDay = '" + DateTime.Now + "' WHERE ExchangeBook.idExchangeBook = " + exchangeBook.idExchangeBook + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                ShowExchangeBook();
            }
            else if (exchangeBook.status == "Đã trả")
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "UPDATE ExchangeBook SET number = " + exchangeBook.number + ", reason = N'" + exchangeBook.reason + "', [status] = N'" + exchangeBook.status + "', endDay = '" + DateTime.Now + "' WHERE IdExchangeBook = " + exchangeBook.idExchangeBook + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                command.CommandText = "UPDATE Book SET number = (SELECT number FROM Book WHERE idBook = " + exchangeBook.idBook + ") - " + exchangeBook.number + " WHERE idBook = " + exchangeBook.idBook + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                ShowExchangeBook();
            }
        }

        public void UpdateCustommer(Custommer updateCustommer)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Custommer SET nameCustommer = N'" + updateCustommer.nameCustommer + "', BirstDay = '" + updateCustommer.BirstDay + "', [Address] = N'" + updateCustommer.Address + "', phoneNumber = N'" + updateCustommer.phoneNumber + "', Email = N'" + updateCustommer.Email + "' WHERE idCustommer = " + updateCustommer.idCustommer + ";";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            ShowCustommer();
        }

        public void UpdateDiscount(Discount updateDiscount)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Discount SET nameDiscount = N'" + updateDiscount.nameDiscount + "', StartDiscountDate = '" + updateDiscount.StartDiscountDate + "', EndDiscountDate = '" + updateDiscount.EndDiscountDate + "', DiscountValue = " + updateDiscount.DiscountValue + " WHERE idDiscount = " + updateDiscount.idDiscount + ";";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            ShowDiscount();
        }

        private void tblCompanyCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblCompany.Columns["tblCompanyEdit"].Index)
            {
                Company company = companies[e.RowIndex];
                var updateCompanyView = new AddEditCompanyFrm(company);
                updateCompanyView.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == tblCompany.Columns["tblCompanyRemove"].Index)
            {
                Company company = companies[e.RowIndex];
                var title = "Xác nhận xóa";
                var msg = "Bạn có chắc chắn muốn xóa bản ghi này không?";
                var ans = ShowConfirmDialog(msg, title);
                if (ans == DialogResult.Yes)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Company WHERE idCompany = " + company.companyId + ";";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    ShowCompany();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblAuthorCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblAuthor.Columns["tblAuthorEdit"].Index)
            {
                Author author = authors[e.RowIndex];
                var updateAuthorView = new AddEditAuthorFrm(author);
                updateAuthorView.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == tblAuthor.Columns["tblAuthorRemove"].Index)
            {
                Author author = authors[e.RowIndex];
                var title = "Xác nhận xóa";
                var msg = "Bạn có chắc chắn muốn xóa bản ghi này không?";
                var ans = ShowConfirmDialog(msg, title);
                if (ans == DialogResult.Yes)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Author WHERE idAuthor = " + author.authorId + ";";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    ShowAuthor();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblTypeCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblType.Columns["tblTypeEdit"].Index)
            {
                Type type = types[e.RowIndex];
                var updateTypeView = new AddEditTypeFrm(type);
                updateTypeView.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == tblType.Columns["tblTypeRemove"].Index)
            {
                Type type = types[e.RowIndex];
                var title = "Xác nhận xóa";
                var msg = "Bạn có chắc chắn muốn xóa bản ghi này không?";
                var ans = ShowConfirmDialog(msg, title);
                if (ans == DialogResult.Yes)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Type WHERE idType = " + type.idType + ";";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    ShowType();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblBookCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblBook.Columns["tblBookEdit"].Index)
            {
                Book book = books[e.RowIndex];
                var updateBookView = new AddEditBookFrm(book);
                updateBookView.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == tblBook.Columns["tblBookRemove"].Index)
            {
                Book book = books[e.RowIndex];
                var title = "Xác nhận xóa";
                var msg = "Bạn có chắc chắn muốn xóa bản ghi này không?";
                var ans = ShowConfirmDialog(msg, title);
                if (ans == DialogResult.Yes)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Book WHERE idBook = " + book.idBook + ";";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    ShowBook();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblExchangeBookCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblExchangeBook.Columns["tblExchangeBookEdit"].Index)
            {
                ExchangeBook exchangeBook = exchangeBooks[e.RowIndex];
                var updateExchangeBookView = new AddEditExchangeBookFrm(exchangeBook);
                updateExchangeBookView.Show();
            }
        }

        private void tblOrderCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var title = "Xác nhận sửa";
            var msg = "Bạn có chắc chắn muốn sửa bản ghi này không?";
            var ans = ShowConfirmDialog(msg, title);
            if (ans == DialogResult.Yes)
            {
                Order order = new Order();
                order.idOrder = Int32.Parse(tblOrderBill.Rows[tblOrderBill.CurrentRow.Index].Cells[0].Value.ToString());
                order.StatusOrder = tblOrderBill.Rows[tblOrderBill.CurrentRow.Index].Cells[5].Value.ToString();
                if (order.StatusOrder != "Chua thanh toan")
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "UPDATE [Order] SET [Order].StatusOrder = N'" + order.StatusOrder + "', [Order].BillDate = '" + DateTime.Now + "' WHERE [Order].idOrder = " + order.idOrder + "";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    orders = new List<Order>();
                    tblOrderBill.Rows.Clear();
                    ConvertDataTableOrder(orders, table);
                    foreach (Order i in orders)
                    {
                        tblOrderBill.Rows.Add(new object[]
                        {
                    i.idOrder, i.nameOrder, i.CreateDateOrder, i.BillTotal, i.BillDate.ToString() == "1/1/0001 12:00:00 AM" ? "-" : i.BillDate.ToString(), i.StatusOrder
                        });
                    }
                    ShowOrderBill();
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblCustommerCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblCustommer.Columns["tblCustommerEdit"].Index)
            {
                Custommer custommer = custommers[e.RowIndex];
                var updateCustommerView = new AddEditCustommerFrm(custommer);
                updateCustommerView.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == tblCustommer.Columns["tblCustommerRemove"].Index)
            {
                Custommer custommer = custommers[e.RowIndex];
                var title = "Xác nhận xóa";
                var msg = "Bạn có chắc chắn muốn xóa bản ghi này không?";
                var ans = ShowConfirmDialog(msg, title);
                if (ans == DialogResult.Yes)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Custommer WHERE idCustommer = " + custommer.idCustommer + ";";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    ShowCustommer();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblDiscountCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblDiscount.Columns["tblDiscountEdit"].Index)
            {
                Discount discount = discounts[e.RowIndex];
                var updateDiscountView = new AddEditDiscountFrm(discount);
                updateDiscountView.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == tblDiscount.Columns["tblDiscountRemove"].Index)
            {
                Discount discount = discounts[e.RowIndex];
                var title = "Xác nhận xóa";
                var msg = "Bạn có chắc chắn muốn xóa bản ghi này không?";
                var ans = ShowConfirmDialog(msg, title);
                if (ans == DialogResult.Yes)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Discount WHERE idDiscount = " + discount.idDiscount + ";";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    ShowDiscount();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tblBillCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblBill.Columns["tblChooseBilldetail"].Index)
            {
                Bill bill = bills[e.RowIndex];
                new DetailBill(bill).Show();
            }
        }

        private void tblPaymentCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tblPayment.Columns["tblPaymentButton"].Index)
            {
                Bill bill = bills[e.RowIndex];
                var title = "Xác nhận thanh toán";
                var msg = "Bạn có chắc chắn muốn thanh toán không?";
                var ans = ShowConfirmDialog(msg, title);
                if (ans == DialogResult.Yes)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "UPDATE Bill SET status = N'Đã thanh toán' WHERE idBill = " + bill.idBill + ";";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table);
                    ShowPayment();
                    MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private DialogResult ShowConfirmDialog(string msg, string title)
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void BtnAddNewCompanyClick(object sender, EventArgs e)
        {
            var childView = new AddEditCompanyFrm();
            childView.Show();
        }

        private void BtnAddNewAuthorClick(object sender, EventArgs e)
        {
            var childView = new AddEditAuthorFrm();
            childView.Show();
        }

        private void BtnAddNewTypeClick(object sender, EventArgs e)
        {
            var childView = new AddEditTypeFrm();
            childView.Show();
        }

        private void BtnAddNewBookClick(object sender, EventArgs e)
        {
            var childView = new AddEditBookFrm();
            childView.Show();
        }

        private void BtnAddNewOrderClick(object sender, EventArgs e)
        {
            var childView = new AddEditOrderFrm();
            childView.Show();
        }

        private void BtnAddNewCustommerClick(object sender, EventArgs e)
        {
            var childView = new AddEditCustommerFrm();
            childView.Show();
        }

        private void BtnAddNewDiscountClick(object sender, EventArgs e)
        {
            var childView = new AddEditDiscountFrm();
            childView.Show();
        }

        private void BtnAddNewBillClick_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Bill(nameCustommer, DiscountValue, TotalPriceDiscount, PayTotal, CreateDate) VALUES (N'0', 0, 0, 0, '" + DateTime.Now + "');";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            command.CommandText = "SELECT TOP 1 * FROM Bill ORDER BY idBill DESC;";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            int idBill = Convert.ToInt32(table.Rows[0]["idBill"]);
            new AddEditBillFrm(idBill).Show();
        }

        private void btRefeshCompany(object sender, EventArgs e)
        {
            ShowCompany();
        }

        private void btRefeshAuthor(object sender, EventArgs e)
        {
            ShowAuthor();
        }

        private void btRefeshType(object sender, EventArgs e)
        {
            ShowType();
        }

        private void btRefeshBook(object sender, EventArgs e)
        {
            ShowBook();
        }

        private void btRefeshExchangeBook(object sender, EventArgs e)
        {
            ShowExchangeBook();
        }

        private void btRefeshOrder(object sender, EventArgs e)
        {
            ShowOrder();
        }

        private void btRefeshCustommer(object sender, EventArgs e)
        {
            ShowCustommer();
        }

        private void btRefeshDiscount(object sender, EventArgs e)
        {
            ShowDiscount();
        }
        private void btrefeshBill(object sender, EventArgs e)
        {
            ShowBill();
        }

        private void SortCompany(object sender, EventArgs e)
        {
            if (sortNameCompanyASC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Company ORDER BY Company.nameCompany ASC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                companies = new List<Company>();
                tblCompany.Rows.Clear();
                ConvertDataTable(companies, table);
                foreach (Company i in companies)
                {
                    tblCompany.Rows.Add(new object[]
                    {
                        i.companyId, i.companyName, i.address, i.phoneNumber
                    });
                }
                connection.Close();
            }
            else if (sortNameCompanyDESC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Company ORDER BY Company.nameCompany DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                companies = new List<Company>();
                tblCompany.Rows.Clear();
                ConvertDataTable(companies, table);
                foreach (Company i in companies)
                {
                    tblCompany.Rows.Add(new object[]
                    {
                        i.companyId, i.companyName, i.address, i.phoneNumber
                    });
                }
                connection.Close();
            }
        }

        private void SortAuthor(object sender, EventArgs e)
        {
            if (sortNameAuthorASC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Author ORDER BY Author.nameAuthor ASC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                authors = new List<Author>();
                tblAuthor.Rows.Clear();
                ConvertDataTableAuthor(authors, table);
                foreach (Author i in authors)
                {
                    tblAuthor.Rows.Add(new object[]
                    {
                        i.authorId, i.authorName, i.birstYear, i.homeTown
                    });
                }
            }
            else if (sortNameAuthorDESC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Author ORDER BY Author.nameAuthor DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                authors = new List<Author>();
                tblAuthor.Rows.Clear();
                ConvertDataTableAuthor(authors, table);
                foreach (Author i in authors)
                {
                    tblAuthor.Rows.Add(new object[]
                    {
                        i.authorId, i.authorName, i.birstYear, i.homeTown
                    });
                }
            }
            connection.Close();
        }

        private void SortType(object sender, EventArgs e)
        {
            if (sortNameTypeASC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Type ORDER BY Type.nameType ASC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                types = new List<Type>();
                tblType.Rows.Clear();
                ConvertDataTableType(types, table);
                foreach (Type i in types)
                {
                    tblType.Rows.Add(new object[]
                    {
                        i.idType, i.nameType
                    });
                }
            }
            else if (sortNameTypeDESC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Type ORDER BY Type.nameType DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                types = new List<Type>();
                tblType.Rows.Clear();
                ConvertDataTableType(types, table);
                foreach (Type i in types)
                {
                    tblType.Rows.Add(new object[]
                    {
                        i.idType, i.nameType
                    });
                }
            }
            connection.Close();
        }

        private void SortBook(object sender, EventArgs e)
        {
            if (sortNameBookASC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Book ORDER BY Book.nameBook ASC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                books = new List<Book>();
                tblBook.Rows.Clear();
                ConvertDataTableBook(books, table);
                foreach (Book i in books)
                {
                    tblBook.Rows.Add(new object[]
                    {
                        i.idBook, i.nameBook, i.nameType, i.nameCompany, i.nameAuthor, i.number, i.price
                    });
                }
            }
            else if (sortNameBookDESC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Book ORDER BY Book.nameBook DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                books = new List<Book>();
                tblBook.Rows.Clear();
                ConvertDataTableBook(books, table);
                foreach (Book i in books)
                {
                    tblBook.Rows.Add(new object[]
                    {
                        i.idBook, i.nameBook, i.nameType, i.nameCompany, i.nameAuthor, i.number, i.price
                    });
                }
            }
            else if (sortTypeBookASC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Book ORDER BY nameType ASC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                books = new List<Book>();
                tblBook.Rows.Clear();
                ConvertDataTableBook(books, table);
                foreach (Book i in books)
                {
                    tblBook.Rows.Add(new object[]
                    {
                        i.idBook, i.nameBook, i.nameType, i.nameCompany, i.nameAuthor, i.number, i.price
                    });
                }
            }
            else if (sortTypeBookDESC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Book ORDER BY nameType DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                books = new List<Book>();
                tblBook.Rows.Clear();
                ConvertDataTableBook(books, table);
                foreach (Book i in books)
                {
                    tblBook.Rows.Add(new object[]
                    {
                        i.idBook, i.nameBook, i.nameType, i.nameCompany, i.nameAuthor, i.number, i.price
                    });
                }
            }
            connection.Close();
        }

        private void SortCustommer(object sender, EventArgs e)
        {
            if (sortIdCustommerDESC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Custommer ORDER BY idCustommer DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                custommers = new List<Custommer>();
                tblCustommer.Rows.Clear();
                ConvertDataTableCustommer(custommers, table);
                foreach (Custommer i in custommers)
                {
                    tblCustommer.Rows.Add(new object[]
                    {
                    i.idCustommer, i.nameCustommer, i.BirstDay, i.Address, i.phoneNumber, i.Email, i.CreateAccount
                    });
                }
            }
            if (sortNameCustommerASC.Equals(sender))
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Custommer ORDER BY nameCustommer ASC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                custommers = new List<Custommer>();
                tblCustommer.Rows.Clear();
                ConvertDataTableCustommer(custommers, table);
                foreach (Custommer i in custommers)
                {
                    tblCustommer.Rows.Add(new object[]
                    {
                    i.idCustommer, i.nameCustommer, i.BirstDay, i.Address, i.phoneNumber, i.Email, i.CreateAccount
                    });
                }
            }
            connection.Close();
        }

        private void ShowSearchedCompany(List<Company> companies)
        {
            foreach (Company i in companies)
            {
                tblCompany.Rows.Add(new object[]
                {
                        i.companyId, i.companyName, i.address, i.phoneNumber
                });
            }
        }

        private void ShowSearchedAuthor(List<Author> authors)
        {
            foreach (Author i in authors)
            {
                tblAuthor.Rows.Add(new object[]
                {
                        i.authorId, i.authorName, i.birstYear, i.homeTown
                });
            }
        }

        private void ShowSearchedType(List<Type> types)
        {
            foreach (Type i in types)
            {
                tblType.Rows.Add(new object[]
                {
                        i.idType, i.nameType
                });
            }
        }

        private void ShowSearchedBook(List<Book> books)
        {
            foreach (Book i in books)
            {
                tblBook.Rows.Add(new object[]
                {
                        i.idBook, i.nameBook, i.nameType, i.nameCompany, i.nameAuthor, i.number, i.price
                });
            }
        }

        private void ShowSearchedOrder(List<Order> orders)
        {
            foreach (Order i in orders)
            {
                tblOrder.Rows.Add(new object[]
                {
                    i.idOrder, i.nameOrder, i.CreateDateOrder, i.BillTotal, i.BillDate.ToString() == "1/1/0001 12:00:00 AM" ? "-" : i.BillDate.ToString(), i.StatusOrder
                });
            }
        }

        private void ShowSearchedCustommer(List<Custommer> custommers)
        {
            foreach (Custommer i in custommers)
            {
                tblCustommer.Rows.Add(new object[]
                {
                    i.idCustommer, i.nameCustommer, i.BirstDay, i.Address, i.phoneNumber, i.Email, i.CreateAccount
                });
            }
        }

        private void BtnSearchCompanyClick(object sender, EventArgs e)
        {
            var key = txtSearchCompany.Text;
            tblCompany.Rows.Clear();
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();

            if (comboSeachCompany.SelectedIndex == -1)
            {
                var msg = "Vui lòng chọn tiêu chí tìm kiếm để tiếp tục";
                var title = "Lỗi dữ liệu";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboSeachCompany.SelectedIndex == 0)
            {

                command.CommandText = "SELECT * FROM Company WHERE Company.idCompany = " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                companies = new List<Company>();
                ConvertDataTable(companies, table);
                if (companies.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedCompany(companies);
                }
            }
            else if (comboSeachCompany.SelectedIndex == 1)
            {
                command.CommandText = "SELECT * FROM Company WHERE Company.nameCompany LIKE '%" + key + "%';";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                companies = new List<Company>();
                ConvertDataTable(companies, table);
                if (companies.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedCompany(companies);
                }
            }
            else if (comboSeachCompany.SelectedIndex == 2)
            {
                command.CommandText = "SELECT * FROM Company WHERE Company.addressCompany LIKE '%" + key + "%';";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                companies = new List<Company>();
                ConvertDataTable(companies, table);
                if (companies.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedCompany(companies);
                }
            }
            else if (comboSeachCompany.SelectedIndex == 3)
            {
                command.CommandText = "SELECT * FROM Company WHERE Company.phoneNumber LIKE '%" + key + "%';";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                companies = new List<Company>();
                ConvertDataTable(companies, table);
                if (companies.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedCompany(companies);
                }
            }
        }

        private void BtnSearchAuthorClick(object sender, EventArgs e)
        {
            var key = txtSearchAuthor.Text;
            tblAuthor.Rows.Clear();
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();

            if (comboSeachAuthor.SelectedIndex == -1)
            {
                var msg = "Vui lòng chọn tiêu chí tìm kiếm để tiếp tục";
                var title = "Lỗi dữ liệu";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboSeachAuthor.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM Author WHERE Author.idAuthor = " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                authors = new List<Author>();
                ConvertDataTableAuthor(authors, table);
                if (authors.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedAuthor(authors);
                }
            }
            else if (comboSeachAuthor.SelectedIndex == 1)
            {
                command.CommandText = "SELECT * FROM Author WHERE Author.nameAuthor LIKE '%" + key + "%';";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                authors = new List<Author>();
                ConvertDataTableAuthor(authors, table);
                if (authors.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedAuthor(authors);
                }
            }
        }

        private void BtnSearchTypeClick(object sender, EventArgs e)
        {
            var key = txtSearchType.Text;
            tblType.Rows.Clear();
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();

            if (comboSeachType.SelectedIndex == -1)
            {
                var msg = "Vui lòng chọn tiêu chí tìm kiếm để tiếp tục";
                var title = "Lỗi dữ liệu";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboSeachType.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM Type WHERE Type.idType = " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                types = new List<Type>();
                ConvertDataTableType(types, table);
                if (types.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedType(types);
                }
            }
            else if (comboSeachType.SelectedIndex == 1)
            {
                command.CommandText = "SELECT * FROM Type WHERE Type.nameType LIKE '%" + key + "%';";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                types = new List<Type>();
                ConvertDataTableType(types, table);
                if (types.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedType(types);
                }
            }
        }

        private void BtnSearchBookClick(object sender, EventArgs e)
        {
            var key = txtSearchBook.Text;
            tblBook.Rows.Clear();
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();

            if (comboSeachBook.SelectedIndex == -1)
            {
                var msg = "Vui lòng chọn tiêu chí tìm kiếm để tiếp tục";
                var title = "Lỗi dữ liệu";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboSeachBook.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM Book WHERE Book.idBook = " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                books = new List<Book>();
                ConvertDataTableBook(books, table);
                if (books.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedBook(books);
                }
            }
            else if (comboSeachBook.SelectedIndex == 1)
            {
                command.CommandText = "SELECT * FROM Book WHERE Book.nameBook LIKE '%" + key + "%';";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                books = new List<Book>();
                ConvertDataTableBook(books, table);
                if (books.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedBook(books);
                }
            }
        }

        private void BtnAddExchangeBookClick(object sender, EventArgs e)
        {
            var key = txtSearchExchangeBook.Text;
            tblExchangeBook.Rows.Clear();
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();

            if (comboSeachExchangeBook.SelectedIndex == -1)
            {
                var msg = "Vui lòng chọn tiêu chí tìm kiếm để tiếp tục";
                var title = "Lỗi dữ liệu";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboSeachExchangeBook.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM Book WHERE Book.idBook = " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ExchangeBook exchangeBook = new ExchangeBook();
                    exchangeBook.idBook = Convert.ToInt32(table.Rows[0]["idBook"]);
                    exchangeBook.nameBook = table.Rows[0]["nameBook"].ToString();
                    var childView = new AddEditExchangeBookFrm(exchangeBook);
                    childView.Show();
                }
            }
        }

        private void btShowListExchangeBookClick(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ExchangeBook WHERE ExchangeBook.[status] = N'Đã đổi' OR ExchangeBook.[status] = N'Đã trả'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            exchangeBooks = new List<ExchangeBook>();
            tblExchangeBook.Rows.Clear();
            ConvertDataTableExchangeBook(exchangeBooks, table);
            foreach (ExchangeBook i in exchangeBooks)
            {
                tblExchangeBook.Rows.Add(new object[]
                {
                    i.idExchangeBook, i.idBook, i.nameBook, i.number, i.reason, i.status, i.startDay.ToString(), i.endDay.ToString() == "1/1/0001 12:00:00 AM" ? "-" : i.endDay.ToString()
                });
            }
        }

        private void BtnSearchOrderClick(object sender, EventArgs e)
        {
            var key = txtSearchOrder.Text;
            tblOrder.Rows.Clear();
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();

            if (comboSeachOrder.SelectedIndex == -1)
            {
                var msg = "Vui lòng chọn tiêu chí tìm kiếm để tiếp tục";
                var title = "Lỗi dữ liệu";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboSeachOrder.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM [Order] WHERE [Order].idOrder = " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                orders = new List<Order>();
                ConvertDataTableOrder(orders, table);
                if (orders.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedOrder(orders);
                }
            }
            else if (comboSeachOrder.SelectedIndex == 1)
            {
                command.CommandText = "SELECT * FROM [Order] WHERE [Order].nameOrder LIKE '%" + key + "%';";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                orders = new List<Order>();
                ConvertDataTableOrder(orders, table);
                if (orders.Count == 0)
                {
                    var msg = "Không tìm thấy kết quả nào.";
                    var title = "Kết quả tìm kiếm";
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowSearchedOrder(orders);
                }
            }
        }

        private void BtnSearchCustommerClick(object sender, EventArgs e)
        {
            var key = txtSearchCustommer.Text;
            tblCustommer.Rows.Clear();
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();

            if (comboSeachCustommer.SelectedIndex == -1)
            {
                var msg = "Vui lòng chọn tiêu chí tìm kiếm để tiếp tục";
                var title = "Lỗi dữ liệu";
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboSeachCustommer.SelectedIndex == 0)
            {
                command.CommandText = "SELECT * FROM [Order] WHERE [Order].idOrder = " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                custommers = new List<Custommer>();
                ConvertDataTableCustommer(custommers, table);
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
            else if (comboSeachCustommer.SelectedIndex == 1)
            {
                command.CommandText = "SELECT * FROM [Order] WHERE [Order].idOrder LIKE " + key + ";";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                custommers = new List<Custommer>();
                ConvertDataTableCustommer(custommers, table);
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
        }

        private void tabControlClick(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                CategoryClick(sender, e);
            }
            else if (tabControl.SelectedIndex == 1)
            {
                OrderClick(sender, e);
            }
            else if (tabControl.SelectedIndex == 2)
            {
                BookPayClick(sender, e);
            }
            else
            {
                ReportClick(sender, e);
            }
        }

        private void CategoryClick(object sender, EventArgs e)
        {
            if (tabControlCategory.SelectedIndex == 0)
            {
                ShowCompany();
            }
            else if (tabControlCategory.SelectedIndex == 1)
            {
                ShowAuthor();
            }
            else if (tabControlCategory.SelectedIndex == 2)
            {
                ShowType();
            }
            else if (tabControlCategory.SelectedIndex == 3)
            {
                ShowBook();
            }
            else
            {
                ShowExchangeBook();
            }
        }

        private void OrderClick(object sender, EventArgs e)
        {
            if (tabControlOrder.SelectedIndex == 0)
            {
                ShowOrder();
            }
            else
            {
                ShowOrderBill();
            }
        }

        private void BookPayClick(object sender, EventArgs e)
        {
            if (tabControlBookPay.SelectedIndex == 0)
            {
                ShowCustommer();
            }
            else if (tabControlBookPay.SelectedIndex == 1)
            {
                ShowBill();
            }
            else if (tabControlBookPay.SelectedIndex == 2)
            {
                ShowDiscount();
            }
            else
            {
                ShowPayment();
            }
        }

        private void ShowResultReportRevenue(DateTime keySearched)
        {
            int total = 0;
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT BillBook.idBook, Book.nameBook, SUM(BillBook.numberBook) AS totalNumberBook, Book.price, SUM(Book.price * BillBook.numberBook) AS totalPrice FROM BillBook JOIN Book ON BillBook.idBook = Book.idBook JOIN Bill ON Bill.idBill = BillBook.idBill WHERE MONTH(Bill.CreateDate) = " + keySearched.ToString("MM") + " AND YEAR(Bill.CreateDate) = " + keySearched.ToString("yyyy") + " GROUP BY BillBook.idBook, Book.nameBook, Book.price;";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView7.Rows.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                dataGridView7.Rows.Add(new object[]
                {
                        Convert.ToInt32(table.Rows[i]["idBook"]), table.Rows[i]["nameBook"].ToString(), Convert.ToInt32(table.Rows[i]["totalNumberBook"]), Convert.ToInt32(table.Rows[i]["price"]), Convert.ToInt32(table.Rows[i]["totalPrice"])
                });
                total += Convert.ToInt32(table.Rows[i]["totalPrice"]);
            }
            lbResultReportRevenue.Text = $"Tổng doanh thu theo tháng: {total:0} (Đồng)";
            connection.Close();
        }

        private void btnResultReportRevenueClick(object sender, EventArgs e)
        {
            DateTime keySearched = dtpkMonth.Value;
            ShowResultReportRevenue(keySearched);
        }

        private void ReportClick(object sender, EventArgs e)
        {
            if (tabControlReport.SelectedIndex == 0)
            {
                int totalBook = 0;
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT idBook, nameBook, number FROM Book";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                tblBookWarehouse.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tblBookWarehouse.Rows.Add(new object[]
                    {
                        Convert.ToInt32(table.Rows[i]["idBook"]), table.Rows[i]["nameBook"].ToString(), Convert.ToInt32(table.Rows[i]["number"])
                    });
                    totalBook += Convert.ToInt32(table.Rows[i]["number"]);
                }
                lbShowTotalBook.Text = $"Tổng số sách hiện tại trong kho: {totalBook:0}(Quyển)";
                connection.Close();
            }
            else if (tabControlReport.SelectedIndex == 1)
            {
                int totalBookPay = 0;
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT BillBook.idBook, Book.nameBook, SUM(BillBook.numberBook) AS totalBuyedBook FROM BillBook JOIN Book ON BillBook.idBook = Book.idBook GROUP BY BillBook.idBook, Book.nameBook ORDER BY SUM(BillBook.numberBook) DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                tblBuyedBook.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tblBuyedBook.Rows.Add(new object[]
                    {
                        Convert.ToInt32(table.Rows[i]["idBook"]), table.Rows[i]["nameBook"].ToString(), Convert.ToInt32(table.Rows[i]["totalBuyedBook"])
                    });
                    totalBookPay += Convert.ToInt32(table.Rows[i]["totalBuyedBook"]);
                }
                lbShowBuyedBook.Text = $"Tổng số sách đã bán: {totalBookPay:0}(Quyển)";
                connection.Close();
            }
            else if (tabControlReport.SelectedIndex == 2)
            {
                DateTime keySearched = dtpkMonth.Value;
                ShowResultReportRevenue(keySearched);
            }
            else
            {
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT Custommer.idCustommer, Custommer.nameCustommer, SUM(Bill.PayTotal) AS totalPayPrice FROM Custommer JOIN Bill ON Custommer.nameCustommer = Bill.nameCustommer GROUP BY Custommer.idCustommer, Custommer.nameCustommer ORDER BY SUM(Bill.PayTotal) DESC;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                lbCustommerPotential.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    lbCustommerPotential.Rows.Add(new object[]
                    {
                        Convert.ToInt32(table.Rows[i]["idCustommer"]), table.Rows[i]["nameCustommer"].ToString(), Convert.ToInt32(table.Rows[i]["totalPayPrice"])
                    });
                }
                connection.Close();
            }
        }


    }
}
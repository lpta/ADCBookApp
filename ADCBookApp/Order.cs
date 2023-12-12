using System;

namespace ADCBookApp
{
    public class Order
    {
        public int idOrder { get; set; }
        public string nameOrder { get; set; }
        public DateTime CreateDateOrder { get; set; }
        public int BillTotal { get; set; }
        public string StatusOrder { get; set; }
        public DateTime BillDate { get; set; }
    }
}

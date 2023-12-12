using System;

namespace ADCBookApp
{
    public class Bill
    {
        public int idBill { get; set; }
        public string nameCustommer { get; set; }
        public int DiscountValue { get; set; }
        public float PayTotal { get; set; }
        public float TotalPriceDiscount { get; set; }
        public string status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

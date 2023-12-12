using System;

namespace ADCBookApp
{
    public class Discount
    {
        public int idDiscount { get; set; }
        public string nameDiscount { get; set; }
        public DateTime StartDiscountDate { get; set; }
        public DateTime EndDiscountDate { get; set; }
        public int DiscountValue { get; set; }
    }
}

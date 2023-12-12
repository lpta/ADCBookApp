using System;

namespace ADCBookApp
{
    public class ExchangeBook
    {
        public int idExchangeBook { get; set; }
        public int idBook { get; set; }
        public string nameBook { get; set; }
        public int number { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDay { get; set; }
    }
}

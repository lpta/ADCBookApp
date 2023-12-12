using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCBookApp
{
    public class Company
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }

        public Company()
        {
        }

        public Company(string companyName, string address, string phoneNumber)
        {
            this.companyName = companyName;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public Company(int companyId, string companyName, string address, string phoneNumber)
        {
            this.companyId = companyId;
            this.companyName = companyName;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

    }
}

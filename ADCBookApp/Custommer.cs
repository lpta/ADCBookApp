using System;

namespace ADCBookApp
{
    public class Custommer
    {
        public int idCustommer { get; set; }
        public string nameCustommer { get; set; }
        public DateTime BirstDay { get; set; }
        public string Address { get; set; }
        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreateAccount { get; set; }

        public Custommer()
        {
        }

        public Custommer(int idCustommer, string nameCustommer, DateTime birstDay, string address, string phoneNumber, string email)
        {
            this.idCustommer = idCustommer;
            this.nameCustommer = nameCustommer;
            BirstDay = birstDay;
            Address = address;
            this.phoneNumber = phoneNumber;
            Email = email;
        }

        public Custommer(int idCustommer, string nameCustommer, DateTime birstDay, string address, string phoneNumber, string email, DateTime createAccount)
        {
            this.idCustommer = idCustommer;
            this.nameCustommer = nameCustommer;
            BirstDay = birstDay;
            Address = address;
            this.phoneNumber = phoneNumber;
            Email = email;
            CreateAccount = createAccount;
        }
    }
}

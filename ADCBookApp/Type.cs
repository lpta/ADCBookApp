using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCBookApp
{
    public class Type
    {
        public int idType { get; set; }
        public string nameType { get; set; }

        public Type()
        {
        }

        public Type(int idType, string nameType)
        {
            this.idType = idType;
            this.nameType = nameType;
        }

        public Type(string nameType)
        {
            this.nameType = nameType;
        }
    }
}

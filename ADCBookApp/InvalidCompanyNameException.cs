using System;

namespace ADCBookApp
{
    public class InvalidCompanyNameException : Exception
    {
        public string InvalidItemName { get; set; }

        public InvalidCompanyNameException() : base() { }
        public InvalidCompanyNameException(string message) : base(message) { }
        public InvalidCompanyNameException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidCompanyNameException(string message, string invalidName) : base(message) { 
            InvalidItemName = invalidName;
        }
    }
}

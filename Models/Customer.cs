using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDataWithSqlClient.Models
{
    public class Customer
    {
        public int Id { get; set; } //not used when inserting
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        
        public Customer (int id, string fname, string lname, string country, string postcode, string tlf, string email)
        {
            this.Id = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.Country = country;
            this.PostalCode = postcode;
            this.PhoneNumber = tlf;
            this.Email = email;
        }

        public Customer()
        {
        }

        public override string ToString()
        {
            return "Customer data: Id: "+ this.Id + " Name: " + this.FirstName + " " + this.LastName + " Country: " + this.Country + " PostCode: " + this.PostalCode + " TLF: " + this.PhoneNumber + " Email: " + this.Email; 
        }
    }
}

using ReadingDataWithSqlClient.DataAccess;
using ReadingDataWithSqlClient.Models;
using System;
using System.Data.SqlClient;

namespace ReadingDataWithSqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository cr = new CustomerRepository();
            //cr.GetCustomer();
            //Customer c=cr.GetCustomerByID(34);
            //Console.WriteLine(c.ToString());
            //cr.InsertCustomer(new Customer( -1, "Ola", "Nordmann", "Norge", "5555", "40404040", "test@email.com"));
            // cr.UpdateCustomer(new Customer(60, "Kari", "Nordmann", "Norge", "5555", "30303030", "test@email.com"));
            //cr.DeleteCustomer(60);
            //Customer c=cr.GetCustomerByName("Ola");
            //Console.WriteLine(c.ToString());
            //cr.GetCustomerLimited(10, 5);
            //cr.GetCustomersPerCountry();
            //cr.GetCustomersBigSpender();
            cr.GetCustomersFavoriteGenre(new Customer(-1, "Frank", "Harris","","","","")); // virker ikke
        }
    }
}

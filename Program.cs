using ReadingDataWithSqlClient.DataAccess;
using System;
using System.Data.SqlClient;

namespace ReadingDataWithSqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository cr = new CustomerRepository();
            cr.GetCustomer();
        }
    }
}

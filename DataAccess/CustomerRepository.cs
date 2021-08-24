using Microsoft.Data.SqlClient;
using ReadingDataWithSqlClient.Models;
using System;
using System.Collections.Generic;

namespace ReadingDataWithSqlClient.DataAccess
{
    class CustomerRepository : ICustomerRepository
    {
        public void DeleteCustomer(int customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomer()
        {
            List<Customer> c = new List<Customer>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                //IEnumerable<Customer> c;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    //Console.WriteLine("Done. \n");
                    //string sql = "SELECT * FROM dbo.Customer";
                    string sql = "SELECT CustomerId, FirstName, LastName, ISNULL(Country, ''), ISNULL(PostalCode,''), ISNULL(Phone,''), ISNULL(Email,'') FROM dbo.Customer";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine($"{reader.GetName(0)} \t {reader.GetName(1)}\t {reader.GetName(2)} \t {reader.GetName(3)} \t {reader.GetName(4)} \t {reader.GetName(5)} \t {reader.GetName(6)}");
                            Console.WriteLine("--------------------------------");
                           
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string fname = reader.GetString(1);
                                string lname = reader.GetString(2);
                                string country = reader.GetString(3);
                                string pcode = reader.GetString(4);
                                string tlf = reader.GetString(5);
                                string email = reader.GetString(6);
                                Customer customer = new Customer(id, fname, lname, country, pcode, tlf, email);
                                Console.WriteLine(customer.ToString());
                                c.Add(customer);
                                

                            }
                             /*
                            Console.WriteLine("--------------------------------");
                            */

                        }
                    }
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return c;
        }

        public Customer GetCustomerByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        public void ExecuteQuery()
        {

        }
    }
}

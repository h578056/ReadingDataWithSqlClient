using Microsoft.Data.SqlClient;
using ReadingDataWithSqlClient.Models;
using System;
using System.Collections.Generic;

namespace ReadingDataWithSqlClient.DataAccess
{
    class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomer()
        {
            List<Customer> c = new List<Customer>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
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
                                Console.WriteLine("--------------------------------");

                            }
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
            Customer c = new Customer();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                
                string sql = "SELECT CustomerId, FirstName, LastName, ISNULL(Country, ''), ISNULL(PostalCode,''), ISNULL(Phone,''), ISNULL(Email,'') FROM Chinook.dbo.Customer WHERE CustomerId = @CustomerID";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                c.Id = reader.GetInt32(0);
                                c.FirstName = reader.GetString(1);
                                c.LastName = reader.GetString(2);
                                c.Country = reader.GetString(3);
                                c.PostalCode = reader.GetString(4);
                                c.PhoneNumber = reader.GetString(5);
                                c.Email = reader.GetString(6);
                                //Console.WriteLine(c.ToString());
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return c;
        }
        public Customer GetCustomerByName(string name)
        {
            Customer c = new Customer();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;

                string sql = "SELECT CustomerId, FirstName, LastName, ISNULL(Country, ''), ISNULL(PostalCode,''), ISNULL(Phone,''), ISNULL(Email,'') FROM Chinook.dbo.Customer WHERE FirstName = @name";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                c.Id = reader.GetInt32(0);
                                c.FirstName = reader.GetString(1);
                                c.LastName = reader.GetString(2);
                                c.Country = reader.GetString(3);
                                c.PostalCode = reader.GetString(4);
                                c.PhoneNumber = reader.GetString(5);
                                c.Email = reader.GetString(6);
                                //Console.WriteLine(c.ToString());
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return c;
        }
        public IEnumerable<Customer> GetCustomerLimited(int limit, int offset)
        {
            List<Customer> c = new List<Customer>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT CustomerId, FirstName, LastName, ISNULL(Country, ''), ISNULL(PostalCode,''), ISNULL(Phone,''), ISNULL(Email,'') FROM Chinook.dbo.Customer " +
                                 "ORDER BY CustomerId OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@limit", limit);
                        command.Parameters.AddWithValue("@offset", offset);
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
                                Console.WriteLine("--------------------------------");

                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return c;
        }
        public void InsertCustomer(Customer customer)
        {
            bool inserted = false;
            string sql= "INSERT INTO Chinook.dbo.Customer(FirstName, LastName, Country, PostalCode, Phone, Email)" +
                "VALUES(@FirstName, @LastName, @Country , @PostalCode, @Phone, @Email)";
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customer.Id);
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        inserted = command.ExecuteNonQuery() > 0 ? true : false;
                        Console.WriteLine("OK:" + inserted);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            bool updated = false;
            string sql = "UPDATE Chinook.dbo.Customer SET FirstName = @Firstname, LastName= @Lastname, Country = @Country, Postalcode = @PostalCode, Phone = @Phone, Email=@Email " +
                " WHERE CustomerId = @CustomerId";
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customer.Id);
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        updated = command.ExecuteNonQuery() > 0 ? true : false;
                        Console.WriteLine("OK:" + updated);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ExecuteQuery()
        {

        }
        public void DeleteCustomer(int customerId)
        {
            bool deleted = false;
            
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    string sql = "DELETE FROM Chinook.dbo.Customer WHERE CustomerId=@CustomerId";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        deleted = command.ExecuteNonQuery() > 0 ? true : false;
                        Console.WriteLine("OK: " + deleted);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void GetCustomersPerCountry()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT Country, Count( *) AS 'Number of Customers' FROM Chinook.dbo.Customer GROUP BY Country ORDER BY Count( *) DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine($"{reader.GetName(0)} \t {reader.GetName(1)}");
                            Console.WriteLine("--------------------------------");

                            while (reader.Read())
                            {
                                string country = reader.GetString(0);
                                int amount = reader.GetInt32(1);
                                Console.WriteLine(country + " | " + amount);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetCustomersBigSpender() 
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT MAX(Total) AS TotalSpent, Customer.FirstName, Customer.LastName FROM dbo.Invoice " +
                        "INNER JOIN Customer " +
                        "ON Customer.CustomerId = Invoice.CustomerId " +
                        "GROUP BY  Customer.FirstName, Customer.LastName " +
                        "ORDER BY MAX(Total) DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine($"{reader.GetName(0)} \t {reader.GetName(1)} \t {reader.GetName(2)}");
                            Console.WriteLine("--------------------------------");

                            while (reader.Read())
                            {
                                decimal total = reader.GetDecimal(0);
                                string fname = reader.GetString(1);
                                string lname = reader.GetString(2);
                                Console.WriteLine(total + " | " + fname + " " + lname);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetCustomersFavoriteGenre(Customer c)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ND-5CG0257SQQ\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT TOP 1 WITH TIES g.Name AS FavoriteGenre, FirstName, LastName, SUM(il.Quantity * il.UnitPrice) AS AmountSpent" +
                        "FROM Invoice i " +
                        "JOIN Customer c ON i.CustomerId = c.CustomerId " +
                        "JOIN InvoiceLine il ON il.Invoiceid = i.InvoiceId JOIN Track t ON t.TrackId = il.Trackid " +
                        "JOIN Genre g ON t.GenreId = g.GenreId " +
                        "WHERE FirstName = @FirstName AND LastName = @LastName " +
                        "GROUP BY  c.FirstName, g.Name, FirstName, LastName " +
                        "ORDER BY AmountSpent DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", c.FirstName);
                        command.Parameters.AddWithValue("@LastName", c.LastName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine($"{reader.GetName(0)} \t {reader.GetName(1)} \t {reader.GetName(2)}");
                            Console.WriteLine("--------------------------------");

                            while (reader.Read())
                            {
                                string total = reader.GetString(0);
                                string fname = reader.GetString(1);
                                string lname = reader.GetString(2);
                                decimal l = reader.GetDecimal(3);
                                Console.WriteLine(total + " | " + fname + " " + lname + " | " +l);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

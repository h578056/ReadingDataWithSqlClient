using ReadingDataWithSqlClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDataWithSqlClient.DataAccess
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomer();
        Customer GetCustomerByID(int customerId);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customer);
        void UpdateCustomer(Customer customer);
    }
}

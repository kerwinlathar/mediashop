using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLibary
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        void UpdateCustomer(int customerIdToUppdate, Customer updatecustomer);
        void RemoveCustomer(int customerIdToRemove);
        void AddCustomer(Customer customerToAdd);
    }
}

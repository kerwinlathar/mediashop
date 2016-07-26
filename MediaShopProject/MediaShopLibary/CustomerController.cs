using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLibary
{
    public class CustomerController: ICustomerRepository
    {
         private ModelMediaShopData content;

        public CustomerController(ModelMediaShopData content)
        {
            this.content = content;
        }

        public List<Customer> GetAllCustomers()
        {
            return content.customers.ToList();
        }

        public void AddCustomer(Customer customerToAdd)
        {
            content.customers.Add(customerToAdd);
            content.SaveChanges();
        }


        public void RemoveCustomer(int customerIdToRemove)
        {
            var customerremove = content.customers.Where(x => x.id == customerIdToRemove);
            foreach (Customer customer_check in customerremove)
            {
                if (customer_check.id == customerIdToRemove)
                {
                    content.customers.Remove(customer_check);

                }

            }
            content.SaveChanges();
        }


        public void UpdateCustomer(int customerIdToUppdate, Customer updatecustomer)
        {
            var datatest = content.customers.Where(c => c.id == customerIdToUppdate).Count();

            if (datatest != 0)
            {
                var datacust = content.customers.Where(x => x.id == customerIdToUppdate).First();

                datacust.name = updatecustomer.name;
            }

            content.SaveChanges();
        }

       

       
    }
}

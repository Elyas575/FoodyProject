using Entities.Models;

using System.Collections.Generic;

namespace Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers(bool trackChanges);




        Customer GetCustomer(Guid customerId, bool trackChanges);

       


        void CreateCustomer(Customer customer);
     
        void DeleteCustomer(Customer customer);


    }
}

using Entities.Models;

using System.Collections.Generic;

namespace Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers(bool trackChanges);
        
    }
}

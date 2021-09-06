using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerContactRepository
    {

        Task<IEnumerable<CustomerContact>> GetAllCustomersContactAsync(Guid customerId, bool trackChanges);
        Task<CustomerContact> GetCustomerContactAsync(Guid customerId, Guid id, bool trackChanges);


        void CreateCustomerContact(Guid customerId, CustomerContact customercontact);
    }
}

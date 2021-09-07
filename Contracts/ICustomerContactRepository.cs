using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerContactRepository
    {

        Task<IEnumerable<CustomerContact>> GetAllCustomersContactAsync(string customerId, bool trackChanges);
        Task<CustomerContact> GetCustomerContactAsync(string customerId, string id, bool trackChanges);


        void CreateCustomerContact(string customerId, CustomerContact customercontact);
    }
}

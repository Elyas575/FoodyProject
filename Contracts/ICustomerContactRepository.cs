using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerContactRepository
    {
        Task<IEnumerable<CustomerContact>> GetAllCustomerContactAsync(bool trackChanges);
        Task<CustomerContact> GetCustomerContactAsync(int customerId, int CustomerContactId, bool trackChanges);
        void CreateCustomerContact(int customerId, CustomerContact customercontact);
        void DeleteCustomerContact(CustomerContact customerContact);
    }
}
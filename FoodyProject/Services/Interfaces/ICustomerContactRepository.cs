using Entities.Models;
using FoodyProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerContactRepository
    {
        Task<PagedList<CustomerContact>> GetAllCustomersContactsAsync(CustomerContactParameters customerContactParameters, bool trackChanges);
        Task<CustomerContact> GetCustomerContactAsync(int customerId, int CustomerContactId, bool trackChanges);
        Task<PagedList<CustomerContact>> GetAllContactsForCustomer(int customerId, CustomerContactParameters customerContactParameters, bool trackChanges);
        void CreateCustomerContact(int customerId, CustomerContact customercontact);
        void DeleteCustomerContact(CustomerContact customerContact);
    }
}
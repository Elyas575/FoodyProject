using Entities.Models;
using FoodyProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerRepository
    {
        Task<PagedList<Customer>> GetAllCustomersAsync(bool trackChanges, CustomerParameters customerParameters);
        Task<Customer> GetCustomerAsync(int customerId, bool trackChanges);
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
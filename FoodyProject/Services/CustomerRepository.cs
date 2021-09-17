using Contracts;
using Entities;
using Entities.Models;
using FoodyProject.Models;
using Microsoft.EntityFrameworkCore;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }

        public async Task<PagedList<Customer>> GetAllCustomersAsync(bool trackChanges, CustomerParameters customerParameters)
        {
            var customers = await FindAll(trackChanges)
                .OrderBy(c => c.CustomerId)
                .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
                .Take(customerParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Customer>(customers, customerParameters.PageNumber, customerParameters.PageSize, count);
        }

        public async Task<Customer> GetCustomerAsync(int customerId, bool trackChanges) =>
             await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }
    }
}
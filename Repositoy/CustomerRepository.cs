using Contracts;
using Entities;
using Entities.Models;
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

        public void CreateCustomer(Customer customer) => Create(customer);


        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges) =>
              await FindAll(trackChanges)
              .OrderBy(c => c.Name)
              .ToListAsync();

        public async Task<IEnumerable<Customer>> GetByIdsAsync(IEnumerable<string> ids, bool
        trackChanges) =>
         await FindByCondition(c => ids.ToList().Contains(c.CustomerId.ToString()), trackChanges)
         .ToListAsync();


        public async Task<Customer> GetCustomerAsync(string customerId, bool trackChanges) =>
             await FindByCondition(c => c.CustomerId.Equals(customerId) , trackChanges)
            .SingleOrDefaultAsync();
      
    }



}


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
    public class CustomerContactRepository : RepositoryBase<CustomerContact>, ICustomerContactRepository
    {
        public CustomerContactRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateCustomerContact(string customerId, CustomerContact customercontact)
        {
            customercontact.CustomerId = customerId;
            Create(customercontact);
        }

        public async Task<IEnumerable<CustomerContact>> GetAllCustomersContactAsync(string customerId, bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(c => c.CustomerContactId)
        .ToListAsync();



        public async Task<CustomerContact> GetCustomerContactAsync(string customerId, string id, bool trackChanges) =>
         await FindByCondition(c => c.CustomerId.Equals(customerId) && c.CustomerContactId.Equals(id),
        trackChanges)
         .SingleOrDefaultAsync();
    }

}

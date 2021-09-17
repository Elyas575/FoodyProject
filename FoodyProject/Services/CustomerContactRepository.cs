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
    public class CustomerContactRepository : RepositoryBase<CustomerContact>, ICustomerContactRepository
    {
        public CustomerContactRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<PagedList<CustomerContact>> GetAllCustomersContactsAsync(CustomerContactParameters customerContactParameters, bool trackChanges)
        {
            var customers = await FindAll(trackChanges)
              .OrderBy(c => c.CustomerId)
              .Skip((customerContactParameters.PageNumber - 1) * customerContactParameters.PageSize)
              .Take(customerContactParameters.PageSize)
              .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<CustomerContact>(customers, customerContactParameters.PageNumber, customerContactParameters.PageSize, count);
        }

        public async Task<PagedList<CustomerContact>> GetAllContactsForCustomer(int customerId, CustomerContactParameters customerContactParameters, bool trackChanges)
        {
            var customers = await FindAll(trackChanges)
              .OrderBy(c => c.CustomerId)
                .Skip((customerContactParameters.PageNumber - 1) * customerContactParameters.PageSize)
                .Take(customerContactParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<CustomerContact>(customers, customerContactParameters.PageNumber, customerContactParameters.PageSize, count);
        }

        public async Task<CustomerContact> GetCustomerContactAsync(int customerId, int CustomerContactId, bool trackChanges) =>
            await FindByCondition(c => c.CustomerId.Equals(customerId) && c.CustomerContactId.Equals(CustomerContactId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateCustomerContact(int customerId, CustomerContact customercontact)
        {
            customercontact.CustomerId = customerId;
            Create(customercontact);
        }

        public void DeleteCustomerContact(CustomerContact customerContact)
        {
            Delete(customerContact);
        }
    }
}
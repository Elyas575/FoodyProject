using Entities;
using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using FoodyProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Services
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

        // Test it????
        public async Task<PagedList<CustomerContact>> GetAllContactsForCustomerAsync(int customerId, CustomerContactParameters customerContactParameters, bool trackChanges)
        {
            var customers = await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges)
                .OrderBy(c => c.CustomerId)
                .Skip((customerContactParameters.PageNumber - 1) * customerContactParameters.PageSize)
                .Take(customerContactParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<CustomerContact>(customers, customerContactParameters.PageNumber, customerContactParameters.PageSize, count);
        }

        public async Task<CustomerContact> GetCustomerContactAsync(int customerId, int CustomerContactId, bool trackChanges) =>
            await FindByCondition(c => c.CustomerId.Equals(customerId) && c.Id.Equals(CustomerContactId), trackChanges)
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
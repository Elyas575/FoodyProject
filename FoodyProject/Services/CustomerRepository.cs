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
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }

        public async Task<PagedList<Customer>> GetAllCustomersAsync(bool trackChanges, CustomerParameters customerParameters)
        {
            var customers = await FindAll(trackChanges)
                .Include(x => x.CustomerContacts)
                .OrderBy(c => c.Id)
                .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
                .Take(customerParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Customer>(customers, customerParameters.PageNumber, customerParameters.PageSize, count);
        }

        public async Task<Customer> GetCustomerAsync(int customerId, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(customerId), trackChanges)
            .Include(x => x.CustomerContacts)
            .SingleOrDefaultAsync();

        public void CreateCustomer(Customer customer) => Create(customer);
        
        public void DeleteCustomer(Customer customer) => Delete(customer);
    }
}
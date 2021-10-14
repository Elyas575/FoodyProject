using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
{
    public interface ICustomerRepository
    {
        Task<PagedList<Customer>> GetAllCustomersAsync(bool trackChanges, CustomerParameters customerParameters);
        Task<Customer> GetCustomerAsync(int customerId, bool trackChanges);
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
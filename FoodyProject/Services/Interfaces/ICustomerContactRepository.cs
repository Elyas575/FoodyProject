using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
{
    public interface ICustomerContactRepository
    {
        Task<PagedList<CustomerContact>> GetAllCustomersContactsAsync(CustomerContactParameters customerContactParameters, bool trackChanges);
        Task<CustomerContact> GetCustomerContactAsync(int customerId, int CustomerContactId, bool trackChanges);
        Task<PagedList<CustomerContact>> GetAllContactsForCustomerAsync(int customerId, CustomerContactParameters customerContactParameters, bool trackChanges);
        void CreateCustomerContact(int customerId, CustomerContact customercontact);
        void DeleteCustomerContact(CustomerContact customerContact);
    }
}
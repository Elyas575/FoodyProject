using Contracts;
using Entities;
using Entities.Models;
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

        public void CreateCustomerContact(Guid customerId, CustomerContact customercontact)
        {
            customercontact.CustomerId = customerId;
            Create(customercontact);
        }

        public IEnumerable<CustomerContact> GetAllCustomerContact(Guid customerId, bool trackChanges) =>
        FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges)
        .OrderBy(c => c.CustomerAddress);


        public CustomerContact GetCustomerContact(Guid customerId, Guid id, bool trackChanges) =>
         FindByCondition(c => c.CustomerId.Equals(customerId) && c.CustomerContactId.Equals(id),
        trackChanges)
         .SingleOrDefault();
    }

}

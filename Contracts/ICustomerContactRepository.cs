using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICustomerContactRepository
    {

        IEnumerable<CustomerContact> GetAllCustomerContact(Guid customerId, bool trackChanges);
        CustomerContact GetCustomerContact(Guid customerId, Guid id, bool trackChanges);


        void CreateCustomerContact(Guid customerId, CustomerContact customercontact);
    }
}

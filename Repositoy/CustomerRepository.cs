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

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges) =>
              FindAll(trackChanges)
              .OrderBy(c => c.Name)
              .ToList();


        public Customer GetCustomer(Guid customerId, bool trackChanges) =>
             FindByCondition(c => c.CustomerId.Equals(customerId) , trackChanges)
            .SingleOrDefault();
      
    }



}


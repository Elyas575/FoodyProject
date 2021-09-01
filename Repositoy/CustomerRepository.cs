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
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }


        public IEnumerable<Customer> GetAllCustomers(bool trackChanges) =>
 FindAll(trackChanges)
 .OrderBy(c => c.Name)
 .ToList();
    }



}


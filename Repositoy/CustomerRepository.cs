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


<<<<<<< HEAD
                    public IEnumerable<Customer> GetAllCustomers(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToList();
                }
=======
            public IEnumerable<Customer> GetAllCustomers(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToList();
            }
>>>>>>> dc07ab4fcb8ea4f3523fd2d15cd918233a278ec3



}


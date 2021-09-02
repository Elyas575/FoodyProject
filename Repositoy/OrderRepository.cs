using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
 

 public IEnumerable<Order> GetAllOrders(bool trackChanges) =>
 FindAll(trackChanges)
 .OrderBy(c => c.OrderId)
 .ToList();

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
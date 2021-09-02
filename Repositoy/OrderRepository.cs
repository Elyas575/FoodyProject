using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void CreateOrders(Order order)
        {
            throw new NotImplementedException();
        }
        []
        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public void DeleteOrders(Order orders)
        {
            Delete(orders);
        }

    
        public Task<IEnumerable<Order>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(Guid companyId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
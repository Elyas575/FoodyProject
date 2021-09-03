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
        public Order GetOrder(Guid id, bool trackChanges) =>
             FindByCondition(c => c.OrderId.Equals(id), trackChanges)
             .SingleOrDefault();


        public void CreateOrder(Guid customerId,   Order order)
        {
            order.CustomerId = customerId;
            Create(order);
        }


        public IEnumerable<Order> GetAllOrders(bool trackChanges) =>
         FindAll(trackChanges)
         .OrderBy(c => c.OrderId)
         .ToList();

     
      
       
        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public void DeleteOrders(Order orders)
        {
            Delete(orders);
        }

    
       

    }
}
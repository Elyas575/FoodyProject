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
        public Order GetOrder(Guid orderid, bool trackChanges) =>
             FindByCondition(c => c.OrderId.Equals(orderid), trackChanges)
             .SingleOrDefault();

        /*  getting a single order for resturant */

     
        /* fix this u should get all orders for one resturant */
        public IEnumerable<Order> GetAllOrders(bool trackChanges) =>
         FindAll(trackChanges)
         .OrderBy(c => c.OrderId)
         .ToList();

        /* fix this u should get all orders for one resturant */
        public void CreateOrder(Guid customerId, Order order)
        {
            order.CustomerId = customerId;
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public IEnumerable<Order> GetOrdersForRestaurantByMealId(Guid MealId, bool trackchanges)
        {
            throw new NotImplementedException();
        }

    }
}
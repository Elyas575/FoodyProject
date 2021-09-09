using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task <Order>  GetOrderAsync(int orderid, bool trackChanges) =>
             await FindByCondition(c => c.OrderId.Equals(orderid), trackChanges)
             .SingleOrDefaultAsync();

        /*  getting a single order for resturant */
        /* fix this u should get all orders for one resturant */
        public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
         .OrderBy(c => c.OrderId)
         .ToListAsync();
    
        /* fix this u should get all orders for one resturant */
        public void CreateOrder(int customerId, Order order)
        {
            order.CustomerId = customerId;
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }
    }
}
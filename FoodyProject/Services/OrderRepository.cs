using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using FoodyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<PagedList<Order>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges)
        {
            var orders = await FindAll(trackChanges)
                 .OrderBy(e => e.OrderId)
                 .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
                 .Take(orderParameters.PageSize)
                 .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Order>(orders, orderParameters.PageNumber, orderParameters.PageSize, count);
        }


        public async Task<PagedList<Order>> GetOrdersForRestaurantAsync(int restaurantid, OrderParameters orderParameters, bool trackChanges)
        {
            var orders = await FindByCondition(e => e.RestaurantId.Equals(restaurantid), trackChanges)
           .OrderBy(e => e.OrderId)
           .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
           .Take(orderParameters.PageSize)
           .ToListAsync();

            var count = await FindByCondition(e => e.RestaurantId.Equals(restaurantid), trackChanges).CountAsync();

            return new PagedList<Order>(orders, orderParameters.PageNumber, orderParameters.PageSize, count);
        }
        
        public async Task<Order> GetOrderAsync(int orderid, bool trackChanges) =>
             await FindByCondition(c => c.OrderId.Equals(orderid), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<PagedList<Order>> GetOrderByCustomerIdAsync(int customerid, OrderParameters orderParameters, bool trackChanges)
        {
            var orderbycustomerid = await FindByCondition(c => c.CustomerId.Equals(customerid), trackChanges)
            .OrderBy(c => c.OrderId)
            .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
            .Take(orderParameters.PageSize)
            .ToListAsync();

            var count = await FindByCondition(c => c.CustomerId.Equals(customerid), trackChanges).CountAsync();

            return new PagedList<Order>(orderbycustomerid, orderParameters.PageNumber, orderParameters.PageSize, count);
        }

        public void CreateOrder(int customerId, int restaurantId, Order order)
        {
            order.CustomerId = customerId;
            order.RestaurantId = restaurantId;
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }
    }
}
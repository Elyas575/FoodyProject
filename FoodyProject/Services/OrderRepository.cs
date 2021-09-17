﻿using System;
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

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges, OrderParameters orderParameters) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.OrderId)
            .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
            .Take(orderParameters.PageSize)
            .ToListAsync();

        public async Task<IEnumerable<Order>> GetOrdersForRestaurantAsync(int restaurantid, OrderParameters orderParameters, bool trackChanges) =>
            await FindByCondition(e => e.RestaurantId.Equals(restaurantid), trackChanges)
            .OrderBy(e => e.OrderId)
            .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
            .Take(orderParameters.PageSize)
            .ToListAsync();

        public async Task <Order>  GetOrderAsync(int orderid, bool trackChanges) =>
             await FindByCondition(c => c.OrderId.Equals(orderid), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(int customerid, bool trackChanges) =>
              await FindByCondition(c => c.CustomerId.Equals(customerid), trackChanges)
              .OrderBy(c => c.OrderId)
              .ToListAsync();

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
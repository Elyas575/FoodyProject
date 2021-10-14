using Entities;
using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using FoodyProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Services
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
                 .OrderBy(e => e.Id)
                 .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
                 .Take(orderParameters.PageSize)
                 .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Order>(orders, orderParameters.PageNumber, orderParameters.PageSize, count);
        }

        public async Task<PagedList<Order>> GetOrdersByRestaurantIdAsync(int restaurantId, OrderParameters orderParameters, bool trackChanges)
        {
            var orders = await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
           .OrderBy(e => e.Id)
           .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
           .Take(orderParameters.PageSize)
           .ToListAsync();

            var count = await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges).CountAsync();

            return new PagedList<Order>(orders, orderParameters.PageNumber, orderParameters.PageSize, count);
        }

        public async Task<PagedList<Order>> GetOrderByCustomerIdAsync(int customerId, OrderParameters orderParameters, bool trackChanges)
        {
            var orderByCustomerId = await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges)
            .OrderBy(c => c.Id)
            .Skip((orderParameters.PageNumber - 1) * orderParameters.PageSize)
            .Take(orderParameters.PageSize)
            .ToListAsync();

            var count = await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges).CountAsync();

            return new PagedList<Order>(orderByCustomerId, orderParameters.PageNumber, orderParameters.PageSize, count);
        }

        public async Task<Order> GetOrderAsync(int orderId, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(orderId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateOrder(int customerId, int restaurantId, Order order)
        {
            order.CustomerId = customerId;
            order.RestaurantId = restaurantId;
            Create(order);
        }

        public void DeleteOrder(Order order) => Delete(order);
    }
}
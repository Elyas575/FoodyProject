using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using FoodyProject.Models;

namespace Contracts
{
    public interface IOrderRepository
    {
        Task<PagedList<Order>> GetOrderByCustomerIdAsync(int customerid, OrderParameters orderParameters, bool trackChanges);
        Task<PagedList<Order>> GetOrdersForRestaurantAsync(int restaurantid, OrderParameters employeeParameters, bool trackChanges);

        Task<PagedList<Order>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges);
        Task<Order> GetOrderAsync(int orderId, bool trackChanges);
        void CreateOrder(int customerId, int restaurantId, Order order);
        void DeleteOrder(Order order);
    }
}
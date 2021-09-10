using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
namespace Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(int customerid, bool trackChanges);
        Task<IEnumerable<Order>> GetOrdersForRestaurantAsync(int restaurantid, bool trackChanges);
        Task<IEnumerable<Order>>  GetAllOrdersAsync(bool trackChanges);
        Task<Order> GetOrderAsync(int orderId,bool trackChanges);
        /*  getting a single order for resturant, order = employee, resturant = meals */
        void CreateOrder(int customerId, int restaurantId, Order order);
        void DeleteOrder(Order order);
    }
}
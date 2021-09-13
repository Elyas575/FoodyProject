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
        Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(int customerid, bool trackChanges);
        Task<IEnumerable<Order>> GetOrdersForRestaurantAsync(int restaurantid, OrderParameters employeeParameters, bool trackChanges);

        Task<IEnumerable<Order>>  GetAllOrdersAsync(bool trackChanges, OrderParameters orderParameters);
        Task<Order> GetOrderAsync(int orderId,bool trackChanges);
        /*  getting a single order for resturant, order = employee, resturant = meals */
        void CreateOrder(int customerId, int restaurantId, Order order);
        void DeleteOrder(Order order);
       
    }
}
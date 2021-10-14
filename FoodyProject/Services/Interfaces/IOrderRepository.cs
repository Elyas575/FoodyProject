using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
{
    public interface IOrderRepository
    {
        Task<PagedList<Order>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges);
        Task<PagedList<Order>> GetOrdersByRestaurantIdAsync(int restaurantid, OrderParameters employeeParameters, bool trackChanges);
        Task<PagedList<Order>> GetOrderByCustomerIdAsync(int customerid, OrderParameters orderParameters, bool trackChanges);
        Task<Order> GetOrderAsync(int orderId, bool trackChanges);
        void CreateOrder(int customerId, int restaurantId, Order order);
        void DeleteOrder(Order order);
    }
}
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

       Task<IEnumerable<Order>>  GetAllOrdersAsync(bool trackChanges);
        Task<Order> GetOrderAsync(Guid orderId,bool trackChanges);

        /*  getting a single order for resturant, order = employee, resturant = meals */


      Task<IEnumerable<Order>>   GetOrdersForRestaurantByMealIdAsync(Guid MealId, bool trackchanges);



        void CreateOrder(Guid customerId, Order order);

        void DeleteOrder(Order order);
   
      
            

    }
}

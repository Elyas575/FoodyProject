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
        IEnumerable<Order> GetAllOrders(bool trackChanges);
        Order GetOrder(Guid id,bool trackChanges);

        
        void CreateOrder(Guid customerId, Order order);

        void DeleteOrder(Order order);
        void DeleteOrders(Order orders);
      


    }
}

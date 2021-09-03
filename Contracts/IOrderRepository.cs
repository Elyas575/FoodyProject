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

        void CreateOrder(Order order, bool trackchanges);
        void CreateOrders(Order order);
        Task<IEnumerable<Order>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteOrder(Order order);
        void DeleteOrders(Order orders);
      


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }
        ICustomerContactRepository CustomerContact { get; }
        ICustomerRepository Customer { get; }
        IMealRepository Meal { get; }
        IOrderRepository Order { get; }
        IRestaurantRepository Restaurant { get; }
        IRestaurantContactRepository RestaurantContact { get; }
        Task SaveAsync();
    }
}
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
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
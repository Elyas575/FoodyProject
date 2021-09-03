
using Contracts;
using Entities;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICategoryRepository _categoryRepository;
        private ICustomerContactRepository _customerContactRepository;
        private ICustomerRepository _customerRepository;
        private IMealRepository _mealRepository;
        private IOrderRepository _orderRepository;
        private IRestaurantRepository _restaurantRepository;
        private IMealOptionRepository _mealOptionRepository;
        private IRestaurantContactRepository _restaurantContactRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository( _repositoryContext);
                return _categoryRepository;
            }
        }

        public ICustomerContactRepository CustomerContact
        {
            get
            {
                if (_customerContactRepository == null)
                    _customerContactRepository = new CustomerContactRepository(_repositoryContext);
                return _customerContactRepository;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_repositoryContext);
                return _customerRepository;
            }
        }

        public IMealOptionRepository MealOption
        {
            get
            {
                if (_mealOptionRepository == null)
                    _mealOptionRepository = new MealOptionRepository(_repositoryContext);
                return _mealOptionRepository;
            }
        }

        public IMealRepository Meal
        {
            get
            {
                if (_mealRepository == null)
                    _mealRepository = new MealRepository(_repositoryContext);
                return _mealRepository;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository== null)
                    _orderRepository = new OrderRepository(_repositoryContext);
                return _orderRepository;
            }
        }

        public IRestaurantContactRepository RestaurantContact
        {
            get
            {
                if (_restaurantContactRepository == null)
                    _restaurantContactRepository = new RestaurantContactRepository(_repositoryContext);
                return _restaurantContactRepository;
            }
        }

        public IRestaurantRepository Restaurant
        {
            get
            {
               if (_restaurantRepository == null)
                     
                    _restaurantRepository = new RestaurantRepository(_repositoryContext);
                return _restaurantRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();



    }
}

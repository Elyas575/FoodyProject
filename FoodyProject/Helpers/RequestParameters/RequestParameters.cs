namespace FoodyProject.Helpers.RequestParameters
{
  public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    public class RestaurantParameters : RequestParameters
    {
        public string SearchTerm { get; set; }
    }

    public class RestaurantContactParameters : RequestParameters 
    {
        public string SearchTerm { get; set; } 
    }
    public class CategoryParameters : RequestParameters { }
    public class MealParameters : RequestParameters { }
    public class CustomerParameters : RequestParameters { }
    public class CustomerContactParameters : RequestParameters { }
    public class OrderParameters : RequestParameters { }
}

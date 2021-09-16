using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FoodyProject.Models
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
    public class OrderParameters : RequestParameters
    {
    }

    public class RestaurantContactParameters :  RequestParameters
    {

    }

    public class RestaurantParameters: RequestParameters
    {

    }
}
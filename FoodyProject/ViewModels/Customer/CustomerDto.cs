using FoodyProject.ViewModels.CustomerContact;
using System.Collections.Generic;

namespace FoodyProject.ViewModels.Customer
{
    public class CustomerDto : CustomerBase
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public ICollection<CustomerContactDto> CustomerContacts { get; set; }
    }
}
using System;

namespace DiscountManagement.Domain.DomainObjects
{
    public class User
    {
        public string Name { get; set; }

        public DateTime? FirstPurchaseDate { get; set; }
        
    }

    public class Customer : User{}

    public class Employee : User{}

    public class Affiliate : User{}

}

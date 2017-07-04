using System.Collections.Generic;
using DiscountManagement.Domain.DomainObjects;

namespace DiscountManagement.Test.UnitTest
{
    public class TestDataSource
    {
        public static Order Order
        {
            get
            {
                Order order = new Order()
;
                Product product1 = new Product { Name = "Mobile", Price = 500, Type = new ProductCategory("Electronics")};
                Product product2 = new Product { Name = "Soap", Price = 400, Type = new ProductCategory("General")};
                Product product3 = new Product { Name = "Vegetable", Price = 95, Type = new ProductCategory("Groceries") };

                CartItem cartItem1 = new CartItem(product1, 1);
                CartItem cartItem2 = new CartItem(product2, 1);
                CartItem cartItem3 = new CartItem(product3, 1);

                order.AddProducts(new List<CartItem> { cartItem1, cartItem2, cartItem3 });

                return order;
            }
        }
    }
}

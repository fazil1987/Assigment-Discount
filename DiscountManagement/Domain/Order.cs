using System.Collections.Generic;
using System.Linq;

namespace DiscountManagement.Domain
{
    public class Order
    {
        public User OrderedBy { get;  set ; }    

        public List<CartItem> CartItems { get; private set; }

        public int Total => CartItems.Sum(i => i.Product.Price * i.Quantity);

        public Order()
        {
            CartItems = new List<CartItem>();
        }

        public void AddProduct(CartItem cartItem)
        {
            CartItems.Add(cartItem);
        }

        public void AddProducts(List<CartItem> cartItems)
        {
            CartItems.AddRange(cartItems);
        }

    }
}

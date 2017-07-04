using System;
using System.Linq;

namespace DiscountManagement.Domain.DiscountRules
{
    public abstract class PercentBasedDiscountRuleBase : IDiscountRule
    {
        private readonly decimal _percent;
        private readonly Func<Product, bool> _productCriteria;
        
        protected abstract bool IsMatch(User user);

        protected PercentBasedDiscountRuleBase( decimal percent, Func<Product,bool> productCriteria = null )
        {
            _percent = percent;
            _productCriteria = productCriteria ?? (i => true);
        }

        public decimal CalculateDiscount(Order order)
        {
            decimal discountAmount = 0;

            if (IsMatch(order.OrderedBy))
            {
                var eligibleAmount = order.CartItems.Where(i => _productCriteria(i.Product)).Sum(i => i.Product.Price * i.Quantity);
                discountAmount = eligibleAmount * (_percent / 100);
            }

            return discountAmount;
        }

    }

   
   
}
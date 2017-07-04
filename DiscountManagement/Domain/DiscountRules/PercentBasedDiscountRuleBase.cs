using System;
using System.Linq;
using DiscountManagement.Domain.DomainObjects;
using DiscountManagement.Domain.NamedCriteria;

namespace DiscountManagement.Domain.DiscountRules
{
    public abstract class PercentBasedDiscountRuleBase : IDiscountRule
    {
        private readonly decimal _percent;
        private readonly Criteria<Product> _productCriteria;
        
        protected abstract bool IsMatch(User user);

        protected PercentBasedDiscountRuleBase( decimal percent, Criteria<Product> productCriteria )
        {
            _percent = percent;
            _productCriteria = productCriteria ?? new ProductExclusionCriteria();
        }

        public decimal CalculateDiscount(Order order)
        {
            decimal discountAmount = 0;

            if (IsMatch(order.OrderedBy))
            {
                var eligibleAmount = order.CartItems.Where(i => _productCriteria?.Validate(i.Product) ?? true).Sum(i => i.Product.Price * i.Quantity);
                discountAmount = eligibleAmount * (_percent / 100);
            }

            return discountAmount;
        }

    }

   
   
}
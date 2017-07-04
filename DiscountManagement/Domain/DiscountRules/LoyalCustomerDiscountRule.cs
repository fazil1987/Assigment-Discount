using System;
using DiscountManagement.Domain.DomainObjects;
using DiscountManagement.Domain.Extension;
using DiscountManagement.Domain.NamedCriteria;

namespace DiscountManagement.Domain.DiscountRules
{
    public class LoyalCustomerDiscountRule : PercentBasedDiscountRuleBase 
    {
        private readonly int _yearsAsCustomer;
        private readonly DateTime? _dateToCompare; 
        // Useful in unit testing as system.DateTime due to its dynamic nature, not ideal candidate for unit Testing

        public LoyalCustomerDiscountRule(decimal percent, int yearsAsCustomer, DateTime? dateToCompare = null,
            Criteria<Product> productCriteria = null) : base(percent, productCriteria)
        {
            _yearsAsCustomer = yearsAsCustomer;
            _dateToCompare = dateToCompare ?? DateTime.Now;
        }

        protected override bool IsMatch(User user)
        {
            return user.GetType() == typeof(Customer) && user.IsCustomerFor(_yearsAsCustomer, _dateToCompare);
        }
    }
}
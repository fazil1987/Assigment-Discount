using System;
using DiscountManagement.Extension;

namespace DiscountManagement.Domain.DiscountRules
{
    public class LoyalCustomerDiscountRule : PercentBasedDiscountRuleBase 
    {
        private readonly int _yearsAsCustomer;
        private readonly DateTime? _dateToCompare; // Useful in unit testing as system.DateTime is very unreliable

        public LoyalCustomerDiscountRule(decimal percent, int yearsAsCustomer, Func<Product, bool> productCriteria,
            DateTime? dateToCompare = null) : base(percent, productCriteria)
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
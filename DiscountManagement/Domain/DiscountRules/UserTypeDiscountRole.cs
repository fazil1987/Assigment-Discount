using System;
using DiscountManagement.Domain.DomainObjects;

namespace DiscountManagement.Domain.DiscountRules
{
    public class UserTypeDiscountRule<T> : PercentBasedDiscountRuleBase where T : User
    {
        public UserTypeDiscountRule(decimal percent, Func<Product, bool> productCriteria = null) : base(percent, productCriteria)
        {
        }

        protected override bool IsMatch(User user)
        {
            return user.GetType() == typeof(T);
        }
    }
}

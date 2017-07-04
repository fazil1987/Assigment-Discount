using System;
using DiscountManagement.Domain.DomainObjects;
using DiscountManagement.Domain.NamedCriteria;

namespace DiscountManagement.Domain.DiscountRules
{
    public class UserTypeDiscountRule<T> : PercentBasedDiscountRuleBase where T : User
    {
        public UserTypeDiscountRule(decimal percent, Criteria<Product> productCriteria) : base(percent, productCriteria)
        {
        }

        protected override bool IsMatch(User user)
        {
            return user.GetType() == typeof(T);
        }
    }
    
}

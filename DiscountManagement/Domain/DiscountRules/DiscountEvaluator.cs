using System;
using System.Collections.Generic;

namespace DiscountManagement.Domain.DiscountRules
{
    public class DiscountEvaluator : IDiscountEvaluator
    {
        private readonly IEnumerable<IDiscountRule> _rules;

        public DiscountEvaluator(IEnumerable<IDiscountRule> rules)
        {
            _rules = rules;
        }

        public decimal Evaluate(Order order)
        {
            decimal discount = 0;

            foreach (var rule in _rules)
            {
                discount = Math.Max(rule.CalculateDiscount(order), discount);
            }

            return discount;
        }

    }
}

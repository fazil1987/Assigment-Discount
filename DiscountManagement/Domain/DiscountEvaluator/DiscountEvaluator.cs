using System;
using System.Collections.Generic;
using DiscountManagement.Domain.DomainObjects;
using DiscountManagement.Domain.DiscountRules;

namespace DiscountManagement.Domain.DiscountEvaluator
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

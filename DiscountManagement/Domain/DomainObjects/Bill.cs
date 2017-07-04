using System;
using DiscountManagement.Domain.DiscountEvaluator;

namespace DiscountManagement.Domain.DomainObjects
{
    public class Bill
    {
        private readonly IDiscountEvaluator _discountEvaluator;
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public Order Order { get; private set; }

        private bool _isDiscountApplied;

        public Bill(Order order, IDiscountEvaluator discountEvaluator )
        {
            Id = Guid.NewGuid();
            Order = order;
            Amount = order.Total;
            _discountEvaluator = discountEvaluator;
        }

        public decimal ApplyDiscount()
        {
            if (!_isDiscountApplied)
            {
                Amount -= _discountEvaluator.Evaluate(Order);
                _isDiscountApplied = true;
            }

            return Amount;
        }

    }
}
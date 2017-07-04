using DiscountManagement.Domain.DomainObjects;

namespace DiscountManagement.Domain.DiscountRules
{
    public class BillAmountDiscountRule : IDiscountRule
    {
        private readonly int _billAmount;
        private readonly int _discountAmount;

        public BillAmountDiscountRule(int billAmount, int discountAmount)
        {
            _billAmount = billAmount;
            _discountAmount = discountAmount;
        }
        public decimal CalculateDiscount(Order order)
        {
            return (order.Total / _billAmount) * _discountAmount;
        }
    }
}
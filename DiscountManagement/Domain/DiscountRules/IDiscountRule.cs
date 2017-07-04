using DiscountManagement.Domain.DomainObjects;

namespace DiscountManagement.Domain.DiscountRules
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Order order);
    }
}
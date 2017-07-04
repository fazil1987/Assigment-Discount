using DiscountManagement.Domain.DomainObjects;

namespace DiscountManagement.Domain.DiscountEvaluator
{
    public interface IDiscountEvaluator
    {
        decimal Evaluate(Order order);
    }
}
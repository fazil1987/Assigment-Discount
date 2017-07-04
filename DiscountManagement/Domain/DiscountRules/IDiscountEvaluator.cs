namespace DiscountManagement.Domain.DiscountRules
{
    public interface IDiscountEvaluator
    {
        decimal Evaluate(Order order);
    }
}
using System;
using DiscountManagement.Domain.DomainObjects;

namespace DiscountManagement.Domain.Extension
{
    public static class CustomerExtension
    {
        public static bool IsCustomerFor(this User user, int numberOfYears, DateTime? dateToCompareAgainst = null)
        {
            numberOfYears = -1 * numberOfYears;
            var dateToBeCompared = dateToCompareAgainst ?? DateTime.Now;

            return user.FirstPurchaseDate.Value < dateToBeCompared.AddYears(numberOfYears);
        }
    }
}

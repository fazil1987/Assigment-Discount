using System;
using DiscountManagement.Domain;

namespace DiscountManagement.Extension
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

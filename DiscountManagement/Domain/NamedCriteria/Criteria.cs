using System;

namespace DiscountManagement.Domain.NamedCriteria
{
    public abstract class Criteria<T> where T : class
    {
        protected Func<T, bool> _criteria;

        protected Criteria() => _criteria = (i => true);

        public bool Validate(T type) => _criteria(type);
    }
}

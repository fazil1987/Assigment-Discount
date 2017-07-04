using DiscountManagement.Domain.DomainObjects;

namespace DiscountManagement.Domain.NamedCriteria
{
    class ProductExclusionCriteria : Criteria<Product>
    {
        public ProductExclusionCriteria ExcludeCategory(string category)
        {
            _criteria = (i) => i.Type.Name != category;
            return this;
        }
    }
}
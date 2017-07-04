namespace DiscountManagement.Domain
{
    public class Product
    {
        public ProductCategory Type { get; set; }

        public int Price { get; set; }

        public string Name { get; set; }

    }

    public struct ProductCategory
    {
        public string Name { get; set; }

        public ProductCategory(string name)
        { 
            Name = name;
        }
    }

}

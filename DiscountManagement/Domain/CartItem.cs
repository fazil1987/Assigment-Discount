namespace DiscountManagement.Domain
{
    public struct CartItem
    {
        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}

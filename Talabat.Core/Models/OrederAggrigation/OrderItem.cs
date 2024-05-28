namespace Talabat.Core.Models.OrederAggrigation
{
    public class OrderItem : BaseEntity
    {

        public OrderItem() { }

        public OrderItem(ProductItemOrderd orderWithProduct, decimal price, int quantity)
        {
            OrderWithProduct = orderWithProduct;
            Price = price;
            Quantity = quantity;
        }

        public ProductItemOrderd OrderWithProduct {  get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
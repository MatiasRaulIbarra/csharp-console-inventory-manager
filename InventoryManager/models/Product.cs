namespace InventoryManager.models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public Product(string name, decimal price, int amount)
        {
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

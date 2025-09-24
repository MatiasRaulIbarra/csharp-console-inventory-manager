using InventoryManager.models;

namespace InventoryManager.services
{
    public interface IIinventoryService
    {
        public void AddProduct(Product product);
        public Product? GetProductByName(string name);
        public void DeleteProductByName(string name);
        public void UpdateProduct(string name, decimal newPrice,int newAmount);

        public List<Product> GetProducts();
        
        
    }
}

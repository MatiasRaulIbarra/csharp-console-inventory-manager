using InventoryManager.models;

namespace InventoryManager.services
{
    public class InventoryService : IIinventoryService
    {
        private List<Product> productsList;

        public InventoryService( List<Product> products)
        {
            productsList = products;
        }


        public Product? GetProductByName(string name)
        {
            foreach (var product in productsList)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }

        public List<Product> GetProducts()
        {
            return productsList;
        }


        public void AddProduct(Product product)
        {
            productsList.Add(product);
        }

        public void UpdateProduct(string name, decimal newPrice, int newAmount)
        {
            var searchProduct = GetProductByName(name);
            if (searchProduct != null)
            {
                searchProduct.Price = newPrice;
                searchProduct.Amount = newAmount;
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DeleteProductByName(string name)
        {
            var deleteProduct = GetProductByName(name);
            if (deleteProduct != null)
            {
                productsList.Remove(deleteProduct);
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }


    }
}

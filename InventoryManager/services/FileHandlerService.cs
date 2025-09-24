using InventoryManager.models;
using System.Text.Json;
using System.IO;

namespace InventoryManager.services
{
    public class FileHandlerService : IFileHandlerService
    {
        string filePath = "task.json";




        public List<Product> LoadInventory(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonFromFile = File.ReadAllText(filePath);
                Console.WriteLine($"JSON read from file: {jsonFromFile}");
                List<Product> restoredProducts = JsonSerializer.Deserialize<List<Product>>(jsonFromFile);
                foreach (var product in restoredProducts)
                {
                    Console.WriteLine($"Product: {product.Name},Price: {product.Price},Amount: {product.Amount}");
                }
                return restoredProducts;
            }
            else
            {
                return new List<Product>();
            }
        }

        public void SaveInventory(List<Product> products, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, jsonString);
        }
    }
}

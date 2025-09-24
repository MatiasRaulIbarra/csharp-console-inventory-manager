

using InventoryManager.models;
using System.Security.Cryptography.X509Certificates;

namespace InventoryManager.services
{
    public interface IFileHandlerService
    {
        public void SaveInventory(List<Product> products, string filePath);
        
        public  List<Product> LoadInventory(string filePath);
        
    }
}

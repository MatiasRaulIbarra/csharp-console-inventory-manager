using InventoryManager.models;
using InventoryManager.services;

internal class Program
{
    private static void Main(string[] args)
    {
        int shouldExit = 0;
        string filePath = "inventory.json";
        IFileHandlerService _fileHandlerService = new FileHandlerService();
        List<Product> allProducts = _fileHandlerService.LoadInventory(filePath);
        IIinventoryService _inventoryService = new InventoryService(allProducts);
       




        while (shouldExit != 5)
        {
            string name;
            string price;
            string amount;
            Console.Clear();
            Console.WriteLine("--- Inventory Manager ---");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1.Add Product.");
            Console.WriteLine("2.Show all the inventory.");
            Console.WriteLine("3.Update Product");
            Console.WriteLine("4.Delete Product.");
            Console.WriteLine("5.Save and exit.");

            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int option))
            {
                Console.Clear();

                switch (option)
                {
                    case 1:


                        Console.WriteLine("\nPlease enter a name: ");
                        name = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Error:Input not valid.");
                            return;
                        }


                        Console.WriteLine("\nPlease enter a price: ");
                        price = Console.ReadLine();

                        if (!decimal.TryParse(price, out decimal decimalPrice))
                        {
                            Console.WriteLine("Error: Input not valid.");
                            return;

                        }

                        Console.WriteLine("\nPlease enter an amount.");
                        amount = Console.ReadLine();
                        if (!int.TryParse(amount, out int intAmount))
                        {
                            Console.WriteLine("Error: Input not valid.");
                            return;
                        }

                        Product addProduct = new Product(name, decimalPrice, intAmount);

                        _inventoryService.AddProduct(addProduct);
                        Console.WriteLine("The product was added successfully.");
                        Console.ReadKey();
                        break;
                    case 2:
                        List<Product> products = _inventoryService.GetProducts();
                        foreach (var product in products)
                        {
                            Console.WriteLine($"Product : {product.Name}, Price: {product.Price}, Amount: {product.Amount}");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Please enter a product name to modify.");
                        name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Error: Name can't be empty.");
                            return;
                        }

                        Product productFound = _inventoryService.GetProductByName(name);
                        if (productFound == null)
                        {
                            Console.WriteLine("Product not found.");
                            return;
                        }

                        Console.WriteLine("\nPlease enter a price to modify: ");
                        price = Console.ReadLine();

                        if (!decimal.TryParse(price, out decimal updatePrice))
                        {
                            Console.WriteLine("Error:Input not valid.");
                            return;

                        }

                        Console.WriteLine("\nPlease enter an amount to modify.");
                        amount = Console.ReadLine();
                        if (!int.TryParse(amount, out int updateAmount))
                        {
                            Console.WriteLine("Error: Input not valid.");
                            return;
                        }

                        _inventoryService.UpdateProduct(name, updatePrice, updateAmount);
                        Console.WriteLine("The product was  updated successfully.");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Please enter a product name to delete.");
                        name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Error: Name can't be empty.");
                            return;
                        }

                        Product productDelete = _inventoryService.GetProductByName(name);
                        if (productDelete == null)
                        {
                            Console.WriteLine("Product not found.");
                            return;
                        }

                        _inventoryService.DeleteProductByName(name);
                        Console.WriteLine("The product was deleted successfully.");
                        Console.ReadKey();
                        break;
                    case 5:
                        List<Product> currentProducts = _inventoryService.GetProducts();
                        _fileHandlerService.SaveInventory(currentProducts, filePath);
                        Console.WriteLine("Inventory saved.Exiting application.");
                        shouldExit = 5;
                        break;


                    default:
                        Console.WriteLine("Invalid option. Please try again");
                        Console.ReadKey();
                        break;

                }
            }
            else
            {
                Console.Write("Invalid input. Press any key to try again.");
                Console.ReadKey();
            }
        }
    }
}
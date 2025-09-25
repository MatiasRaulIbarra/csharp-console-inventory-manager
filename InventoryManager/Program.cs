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
            Console.Clear();
            Console.WriteLine("--- Inventory Manager ---");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1.Add Product.");
            Console.WriteLine("2.Show all inventory.");
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

                        string name = GetStringInput("Please enter a name: ");
                        decimal price = GetDecimalInput("Please enter a price: ");
                        int amount = GetIntInput("Please enter an amount: ");


                        Product addProduct = new Product(name, price, amount);

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

                        string updatename = GetStringInput("Please enter a product name to modify.");

                        Product productFound = _inventoryService.GetProductByName(updatename);
                        if (productFound == null)
                        {
                            Console.WriteLine("Product not found.");
                            break;
                        }

                        decimal updatePrice = GetDecimalInput("\nPlease enter a price to modify: ");

                        int updateAmount = GetIntInput("\nPlease enter an amount to modify.");

                        _inventoryService.UpdateProduct(updatename,updatePrice,updateAmount);
                        Console.WriteLine("The product was updated successfully.");
                        Console.ReadKey();
                        break;
                    case 4:
                        string deleteName = GetStringInput("Please enter a product name to delete.");
                        Product productDelete = _inventoryService.GetProductByName(deleteName);
                        if (productDelete == null)
                        {
                            Console.WriteLine("Product not found.");
                            break;
                        }

                        _inventoryService.DeleteProductByName(deleteName);
                        Console.WriteLine("The product was deleted successfully.");
                        Console.ReadKey();
                        break;
                    case 5:
                        List<Product> currentProducts = _inventoryService.GetProducts();
                        _fileHandlerService.SaveInventory(currentProducts, filePath);
                        Console.WriteLine("Inventory saved. Exiting application.");
                        shouldExit = 5;
                        break;


                    default:
                        Console.WriteLine("Invalid option. Please try again.");
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

    public static decimal GetDecimalInput(string prompt)
    {
        decimal result;
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out result))
            {
                return result;
            }

            Console.WriteLine("Error: Invalid price.");
        }
    }

    public static int GetIntInput(string prompt)
    {
        int result;
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                return result;
            }
            Console.WriteLine("Error: Invalid amount.");
        }
    }

    public static string GetStringInput(string prompt)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Name can't be empty.");
            }
        }
        while (string.IsNullOrWhiteSpace(input));
        return input.Trim();
    }

}

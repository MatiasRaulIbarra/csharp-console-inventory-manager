# Csharp-Console-Inventory-Manager and Description 💻

Description: This is a console-based inventory manager developed in C#. It allows users to add, update, delete, and display products. The application uses JSON serialization to ensure the persistence of inventory data between sessions.

## Technologies Used
* C# .NET: The principal language.

* Object-Oriented Programming (OOP): For modular code design and scalability.

* JSON Serialization (System.Text.Json): To save and manage inventory data in a persistent manner.

* Exception Handling: To safely manage invalid user input.

* Collections (List<T>): To store and manage the list of products.

## Project Characteristics
* Product Management: Allows creating, updating, and deleting products via a console interface.

* Robust Input Validation: The validation functions prevent errors and ensure the program doesn't crash due to invalid inputs.

* Data Persistence: The inventory is automatically saved to a JSON file when the program ends and loaded when the application starts.

* Console Interface: Features a simple and clear user menu for navigating options.

* Refactoring and Clean Code: The code has been refactored to implement the "Don't Repeat Yourself" (DRY) principle, which makes it easier to maintain and scale.

## Procject Structure
```
/csharp-console-inventory-manager
├── InventoryManager/
│   ├── models/
│   │   └── Product.cs
│   ├── services/
│   │   ├── FileHandlerService.cs
│   │   ├── IFileHandlerService.cs
│   │   ├── InventoryService.cs
│   │   └── IInventoryService.cs
│   └── Program.cs
├── inventory.json
└── README.md 
```
### How to Run the Project

1.  **Clone the repository to your local machine:**
    ```bash
    git clone https://github.com/MatiasRaulIbarra/csharp-console-inventory-manager.git
    ```

2.  **Navigate to the main project folder:**
    ```bash
    cd InventoryManager
    ```

3.  **Compile and run the application from your terminal:**
    ```bash
    dotnet run
    ```

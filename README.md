# SqliteConnectionLib

**SqliteConnectionLib** is a simple library for connecting and managing an SQLite database, designed to be used in .NET MAUI applications.

## Features

- Easy management of SQLite connections.
- Integration with **Microsoft.Maui.Storage** for database path management within MAUI apps.
- Flexibility to create and manage custom tables in your project.

## Installation

To install the **SqliteConnectionLib** package in your .NET MAUI project, run the following command:

```bash
dotnet add package SqliteConnectionLib
```


# Usage
## 1. Initialize the Database
In your MAUI project, use the package to easily access the database path and create your own tables.

## 2. Create a Database Service
Create a DatabaseService class in your MAUI project that handles the connection and manages custom tables.

Here is an example of the implementation:

```bash
using SqliteConnectionLib;  // Import the SqliteConnectionLib package
using SQLite;
using System.Collections.Generic;

namespace SqliteMauiApp.Services
{
    public class DatabaseService
    {
        private SQLiteConnection _connection;

        public DatabaseService()
        {
            // Initialize the connection using SqliteConnectionLib
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.flags);

            // Create a custom table (e.g., Product)
            _connection.CreateTable<Product>();
        }

        // Method to insert a new record into the Product table
        public void AddProduct(Product product)
        {
            _connection.Insert(product);
        }

        // Method to retrieve all records from the Product table
        public List<Product> GetProducts()
        {
            return _connection.Table<Product>().ToList();
        }

        // Method to close the connection
        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
```

## 3. Define Your Table Model
Define a class representing your SQLite table. For example, a Product table might look like this:

```bash
public class Product
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

## 4. Use the Database Service in Your MAUI Application
Once the database service is ready, you can use it within your MAUI pages. Here's how to insert and display data using the DatabaseService:
```bash
public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public MainPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;

        // Add a new product
        var product = new Product
        {
            Name = "Product A",
            Price = 10.99m
        };
        _databaseService.AddProduct(product);

        // Get and print all products
        var products = _databaseService.GetProducts();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}");
        }
    }
}
```

## 5. Register the DatabaseService in MAUI
To use the DatabaseService in your MAUI app, you need to register it in MauiProgram.cs:

```bash
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Register DatabaseService as a singleton
        builder.Services.AddSingleton<DatabaseService>();

        return builder.Build();
    }
}
```

## 6. Build and Run the Application
You can now build and run your MAUI application. The data should be successfully inserted into and retrieved from the SQLite database.

With SqliteConnectionLib, you can easily set up and manage your SQLite database in a .NET MAUI app, allowing for flexible and customized database table management.

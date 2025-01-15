using System;
using System.Collections.Generic;
using System.Linq;



public class Product
{
    private int _id;
    private string _name;
    private decimal _price;
    private int _quantity;
    private string _category;
    private int _stock;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }

    public int Stock
    {
        get { return _stock; }
        set { _stock = value; }
    }

    public Product(int id, string name, decimal price, string category, int stock)
    {
        _id = id;
        _name = name;
        _price = price;
        _quantity = 1;
        _category = category;
        _stock = stock;
    }
}


public class ShoppingCart
{
    private List<Product> products = new List<Product>();
    private DateTime lastActivity;
    private const decimal DiscountRate = 0.1M;
    private const decimal TaxRate = 0.07M;
    private TimeSpan cartExpirationTime = TimeSpan.FromMinutes(1);

    public ShoppingCart()
    {
        lastActivity = DateTime.Now;
    }

    public void AddProduct(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("\nQuantity should be at least 1.");
            return;
        }

        CheckCartExpiration();
        UpdateActivity();

        var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {

            if (existingProduct.Stock < quantity)
            {
                Console.WriteLine($"\nOnly {existingProduct.Stock} items available in stock.");
                return;
            }
            existingProduct.Quantity += quantity;
            existingProduct.Stock -= quantity;
        }
        else
        {

            if (product.Stock < quantity)
            {
                Console.WriteLine($"\nOnly {product.Stock} items available in stock.");
                return;
            }
            product.Quantity = quantity;
            product.Stock -= quantity;
            products.Add(product);
        }

        if (product.Stock <= 5)
        {
            Console.WriteLine($"\nWarning: Only {product.Stock} items left in stock!");
        }

        Console.WriteLine($"\n{quantity} x {product.Name} has been added to your cart.");
    }



    public void RemoveProduct(int productId)
    {
        CheckCartExpiration();
        UpdateActivity();

        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            Console.WriteLine($"\nYou have {product.Quantity} x {product.Name} in your cart.");
            Console.Write("\nDo you want to remove all quantities (y/n)? ");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                products.Remove(product);
                Console.WriteLine($"\n{product.Name} has been removed from your cart.");
            }
            else
            {
                Console.Write("\nEnter the quantity to remove: ");
                if (int.TryParse(Console.ReadLine(), out int quantityToRemove))
                {
                    if (quantityToRemove <= 0)
                    {
                        Console.WriteLine("\nInvalid quantity entered.");
                        return;
                    }

                    if (quantityToRemove >= product.Quantity)
                    {
                        products.Remove(product);
                        Console.WriteLine($"\n{product.Name} has been fully removed from your cart.");
                    }
                    else
                    {
                        product.Quantity -= quantityToRemove;
                        Console.WriteLine($"\n{quantityToRemove} x {product.Name} removed. Remaining: {product.Quantity}");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid quantity entered.");
                }
            }
        }
        else
        {
            Console.WriteLine("\nProduct not found in the cart.");
        }
    }

    public void ViewCart()
    {
        CheckCartExpiration();

        if (products.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
            return;
        }

        Console.WriteLine("\nYour Cart:");
        foreach (var product in products)
        {
            Console.WriteLine($"\nProduct: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}, Category: {product.Category}, ID: {product.Id}, Stock left: {product.Stock}");
        }
    }


    public void GetTotalPrice()
    {
        CheckCartExpiration();

        decimal subtotal = products.Sum(p => p.Price * p.Quantity);
        decimal discountAmount = subtotal * DiscountRate;
        decimal taxAmount = (subtotal - discountAmount) * TaxRate;
        decimal total = subtotal - discountAmount + taxAmount;

        // Display prices
        Console.WriteLine($"\nSubtotal (before discount): {subtotal:C}");
        Console.WriteLine($"\nDiscount: {discountAmount:C}");
        Console.WriteLine($"\nTax: {taxAmount:C}");
        Console.WriteLine($"\nTotal (after discount and tax): {total:C}");
    }

    public void Checkout()
    {
        CheckCartExpiration();
        UpdateActivity();

        if (products.Count == 0)
        {
            Console.WriteLine("Your cart is empty.Are You Sure you Want to Checkout.");
            return;
        }
        Console.WriteLine("\n===============================");
        Console.WriteLine("      Bill and Payments  ");
        Console.WriteLine("===============================");
        Console.WriteLine("\nProceeding to checkout...");
        Console.WriteLine("\nCheckout Time: " + DateTime.Now.ToString("f"));
        GetTotalPrice();
        products.Clear();
        Console.WriteLine("\n===============================");
        Console.WriteLine("Thank you for your purchase!");
        Console.WriteLine("===============================");
    }

    public void ShowRecommendations(List<Product> allProducts)
    {
        CheckCartExpiration();
        UpdateActivity();

        if (!products.Any())
        {
            Console.WriteLine("No products in the cart, so no recommendations at this time.");
            return;
        }

        Console.WriteLine("You might also like these products:\n");
        var categoriesInCart = products.Select(p => p.Category).Distinct();
        var recommendations = allProducts.Where(p => categoriesInCart.Contains(p.Category) && !products.Contains(p)).Take(5);

        if (!recommendations.Any())
        {
            recommendations = allProducts.Where(p => !products.Contains(p)).Take(5);
        }

        foreach (var recommendation in recommendations)
        {
            Console.WriteLine($"Product: {recommendation.Name}, Price: {recommendation.Price:C}, Category: {recommendation.Category}");
        }
    }

    public void ExpireCart()
    {
        if (DateTime.Now - lastActivity > cartExpirationTime)
        {
            products.Clear();
            Console.WriteLine("Your cart has expired due to inactivity.");
        }
        else
        {
            Console.WriteLine("Your cart is still active.");
        }
    }

    private void UpdateActivity()
    {
        lastActivity = DateTime.Now;
    }

    private void CheckCartExpiration()
    {
        if (DateTime.Now - lastActivity > cartExpirationTime)
        {
            Console.WriteLine("Your cart has expired.");
            products.Clear();
        }
    }
}

class Program
{
    static void Main()
    {

        Console.Title = "ShoppingCart";


        string logo = @"
 __        __   _                          _ 
 \ \      / /__| | ___ ___  _ __ ___   ___| |
  \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ |
   \ V  V /  __/ | (_| (_) | | | | | |  __/_|
    \_/\_/ \___|_|\___\___/|_| |_| |_|\___(_)
                                             ";

        // Calculate the console width
        int consoleWidth = Console.WindowWidth;

        // Split the ASCII art into lines
        string[] logoLines = logo.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Display the ASCII art centered
        foreach (var line in logoLines)
        {
            int padding = (consoleWidth - line.Length) / 2; 
            Console.WriteLine(new string(' ', padding) + line); 
        }

        Console.WriteLine(new string('=', consoleWidth - 1));


        Console.Write("\n\nPlease Enter your Name: ");
        string username = Console.ReadLine();


        Console.WriteLine($"\nHello, {username}! Enjoy your shopping experience!");

        Console.WriteLine("\nPress any key to Continue...");
        Console.ReadKey();



        int currentId = 1;

        var cart = new ShoppingCart();
        var allProducts = new List<Product>
       {
    new Product(currentId++, "Laptop", 1000M, "Electronics", 5),
    new Product(currentId++, "Headphones", 200M, "Electronics", 10),
    new Product(currentId++, "T-Shirt", 25M, "Clothing", 50),
    new Product(currentId++, "Shoes", 80M, "Clothing", 30),
    new Product(currentId++, "Coffee Maker", 150M, "Appliances", 15),
    new Product(currentId++, "Smartphone", 800M, "Electronics", 8),
    new Product(currentId++, "Blender", 50M, "Appliances", 25),
    new Product(currentId++, "Gaming Console", 400M, "Electronics", 7),
    new Product(currentId++, "Jacket", 60M, "Clothing", 20),
    new Product(currentId++, "Watch", 250M, "Accessories", 18),
    new Product(currentId++, "Backpack", 40M, "Accessories", 22),
    new Product(currentId++, "Wireless Mouse", 30M, "Electronics", 35),
    new Product(currentId++, "Camera", 500M, "Electronics", 9),
    new Product(currentId++, "Office Chair", 120M, "Furniture", 12),
    new Product(currentId++, "Desk", 300M, "Furniture", 5),
    new Product(currentId++, "Gaming Mouse", 25M, "Electronics", 40),
    new Product(currentId++, "Mechanical Keyboard", 100M, "Electronics", 15),
    new Product(currentId++, "Tablet", 350M, "Electronics", 11),
    new Product(currentId++, "Monitor", 200M, "Electronics", 20),
    new Product(currentId++, "External Hard Drive", 100M, "Electronics", 17)
};

        //Console.BackgroundColor = ConsoleColor.White;
        //Console.ForegroundColor = ConsoleColor.Black;
        //Console.Clear();

        bool running = true;

        while (running)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();

            Console.WriteLine("\n===============================");
            Console.WriteLine("    Welcome to Shopping Cart   ");
            Console.WriteLine("===============================\n");

            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Calculate Total Price");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Show Product Recommendations");
            Console.WriteLine("7. Check Cart Expiration");
            Console.WriteLine("8. Exit");

            Console.WriteLine("\n===============================");
            Console.Write("Choose an option: ");


            Console.ResetColor();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Select a category:");
                    Console.WriteLine("1. Electronics");
                    Console.WriteLine("2. Clothing");
                    Console.WriteLine("3. Appliances");
                    Console.WriteLine("4. Furniture");
                    Console.WriteLine("5. Accessories");
                    Console.Write("Choose a category (1-5): ");

                    int categoryChoice;
                    if (int.TryParse(Console.ReadLine(), out categoryChoice) && categoryChoice >= 1 && categoryChoice <= 5)
                    {
                        var selectedProducts = allProducts.Where(p => p.Category switch
                        {
                            "Electronics" => categoryChoice == 1,
                            "Clothing" => categoryChoice == 2,
                            "Appliances" => categoryChoice == 3,
                            "Furniture" => categoryChoice == 4,
                            "Accessories" => categoryChoice == 5,
                            _ => false
                        }).ToList();

                        Console.Clear();
                        Console.WriteLine("\nAvailable Products:");

                        foreach (var product in selectedProducts)
                        {
                            Console.WriteLine($"\nID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}");


                            if (product.Stock < 5)
                            {
                                Console.WriteLine("Warning: Low stock!");
                            }
                        }


                        Console.Write("\nEnter the product ID to add to the cart: ");
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            var productToAdd = selectedProducts.FirstOrDefault(p => p.Id == productId);
                            if (productToAdd != null)
                            {
                                Console.Write("\nEnter the quantity: ");
                                if (int.TryParse(Console.ReadLine(), out int quantity))
                                {
                                    cart.AddProduct(productToAdd, quantity);
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid quantity.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid product ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid product ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid category choice.");
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("=== Remove Product ===");
                    Console.Write("Enter the product ID to remove from the cart: ");
                    if (int.TryParse(Console.ReadLine(), out int removeProductId))
                    {
                        cart.RemoveProduct(removeProductId);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid product ID.");
                    }
                    break;

                case "3":
                    Console.Clear();
                    cart.ViewCart();
                    break;

                case "4":
                    Console.Clear();
                    cart.GetTotalPrice();
                    break;

                case "5":
                    Console.Clear();
                    cart.Checkout();
                    running = false;
                    break;

                case "6":
                    Console.Clear();
                    cart.ShowRecommendations(allProducts);
                    break;

                case "7":
                    Console.Clear();
                    cart.ExpireCart();
                    break;

                case "8":
                    //Console.WriteLine("\nWe appreciate your visit! Thank you for being a valued customer. Goodbye!");
                    //Console.WriteLine("\nThank you for visiting our store! We hope to see you again soon. Goodbye!");
                    //Console.WriteLine("\nThank you for shopping with us! We hope you had a great experience. Take care and goodbye!");
                    Console.WriteLine("\nYour shopping experience matters to us! Thank you for choosing us. Have a wonderful day!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
























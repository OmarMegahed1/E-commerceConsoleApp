# E-commerce Console Application

A comprehensive console-based e-commerce system built with C# and .NET 8.0 that demonstrates object-oriented programming principles.

## ✨ Features

- **Multiple Product Types**: Support for both expirable and non-expirable products
- **Shopping Cart Management**: Add products, validate quantities, and manage cart state
- **Checkout Process**: Complete order processing with validation and receipt generation
- **Shipping System**: Automatic shipping calculations based on product weight
- **Customer Management**: Track customer balance and transaction history
- **Error Handling**: Comprehensive validation for expired products, insufficient stock, and balance checks

## 🛍️ Product Types

### Expirable Products
Products with expiration dates that require special handling:

- **Cheese**: Dairy product with weight-based shipping
- **Biscuits**: Snack food with expiration tracking

### Non-Expirable Products
Durable goods that don't expire:

- **Mobile**: Electronic device with shipping requirements
- **TV**: Large electronic item with heavy shipping
- **Scratch Card**: Digital product with no shipping needed

### Product Properties

| Product Type | Expirable | Requires Shipping | Weight-Based |
|-------------|-----------|-------------------|--------------|
| Cheese      | ✅        | ✅                | ✅           |
| Biscuits    | ✅        | ✅                | ✅           |
| Mobile      | ❌        | ✅                | ✅           |
| TV          | ❌        | ✅                | ✅           |
| Scratch Card| ❌        | ❌                | ❌           |

## 🚀 Getting Started

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd E-commerceConsoleApp
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run
```

## 💡 Usage Examples

The application demonstrates various scenarios through predefined examples:

### Adding Products to Cart

```csharp
var cart = new Cart();
var cheese = new Cheese(100m, 10, DateTime.Now.AddDays(10), 200);
cart.Add(cheese, 2); // Add 2 units of cheese
```

### Customer Checkout

```csharp
var customer = new Customer("John Doe", 1000m);
CheckoutService.Checkout(customer, cart);
```

## 📊 Key Metrics

- **Shipping Rate**: 30 EGP per kilogram
- **Weight Conversion**: Grams to kilograms (÷1000)
- **Decimal Precision**: 2 decimal places for currency
- **Date Handling**: DateTime for expiration tracking

## 🧪 Testing Scenarios (The Output)

The application includes comprehensive test scenarios:

1. **Successful Checkout**: Complete order with mixed products
2. **Expired Product**: Handling of expired items
3. **Insufficient Balance**: Payment failure scenarios
4. **Out of Stock**: Inventory limitation handling
5. **Empty Cart**: Edge case validation
6. **Complex Orders**: Multiple product types and calculations

```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Example 1: Successful Checkout ===");
        var cheese = new Cheese(100m, 10, DateTime.Now.AddDays(10), 200);
        var tv = new TV(500m, 5, 5000);
        var scratchCard = new ScratchCard(50m, 20);
        var customer1 = new Customer("Omar Megahed", 2000m);
        var cart1 = new Cart();

        cart1.Add(cheese, 2);
        cart1.Add(tv, 1);
        cart1.Add(scratchCard, 3);

        CheckoutService.Checkout(customer1, cart1);

        Console.WriteLine("\n=== Example 2: Expired Product ===");
        var expiredCheese = new Cheese(100m, 10, DateTime.Now.AddDays(-1), 200);
        var cart2 = new Cart();
        cart2.Add(expiredCheese, 1);

        var customer2 = new Customer("Ahmed Helmy", 500m);
        CheckoutService.Checkout(customer2, cart2);

        Console.WriteLine("\n=== Example 3: Insufficient Balance ===");
        var mobile = new Mobile(800m, 3, 150);
        var cart3 = new Cart();
        cart3.Add(mobile, 2);

        var customer3 = new Customer("Tom Cruise", 1000m);
        CheckoutService.Checkout(customer3, cart3);

        Console.WriteLine("\n=== Example 4: Out of Stock ===");
        var biscuits = new Biscuits(150m, 2, DateTime.Now.AddDays(30), 350);
        var cart4 = new Cart();
        cart4.Add(biscuits, 3);

        Console.WriteLine("\n=== Example 5: Empty Cart ===");
        var cart5 = new Cart();
        var customer5 = new Customer("Radwaa Elsherbeny", 1000m);
        CheckoutService.Checkout(customer5, cart5);

        Console.WriteLine("\n=== Example 6: Complex Order ===");
        var cheese2 = new Cheese(100m, 10, DateTime.Now.AddDays(10), 200);
        var biscuits2 = new Biscuits(150m, 5, DateTime.Now.AddDays(30), 350);
        var cart6 = new Cart();

        cart6.Add(cheese2, 2);
        cart6.Add(biscuits2, 1);

        var customer6 = new Customer("Adel Emam", 1000m);
        CheckoutService.Checkout(customer6, cart6);
    }
}
```

```Output
=== Example 1: Successful Checkout ===
 Shipment notice 
2x Cheese          400g
1x TV              5000g
Total package weight 5.4kg
 Checkout receipt 
2x Cheese          200
1x TV              500
3x Mobile Scratch Card 150
----------------------
Subtotal          850
Shipping          162.0
Amount            1012.0
Customer Balance  988.0
=== Example 2: Expired Product ===
Error: Cheese is expired
=== Example 3: Insufficient Balance ===
Error: Insufficient balance
=== Example 4: Out of Stock ===
Error: Only 2 Biscuits(s) available
=== Example 5: Empty Cart ===
Error: Cart is empty
=== Example 6: Complex Order ===
 Shipment notice 
2x Cheese          400g
1x Biscuits        350g
Total package weight 0.8kg
 Checkout receipt 
2x Cheese          200
1x Biscuits        150
----------------------
Subtotal          350
Shipping          22.50
Amount            372.50
Customer Balance  627.50
```

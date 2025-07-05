public static class CheckoutService
{
    private const decimal SHIPPING_RATE_PER_KG = 30m;

    public static void Checkout(Customer customer, Cart cart)
    {
        // Check if cart is empty
        if (cart.IsEmpty())
        {
            Console.WriteLine("Error: Cart is empty");
            return;
        }

        // Check for expired or out of stock products
        foreach (var item in cart.Items)
        {
            if (item.Product.IsExpired())
            {
                Console.WriteLine($"Error: {item.Product.Name} is expired");
                return;
            }

            if (item.Quantity > item.Product.Quantity)
            {
                Console.WriteLine($"Error: {item.Product.Name} is out of stock");
                return;
            }
        }

        // Calculate totals
        decimal subtotal = 0;
        var shippableItems = new List<IShippable>();

        foreach (var item in cart.Items)
        {
            subtotal += item.Product.Price * item.Quantity;

            if (item.Product.RequiresShipping() && item.Product is IShippable shippable)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    shippableItems.Add(shippable);
                }
            }
        }

        // Calculate shipping fee
        double totalWeight = shippableItems.Sum(i => i.GetWeight()) / 1000.0; // Convert to kg
        decimal shippingFee = (decimal)totalWeight * SHIPPING_RATE_PER_KG;
        decimal totalAmount = subtotal + shippingFee;

        // Check customer balance
        if (customer.Balance < totalAmount)
        {
            Console.WriteLine("Error: Insufficient balance");
            return;
        }

        // Process shipment if there are shippable items
        if (shippableItems.Any())
        {
            ShippingService.Ship(shippableItems);
            Console.WriteLine();
        }

        // Print receipt
        Console.WriteLine("** Checkout receipt **");
        foreach (var item in cart.Items)
        {
            Console.WriteLine($"{item.Quantity}x {item.Product.Name,-15} {item.Product.Price * item.Quantity}");
        }
        Console.WriteLine("----------------------");
        Console.WriteLine($"{"Subtotal",-17} {subtotal}");
        Console.WriteLine($"{"Shipping",-17} {shippingFee}");
        Console.WriteLine($"{"Amount",-17} {totalAmount}");

        // Update customer balance and product quantities
        customer.Balance -= totalAmount;
        foreach (var item in cart.Items)
        {
            item.Product.Quantity -= item.Quantity;
        }

        Console.WriteLine($"{"Customer Balance",-17} {customer.Balance}");

        // Clear cart after successful checkout
        cart.Clear();
    }
}

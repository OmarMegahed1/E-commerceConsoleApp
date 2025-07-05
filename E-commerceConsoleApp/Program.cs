namespace E_commerceConsoleApp
{
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
}


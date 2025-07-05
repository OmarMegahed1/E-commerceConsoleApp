public class Cart
{
    private List<CartItem> items = new List<CartItem>();

    public List<CartItem> Items => items.ToList();

    public void Add(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine($"Error: Invalid quantity for {product.Name}");
            return;
        }

        if (quantity > product.Quantity)
        {
            Console.WriteLine($"Error: Only {product.Quantity} {product.Name}(s) available");
            return;
        }

        var existingItem = items.FirstOrDefault(i => i.Product == product);
        if (existingItem != null)
        {
            if (existingItem.Quantity + quantity > product.Quantity)
            {
                Console.WriteLine($"Error: Only {product.Quantity} {product.Name}(s) available");
                return;
            }
            existingItem.Quantity += quantity;
        }
        else
        {
            items.Add(new CartItem(product, quantity));
        }
    }

    public void Clear()
    {
        items.Clear();
    }

    public bool IsEmpty()
    {
        return !items.Any();
    }
}

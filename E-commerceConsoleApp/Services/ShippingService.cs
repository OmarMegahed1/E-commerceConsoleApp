public static class ShippingService
{
    public static void Ship(List<IShippable> items)
    {
        Console.WriteLine("** Shipment notice **");

        double totalWeight = 0;
        var groupedItems = items.GroupBy(i => i.GetName());

        foreach (var group in groupedItems)
        {
            int count = group.Count();
            double weight = group.Sum(i => i.GetWeight());
            Console.WriteLine($"{count}x {group.Key,-15} {weight}g");
            totalWeight += weight;
        }

        Console.WriteLine($"Total package weight {totalWeight / 1000:F1}kg");
    }
}

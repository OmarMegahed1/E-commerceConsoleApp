public class TV : NonExpirableProduct, IShippable
{
    public double Weight { get; set; }

    public TV(decimal price, int quantity, double weight)
        : base("TV", price, quantity)
    {
        Weight = weight;
    }

    public override bool RequiresShipping() => true;

    public string GetName() => Name;
    public double GetWeight() => Weight;
}

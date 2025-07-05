public class Mobile : NonExpirableProduct, IShippable
{
    public double Weight { get; set; }

    public Mobile(decimal price, int quantity, double weight)
        : base("Mobile", price, quantity)
    {
        Weight = weight;
    }

    public override bool RequiresShipping() => true;

    public string GetName() => Name;
    public double GetWeight() => Weight;
}

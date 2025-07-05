public class Cheese : ExpirableProduct, IShippable
{
    public double Weight { get; set; }

    public Cheese(decimal price, int quantity, DateTime expiryDate, double weight)
        : base("Cheese", price, quantity, expiryDate)
    {
        Weight = weight;
    }

    public override bool RequiresShipping() => true;

    public string GetName() => Name;
    public double GetWeight() => Weight;
}

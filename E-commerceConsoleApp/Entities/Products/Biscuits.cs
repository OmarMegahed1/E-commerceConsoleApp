public class Biscuits : ExpirableProduct, IShippable
{
    public double Weight { get; set; }

    public Biscuits(decimal price, int quantity, DateTime expiryDate, double weight)
        : base("Biscuits", price, quantity, expiryDate)
    {
        Weight = weight;
    }

    public override bool RequiresShipping() => true;

    public string GetName() => Name;
    public double GetWeight() => Weight;
}

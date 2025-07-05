public abstract class NonExpirableProduct : Product
{
    protected NonExpirableProduct(string name, decimal price, int quantity)
        : base(name, price, quantity)
    {
    }

    public override bool IsExpired()
    {
        return false;
    }
}

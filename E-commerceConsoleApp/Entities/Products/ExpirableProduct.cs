public abstract class ExpirableProduct : Product
{
    public DateTime ExpiryDate { get; set; }

    protected ExpirableProduct(string name, decimal price, int quantity, DateTime expiryDate)
        : base(name, price, quantity)
    {
        ExpiryDate = expiryDate;
    }

    public override bool IsExpired()
    {
        return DateTime.Now > ExpiryDate;
    }
}

public class ScratchCard : NonExpirableProduct
{
    public ScratchCard(decimal price, int quantity)
        : base("Mobile Scratch Card", price, quantity)
    {
    }

    public override bool RequiresShipping() => false;
}

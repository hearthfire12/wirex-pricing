namespace Wirex.Pricing.Tests.Contract
{
    public interface ICloneable<out T>
    {
        T Clone();
    }
}
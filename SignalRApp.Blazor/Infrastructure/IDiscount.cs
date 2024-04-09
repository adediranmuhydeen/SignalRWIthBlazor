namespace SignalRApp.Blazor.Infrastructure;

public interface IDiscount
{
    List<string> GenerateDiscountCodesAsync(ushort code, byte length);
}

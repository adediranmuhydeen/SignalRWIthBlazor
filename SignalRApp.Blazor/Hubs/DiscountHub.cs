using Microsoft.AspNetCore.SignalR;
using SignalRApp.Blazor.Infrastructure;

namespace SignalRApp.Blazor.Hubs;

public class DiscountHub : Hub
{
    private readonly IDiscount _discount;
    public DiscountHub(IDiscount discount)
    {
        _discount = discount;
    }
    public Task GetDiscountCode(ushort numberOfCode, byte length)
    {
        var codes = _discount.GenerateDiscountCodesAsync(numberOfCode, length);
        return Clients.All.SendAsync("ReceiveMessage", codes);
    }
}

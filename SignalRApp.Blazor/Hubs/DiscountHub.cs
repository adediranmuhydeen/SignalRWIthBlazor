using Microsoft.AspNetCore.SignalR;
using SignalRApp.Blazor.Infrastructure;

namespace SignalRApp.Blazor.Hubs;

public class DiscountHub : Hub
{
    #region Fields
    private readonly IDiscountService _service;
    #endregion

    #region Constructor
    public DiscountHub(IDiscountService service)
    {
        _service = service;
    }
    #endregion

    #region Public Methods
    public Task GetDiscountCode(ushort numberOfCode, byte length)
    {
        var codes = _service.GenerateDiscountCodesAsync(numberOfCode, length);
        return Clients.All.SendAsync("ReceiveMessage", codes);
    }
    
    public Task ConFirmDicountCode(string code)
    {
        var result = _service.ConfirmDiscount(code);
        return Clients.All.SendAsync("ReceiveMessage", result);
    }
    #endregion
}

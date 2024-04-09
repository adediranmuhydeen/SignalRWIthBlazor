using Microsoft.AspNetCore.SignalR;

namespace SignalRApp.Blazor.Hubs;
public class AppHub : Hub
{
    public Task SendMessage(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.UtcNow.ToString("f"));
    }
}


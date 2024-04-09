using Microsoft.AspNetCore.SignalR;

namespace TEAM11.UNO.API.Hubs
{
    public class UnoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

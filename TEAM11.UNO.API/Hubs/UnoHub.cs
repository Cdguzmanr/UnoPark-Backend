using Microsoft.AspNetCore.SignalR;

namespace TEAM11.UNO.API.Hubs
{
    public class UnoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }

        public async Task BroadcastMessage(string message)
        {
            await Clients.All.SendAsync("OnMessageReceived", message);
        }

        public async Task StartGame()
        {
            await Clients.All.SendAsync("Game Started!");
            Console.WriteLine("------ Connection ----- ");
        }

        public async Task UserLogin(string user)
        {
            await Clients.All.SendAsync("User: " + user + " has logged in.");
        }

    }
}

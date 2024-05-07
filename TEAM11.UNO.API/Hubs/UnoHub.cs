﻿using Microsoft.AspNetCore.SignalR;
using NuGet.Common;
using TEAM11.UNO.BL;

namespace TEAM11.UNO.API.Hubs
{
    public class UnoHub : Hub
    {
        private readonly ILogger<UnoHub> logger;
        public UnoHub(ILogger<UnoHub> logger) { this.logger = logger; }

        public async Task SendMessage(string user, string message)
        {
            new LogManager(logger).Log(new LogMessage(NuGet.Common.LogLevel.Information,
                                                             "User: " + user + " Message: " + message));
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // -------- Extra Methods ------

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

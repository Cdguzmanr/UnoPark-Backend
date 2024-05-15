using Microsoft.AspNetCore.SignalR.Client;

namespace TEAM11.UNO.ConsoleApp
{
    internal class SignalRConnection
    {
        private string hubAddress;
        HubConnection _connection;
        string user;

        public SignalRConnection(string hubAddress)
        {
            this.hubAddress = hubAddress;
        }

        public async Task Start()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubAddress)
                .Build();

            _connection.On<string, string>("ReceiveMessage", (s1, s2) => OnSend(s1, s2));

            await _connection.StartAsync(); // Await StartAsync method
        }

        private void OnSend(string user, string message)
        {
            Console.WriteLine(user + ": " + message);
        }

        public async Task SendMessageToChannel(string user, string message)
        {
            try
            {
                Console.WriteLine("Sending message " + message + " from " + user);
                await _connection.InvokeAsync("SendMessage", user, message); // Await InvokeAsync method
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void ConnectToChannel(string user)
        {
            Start();
            string message = user + " Connected";

            try
            {
                _connection.InvokeAsync("SendMessage", "System", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

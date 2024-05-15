using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEAM11.UNO.ConsoleApp;
using Newtonsoft.Json;

namespace TEAM11.UNO.ConsoleApp
{
    class Program
    {
        private static string DrawMenu()
        {

            Console.WriteLine("Which operation do you wish to perform?");
            Console.WriteLine("Connect to a channel (c)");

            Console.WriteLine("Exit (x)");

            string operation = Console.ReadLine();
            return operation;
        }

        static async Task Main(string[] args)
        {
            string user = "Test Test Test";

            string remoteAddress = "https://bigprojectapi-300079087.azurewebsites.net/UnoHub";
            string localAddress = "https://localhost:7045/UnoHub";

            string operation = DrawMenu();

            var signalRConnection = new SignalRConnection(localAddress);

            while (operation != "x")
            {
                switch (operation)
                {
                    case "c":
                        signalRConnection.ConnectToChannel(user);
                        break;
                }

                operation = DrawMenu();
            }
        }
    }
}
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
            string user = "Test";
            // Add new url
            //string hubAddress = "https://fvtcdp.azurewebsites.net/BingoHub";
            //string hubAddress = "https://dvdcentralapi-120212964.azurewebsites.net/BingoHub";
            string hubAddress = "https://localhost:7045/UnoHub";

            string operation = DrawMenu();

            var signalRConnection = new SignalRConnection(hubAddress);

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
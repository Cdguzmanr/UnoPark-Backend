
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEAM11.UNO.ConsoleApp;
using Newtonsoft.Json;

namespace UnoCardRetriever
{
    class ConsoleApp
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Creating local variables needed to figure out if Signal R is working or not.
                string user = "Uno";
                string localAddress = "https://localhost:7045/UnoHub";

                // Calling Signal R address.
                var signalRConnection = new SignalRConnection(localAddress);

                Console.WriteLine("Before Signal R is Called");
                signalRConnection.ConnectToChannel(user);
                Console.WriteLine("After Signal R is Called");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


            //try
            //{
            //    // Base URL of the API
            //    string baseUrl = "https://bigprojectapi-300079087.azurewebsites.net";

            //    // API endpoint for retrieving cards
            //    string endpoint = "/api/Card";

            //    // Create HttpClient instance
            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = new Uri(baseUrl);
            //        client.DefaultRequestHeaders.Accept.Clear();
            //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //        // Call the API to retrieve the list of cards
            //        HttpResponseMessage response = await client.GetAsync(endpoint);

            //        if (response.IsSuccessStatusCode)
            //        {
            //            // Parse the response content
            //            var cardJson = await response.Content.ReadAsStringAsync();
            //            var cards = JsonConvert.DeserializeObject<List<Card>>(cardJson);

            //            // Display the retrieved cards
            //            Console.WriteLine("Retrieved Cards:");
            //            foreach (var card in cards)
            //            {
            //                Console.WriteLine($"ID: {card.Id}, Name: {card.Name}, Color: {card.Color}, Type: {card.Type}");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Failed to retrieve cards. Status code: {response.StatusCode}");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            //Console.ReadLine();
        }
    }

    // Define Card class to match the structure of the JSON response
    //public class Card
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public string Color { get; set; }
    //    public string Type { get; set; }
    //}
}

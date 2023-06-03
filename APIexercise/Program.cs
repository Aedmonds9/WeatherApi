using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIexercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter API key:");
            var api_key = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter City Name:");
                string city_name = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_key}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Choose another city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if(userInput.ToLower() == "no")
                {
                    break;
                }
            }
        }
    }
}

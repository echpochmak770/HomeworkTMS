using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HomeworkTMS
{
    internal class Program
    {
        static readonly string _catApiEndpoint = "https://api.thecatapi.com/v1/images/search";

        static async Task Main(string[] args)
        {
            using HttpClient _client = new();

            string response = await _client.GetStringAsync(_catApiEndpoint);
            var catData = JsonSerializer.Deserialize<List<ApiResponse>>(response);

            if (catData.Count > 0)
            {
                Console.WriteLine($"Успех! Котики получены" +
                    $"\n{catData[0].Url}");
            }
            else
            {
                Console.WriteLine("Сегодня без котиков. Что-то поломалось((");
            }
                
        }
    }
}

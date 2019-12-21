using System;
using System.Threading;
using System.Net.Http;
using System.Collections.Generic;
using UzExTaskBeater.Models;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace UzExTaskBeater
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        public static string myName = "";
        static void Main(string[] args)
        {
            Console.Write("Insert your name: ");
            myName = Console.ReadLine();

            while(true){              
                LastBeat().Wait();
                Thread.Sleep(1000);
            }
        }

        private static async Task LastBeat()
        {   

            var responseString = await client.GetStringAsync("https://localhost:5001/api/v1/beats/LastBeat");
            Beat lastBeat = JsonConvert.DeserializeObject<Beat>(responseString.ToString());

            BeatVM vm = new BeatVM();
            Random random = new Random(); 
            var lastPrice = lastBeat!=null ? lastBeat.Price: 0;
            vm.BeaterId = myName;
            decimal rDec = (decimal)System.Math.Round(random.NextDouble(),2);
            vm.Price = lastPrice+rDec;

            var json = JsonConvert.SerializeObject(vm, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("https://localhost:5001/api/v1/beats", content);
            var createResponse = await response.Content.ReadAsStringAsync();
            
            //Console.WriteLine(createResponse);
            Console.WriteLine("'{0}': last beat was '{1}', my beat is '{2}' -> '{3}'",myName, lastPrice, vm.Price, createResponse==""?"Error":"OK");            
        }


    }
}

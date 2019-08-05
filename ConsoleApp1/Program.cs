using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            /* var client = new RestClient
            {
                BaseUrl = new Uri("http://fipeapi.appspot.com/")
            };

            var req = new RestRequest("api/1/{0}/marcas.json", Method.GET);

            req.AddParameter("tipo", "carros", ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<List<Marca>>(response.Content);
            //var contentResponse = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);

            Console.WriteLine();
            Console.ReadKey();*/


            


        }

  
    }
    public class Fipe
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Fipe_Name { get; set; }
    }
    
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Serialization.Xml;
using Start.Library;
using Start.Models;
using System.Xml.Serialization;

namespace Start.Controllers
{
    [Serializable()]
    public class ViagemController : ApiController
    {
        private ContextDB db = new ContextDB();
        
        public float Valor(int dias, string plano)
        {
            if (plano == "Economy")
                return dias * economy;
            else if (plano == "Premium")
                return dias * premium;
            else
                return 0;       
        }

        private static Cobertura Economy = new Cobertura
        {
            nome = "Economy",
            id = 9
        };
        private static Cobertura Premium = new Cobertura
        {
            nome = "Premium",
            id = 10
        };

        [HttpGet]
        public string GetDolar(string dias, string plano)
        {
            var restClient = new RestClient(string.Format("https://api.hgbrasil.com/finance?fields=only_results&source=BRL&buy=1&sell=1&key=0c75e674"));
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);
            var DolToday = restResponse.Content.ToString();

            string phrase = DolToday;
            string[] words = phrase.Split('\"');

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
                string variacao = words[18]; // Não estou usando pra nada, mas acho que pode ser útil no futuro.
                string a = words[14];
                string b = a.Replace(":", "");
                string c = b.Replace(",", "").ToString();

                var result = Valor(int.Parse(dias), plano);
                var result2 = result * float.Parse(c);
                return result2.ToString();
            }
            return null;
        }

        #region Planos
        private const float economy = 5.35f;
        private const float gold = 0f;
        private const float premium = 16.33f;
        #endregion

    }
} 
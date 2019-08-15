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
            if (plano == "economy")
            {
                return dias * 5.35f;
            }
            else if (plano == "premium")
            {
                return dias * 16.33f;
            }
            else
            {
                return 0;
            }         
        }

        //

        [HttpGet]
        public string GetDolar()
        {
            var restClient = new RestClient(string.Format("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao='{0}'", DateTime.Now.ToString("MM'-'dd'-'yyyy")));
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            var oi = restResponse.Content;

            return oi;

        }
    }
}
 
 
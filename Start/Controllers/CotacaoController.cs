using RestSharp;
using RestSharp.Serialization.Json;
using System.Web.Http;
using System.Text.RegularExpressions;

namespace Start.Controllers
{
    public class CotacaoController : ApiController
    {
        private const float plano1 = 589.70f;
        private const float plano2 = 657.74f;
        private const float plano3 = 940.79f;
        private const float plano4 = 1059.36f;
        private const float plano5 = 1160.16f;
        private const float plano6 = 1298.42f;
        private const float plano7 = 1440.73f;
        private const float plano8 = 1612.37f;
        private const float plano9 = 1805.72f;

        [HttpGet]
        public int GetSoma(int c, int d) => c + d;

        [HttpGet]
        public string GetFipe(string tipo, string acao, string modelo)
        {
            /* http://fipeapi.appspot.com/api/1/carros/veiculo/21/4828/2013-1.json */

            var restClient = new RestClient(string.Format("http://fipeapi.appspot.com/api/1/carros/veiculo/{0}/{1}/{2}.json", tipo, acao, modelo));
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);
            Retorno dadosRetorno = new JsonDeserializer().Deserialize<Retorno>(restResponse);

            //string fipeRetorno = string.Format("ID: {0}, Key: {1}, Fipe_Name: {2}, Name: {3}, Order: {4}, Preço: {5}", dadosRetorno.Id, dadosRetorno.Key, dadosRetorno.Fipe_Name, dadosRetorno.Name, dadosRetorno.Order, dadosRetorno.Preco);

            string fipeValor = dadosRetorno.Preco.Remove(0, 3);

            return "Valor do plano - R$: " + GetMensalidade(ConverteNum(fipeValor));
        }

        public string ConverteNum(string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(str, "");
        }

        [HttpGet]
        public string GetMensalidade(string fipeValor)
        {
            float resultValor = 0;
            float valor = float.Parse(fipeValor)/100;
            if (valor <= 10000)
                resultValor = plano1;
            else if (valor >= 10001 && valor <= 20000)
                resultValor = plano2;
            else if (valor >= 20001 && valor <= 30000)
                resultValor = plano3;
            else if (valor >= 30001 && valor <= 40000)
                resultValor = plano4;
            else if (valor >= 40001 && valor <= 50000)
                resultValor = plano5;
            else if (valor >= 50001 && valor <= 60000)
                resultValor = plano6;
            else if (valor >= 60001 && valor <= 70000)
                resultValor = plano7;
            else if (valor >= 70001 && valor <= 80000)
                resultValor = plano8;
            else if (valor >= 80001 && valor <= 90000)
                resultValor = plano9;
            else if (valor >= 90001)
                resultValor = 0;

            return resultValor.ToString();
        }
    }

    public class Retorno
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Fipe_Name { get; set; }
        public int Order { get; set; }
        public string Preco { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
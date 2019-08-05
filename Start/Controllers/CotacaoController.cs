using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Web.Http;


namespace Start.Controllers
{
    public class CotacaoController : ApiController
    {
        // GET: api/Cotacao
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cotacao/5
        public string Get(int id)
        {
            return "value";
        }



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

            /*
            var response = restClient.Execute<List<Retorno>>(restRequest);
            Retorno dadosRetorno = new JsonDeserializer().Deserialize<Retorno>(response);

            foreach (Retorno item in response.Data)
            {
                string fipeRetorno = string.Format("ID: {0}, Key: {1}, Fipe_Name: {2}, Name: {3}, Order: {4}", dadosRetorno.Id, dadosRetorno.Key, dadosRetorno.Fipe_Name, dadosRetorno.Name, dadosRetorno.Order);
                return fipeRetorno;
            }
            */

            string fipeRetorno = string.Format("ID: {0}, Key: {1}, Fipe_Name: {2}, Name: {3}, Order: {4}, Preço: {5}", dadosRetorno.Id, dadosRetorno.Key, dadosRetorno.Fipe_Name, dadosRetorno.Name, dadosRetorno.Order, dadosRetorno.Preco);
            return fipeRetorno;
        }





        // POST: api/Cotacao
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cotacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cotacao/5
        public void Delete(int id)
        {
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

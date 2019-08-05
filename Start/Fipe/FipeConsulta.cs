using RestSharp;
using RestSharp.Serialization.Json;
using System;

namespace Start.Fipe
{
    public class FipeConsulta
    {
        public string Tipo { get; set; }
        public string Acao { get; set; }
        public string Parametro1 { get; set; }
        public string Parametro2 { get; set; }

        public string Consulta(string tipo, string acao)
        {
            try
            {
                RestClient restClient = new RestClient(string.Format("http://fipeapi.appspot.com/api/1/{0}/{1}.json", tipo, acao));
                RestRequest restRequest = new RestRequest(Method.GET);

                IRestResponse restResponse = restClient.Execute(restRequest);

                if (restResponse.ContentLength <= 0 || restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Houve um problema com a sua requisição: " + restResponse.Content);
                }
                else
                {
                    Retorno dadosRetorno = new JsonDeserializer().Deserialize<Retorno>(restResponse);

                    string fipeRetorno = string.Format("ID: {0}, Key: {1}, Fipe_Name: {2}, Name: {3}, Order: {4}", dadosRetorno.Id, dadosRetorno.Key, dadosRetorno.Fipe_Name, dadosRetorno.Name, dadosRetorno.Order);
                    return fipeRetorno;
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("Houve um problema com a sua requisição: " + error);
            }
            return "Não rolou";
        }

        public static string Cotacao(string mskTxtTipo, string mskTxtTipo2, string mskTxtTipo3, string mskTxtTipo4)
        {
            RestClient restClient = new RestClient(string.Format("http://fipeapi.appspot.com/api/1/{0}/{1}.json", mskTxtTipo, mskTxtTipo2));
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);
            return "A";
        }


    }
    public class Retorno
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Fipe_Name { get; set; }
        public int Order { get; set; }
    }
}
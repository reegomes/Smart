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
        public List<Produto> Valor(int dias)
        {


            Produto oferta1 = new Produto()
            {
                id = 1,
                Nome = "Economy",
                ValorParcela = dias * economy,
                Valor = dias * economy,
                cobertura = getLstCoberturarEconomica()
            };
            Produto oferta2 = new Produto()
            {
                id = 2,
                Nome = "Premium",
                ValorParcela = dias * premium,
                Valor = dias * premium,
                cobertura = getLstCoberturarPremium()
            };

            List<Produto> produtos = new List<Produto>();
            produtos.Add(oferta1);
            produtos.Add(oferta2);

            return produtos;
        }

        private List<Cobertura> getLstCoberturarPremium()
        {
            Cobertura DespMedica = new Cobertura()
            {
                id = 1,
                nome = "Despesas Médico Hospitalares e Odontológicas - U$200.000,00"
            };
            Cobertura Regresso = new Cobertura()
            {
                id = 2,
                nome = "Regresso Sanitário - U$200.000,00"
            };
            Cobertura Translado = new Cobertura()
            {
                id = 3,
                nome = "Traslado de Corpo - U$100.000,00"
            };
            Cobertura TransladoMedico = new Cobertura()
            {
                id = 16,
                nome = "Traslado de Medico - U$200.000,00"
            };
            Cobertura Morte = new Cobertura()
            {
                id = 4,
                nome = "Morte Acidental - U$15.000,00"
            };
            Cobertura Invalidez = new Cobertura()
            {
                id = 5,
                nome = "Invalidez Permanente total por Acidente - U$15.000,00"
            };
            Cobertura Hospedagem = new Cobertura()
            {
                id = 6,
                nome = "Hospedagem de Acompanhante - U$15.000,00"
            };
            Cobertura Bagagem = new Cobertura()
            {
                id = 7,
                nome = "Perda ou Dano a de Bagagem em Transporte Aéreo - U$1.000,00"
            };
            Cobertura Menssagem = new Cobertura()
            {
                id = 8,
                nome = "Transmissão de mensagens de urgência"
            };
            Cobertura Documentos = new Cobertura()
            {
                id = 9,
                nome = "Auxílio em caso de perda ou roubo de documentos"
            };
            Cobertura Concierge = new Cobertura()
            {
                id = 10,
                nome = "Concierge - informações de viagem"
            };
            Cobertura Localizacao = new Cobertura()
            {
                id = 11,
                nome = "Auxílio na localização de bagagem"
            };
            Cobertura Familizar = new Cobertura()
            {
                id = 12,
                nome = "Reserva de passagem aérea de ida e volta para um familiar"
            };
            Cobertura Internacao = new Cobertura()
            {
                id = 13,
                nome = "Reserva de hotel para acompanhante em caso de internação"
            };
            Cobertura Inturripcao = new Cobertura()
            {
                id = 14,
                nome = "Interrupção de Viagem - U$5.000,00"
            };
            Cobertura Cancelamento = new Cobertura()
            {
                id = 15,
                nome = "Interrupção de Viagem -  U$5.000,00"
            };

            List<Cobertura> coberturas = new List<Cobertura>();
            coberturas.Add(DespMedica);
            coberturas.Add(Regresso);
            coberturas.Add(Translado);
            coberturas.Add(Morte);
            coberturas.Add(Invalidez);
            coberturas.Add(Hospedagem);
            coberturas.Add(Bagagem);
            coberturas.Add(Menssagem);
            coberturas.Add(Documentos);
            coberturas.Add(Concierge);
            coberturas.Add(Localizacao);
            coberturas.Add(Familizar);
            coberturas.Add(Internacao);
            coberturas.Add(TransladoMedico);
            coberturas.Add(Inturripcao);
            coberturas.Add(Cancelamento);

            return coberturas.OrderBy(x => x.id).ToList();
        }

        private List<Cobertura> getLstCoberturarEconomica()
        {
            Cobertura DespMedica = new Cobertura()
            {
                id = 1,
                nome = "Despesas Médico Hospitalares e Odontológicas - U$15.000,00"
            };
            Cobertura Regresso = new Cobertura()
            {
                id = 2,
                nome = "Regresso Sanitário - U$15.000,00"
            };
            Cobertura Translado = new Cobertura()
            {
                id = 3,
                nome = "Traslado de Corpo - U$15.000,00"
            };
            Cobertura Morte = new Cobertura()
            {
                id = 4,
                nome = "Morte Acidental - U$15.000,00"
            };
            Cobertura Invalidez = new Cobertura()
            {
                id = 5,
                nome = "Invalidez Permanente total por Acidente - U$15.000,00"
            };
            Cobertura Hospedagem = new Cobertura()
            {
                id = 6,
                nome = "Hospedagem de Acompanhante - U$15.000,00"
            };
            Cobertura Bagagem = new Cobertura()
            {
                id = 7,
                nome = "Perda ou Dano a de Bagagem em Transporte Aéreo - U$250,00"
            };
            Cobertura Menssagem = new Cobertura()
            {
                id = 8,
                nome = "Transmissão de mensagens de urgência"
            };
            Cobertura Documentos = new Cobertura()
            {
                id = 9,
                nome = "Auxílio em caso de perda ou roubo de documentos"
            };
            Cobertura Concierge = new Cobertura()
            {
                id = 10,
                nome = "Concierge - informações de viagem"
            };
            Cobertura Localizacao = new Cobertura()
             {
                 id = 11,
                 nome = "Auxílio na localização de bagagem"
             };
            Cobertura Familizar = new Cobertura()
            {
                id = 12,
                nome = "Reserva de passagem aérea de ida e volta para um familiar"
            };
            Cobertura Internacao = new Cobertura()
            {
                id = 13,
                nome = "Reserva de hotel para acompanhante em caso de internação"
            };

            List<Cobertura> coberturas = new List<Cobertura>();
            coberturas.Add(DespMedica);
            coberturas.Add(Regresso);
            coberturas.Add(Translado);
            coberturas.Add(Morte);
            coberturas.Add(Invalidez);
            coberturas.Add(Hospedagem);
            coberturas.Add(Bagagem);
            coberturas.Add(Menssagem);
            coberturas.Add(Documentos);
            coberturas.Add(Concierge);
            coberturas.Add(Localizacao);
            coberturas.Add(Familizar);
            coberturas.Add(Internacao);


            return coberturas;

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
        public List<Produto> Get(string dias)
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
                string c = b.Replace(",", "").Replace(".","").ToString();
                //int d = Convert.ToInt32(c);

                var result = Valor(int.Parse(dias));
                List<Produto> result3 = new List<Produto>();
                
                foreach(Produto aaaa in result)
                {
                    aaaa.Valor = aaaa.Valor * 4;
                    aaaa.ValorParcela = aaaa.Valor;
                    result3.Add(aaaa);
                }

                return result3;
            }
            return null;
        }
        #region Planos
        private const double economy = 3.35;
        private const float gold = 0f;
        private const double premium = 9.40;
        #endregion
        [HttpPost]
        public void Post(string cPF, string nome, string email, string dataNascimento, string sexo, string estadoCivil, int cEP, string logradouro, int numero, string complemento, string bairro, string cidade, string uF, int telefoneResidencial, int telefoneCelular, string motivoViagem, string dataPartida, string dataRetorno)
        {
            if (!string.IsNullOrEmpty(cPF))
            {
                using (var ctx = new ContextDB())
                {
                    Cliente clienteObj = new Cliente(cPF, nome, email, dataNascimento, sexo, estadoCivil);
                    Viagem viagemObj = new Viagem(cEP, logradouro, numero, complemento, bairro, cidade, uF, telefoneResidencial, telefoneCelular, motivoViagem, dataPartida, dataRetorno);
                    try
                    {
                        var BuscaCPF = ctx.Clientes.Where(c => c.CPF == clienteObj.CPF).FirstOrDefault();
                        if (clienteObj.CPF == BuscaCPF.CPF)
                        {
                            viagemObj.ClienteId = BuscaCPF.Id;
                            ctx.Viagems.Add(viagemObj);
                            ctx.SaveChanges();
                        }
                    }
                    catch (NullReferenceException)
                    {
                        ctx.Clientes.Add(clienteObj);
                        ctx.Viagems.Add(viagemObj);
                        ctx.SaveChanges();
                        return;
                    }
                }
            }
        }
    }
}
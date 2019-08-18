using RestSharp;
using RestSharp.Serialization.Json;
using System.Web.Http;
using System.Text.RegularExpressions;
using Start.Models;
using System.Collections.Generic;
using System;
using Start.Library;
using System.Linq;

namespace Start.Controllers
{
    public class CotacaoController : ApiController
    {
        #region Planos 
        private const float plano1 = 589.70f;
        private const float plano2 = 657.74f;
        private const float plano3 = 940.79f;
        private const float plano4 = 1059.36f;
        private const float plano5 = 1160.16f;
        private const float plano6 = 1298.42f;
        private const float plano7 = 1440.73f;
        private const float plano8 = 1612.37f;
        private const float plano9 = 1805.72f;



        private const float planoB1 = 342.03f;
        private const float planoB2 = 381.49f;
        private const float planoB3 = 545.66f;
        private const float planoB4 = 614.43f;
        private const float planoB5 = 672.89f;
        private const float planoB6 = 753.09f;
        private const float planoB7 = 835.62f;
        private const float planoB8 = 935.17f;
        private const float planoB9 = 1047.32f;


        private const float planoC1 = 401.00f;
        private const float planoC2 = 447.27f;
        private const float planoC3 = 639.74f;
        private const float planoC4 = 720.36f;
        private const float planoC5 = 788.91f;
        private const float planoC6 = 882.93f;
        private const float planoC7 = 979.70f;
        private const float planoC8 = 1096.41f;
        private const float planoC9 = 1227.89f;

        #endregion


        #region Cobeturas
        private static Cobertura RouboFurto = new Cobertura
        {
            nome = " Roubo, Furto e Incêndio",
            id = 1
        };
        private static Cobertura Guincho = new Cobertura
        {
            nome = " Serviço de Guincho",
            id = 2
        };
        private static Cobertura Colisao = new Cobertura
        {
            nome = "Colisão - Somente Perda Total(Danos)",
            id = 3
        };
        private static Cobertura Alagamento = new Cobertura
        {
            nome = "Alagamento",
            id = 4
        };
        private static Cobertura Colisao2 = new Cobertura
        {
            nome = "Colisão - Qualquer Evento (Batida)",
            id = 5
        };


        #endregion

        [HttpGet]
        public int GetSoma(int c, int d) => c + d;

        [HttpGet]
        public List<Produto> GetFipe(string marca, string modelo, string ano)
        {
        // Exemplo Base
        /* http://fipeapi.appspot.com/api/1/carros/veiculo/21/4828/2013-1.json */
       


            //var restClient = new RestClient(string.Format("http://fipeapi.appspot.com/api/1/carros/veiculo/{0}/{1}/{2}.json", tipo, acao, modelo));
            var restClient = new RestClient(string.Format(" https://parallelum.com.br/fipe/api/v1/carros/marcas/{0}/modelos/{1}/anos/{2}", marca, modelo, ano));

            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);
            RetornoParalelo dadosRetorno = new JsonDeserializer().Deserialize<RetornoParalelo>(restResponse);

            string fipeValor = dadosRetorno.Valor.Remove(0, 3);

            return GetMensalidade(ConverteNum(fipeValor)).OrderBy(x => x.id).ToList();
        }


        public string ConverteNum(string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(str, "");
        }

        [HttpGet]
        public List<Produto> GetMensalidade(string fipeValor)
        {
            float valor = float.Parse(fipeValor) / 100;
            if (valor <= 10000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano1 / 12;
                produtoA.Valor = plano1;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB1 / 12;
                produtoB.Valor = planoB1;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC1 / 12;
                produtoC.Valor = planoC1;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;



            }
            else if (valor >= 10001 && valor <= 20000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano2 / 12;
                produtoA.Valor = plano2;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB2 / 12;
                produtoB.Valor = planoB2;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC2 / 12;
                produtoC.Valor = planoC2;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;

            }
            else if (valor >= 20001 && valor <= 30000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano3 / 12;
                produtoA.Valor = plano3;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB3 / 12;
                produtoB.Valor = planoB3;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC3 / 12;
                produtoC.Valor = planoC3;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;

            }
            else if (valor >= 30001 && valor <= 40000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano4 / 12;
                produtoA.Valor = plano4;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB4 / 12;
                produtoB.Valor = planoB4;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC4 / 12;
                produtoC.Valor = planoC4;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;

            }
            else if (valor >= 40001 && valor <= 50000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano5 / 12;
                produtoA.Valor = plano5;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB5 / 12;
                produtoB.Valor = planoB5;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC5 / 12;
                produtoC.Valor = planoC5;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;

            }
            else if (valor >= 50001 && valor <= 60000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano6 / 12;
                produtoA.Valor = plano6;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB6 / 12;
                produtoB.Valor = planoB6;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC6 / 12;
                produtoC.Valor = planoC6;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;


            }
            else if (valor >= 60001 && valor <= 70000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano7 / 12;
                produtoA.Valor = plano7;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB7 / 12;
                produtoB.Valor = planoB7;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC7 / 12;
                produtoC.Valor = planoC7;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;

            }
            else if (valor >= 70001 && valor <= 80000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano8 / 12;
                produtoA.Valor = plano8;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB8 / 12;
                produtoB.Valor = planoB8;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC8 / 12;
                produtoC.Valor = planoC8;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;

            }
            else if (valor >= 80001 && valor <= 90000)
            {
                List<Produto> produtos = new List<Produto>();

                Produto produtoA = MontaProduto(3);
                produtoA.ValorParcela = plano9 / 12;
                produtoA.Valor = plano9;
                produtoA.ValorAuto = valor;

                Produto produtoB = MontaProduto(1);
                produtoB.ValorParcela = planoB9 / 12;
                produtoB.Valor = planoB9;
                produtoB.ValorAuto = valor;

                Produto produtoC = MontaProduto(2);
                produtoC.ValorParcela = planoC9 / 12;
                produtoC.Valor = planoC9;
                produtoC.ValorAuto = valor;

                produtos.Add(produtoA);
                produtos.Add(produtoB);
                produtos.Add(produtoC);

                return produtos;

            }
            else if (valor >= 90001)
                return new List<Produto>();
            else
                return new List<Produto>();

        }

        [HttpGet]
        public double ValoresAdcionais(int valorEscolhido, string tipo)
        {
            if (tipo == "rcf")
                return GetRCF(valorEscolhido);
            else if (tipo == "app")
                return GetAPP(valorEscolhido);
            else
                return 0;
            
        }

        [HttpPost]
        public string Salvar(CotacaoCompleta cot)
        {
            try
            {
                ContextDB dB = new ContextDB();
                dB.CotacaoCompleta.Add(cot);
                return ("Concluido");
            }
            catch (Exception e)
            {
                return ("Houve um problema");

            }
        }

        private double GetAPP(int valorEscolhido)
        {
            if (valorEscolhido == 10000)
                return 20.64;
            if (valorEscolhido == 20000)
                return 37.08;
            if (valorEscolhido == 30000)
                return 40.61;
            if (valorEscolhido == 40000)
                return 50.43;
            if (valorEscolhido == 50000)
                return 63.20;
            else
                return 0;

        }

        private double GetRCF(int valorEscolhido)
        {
            if (valorEscolhido == 25000)
                return 147.99;
            if (valorEscolhido == 30000)
                return 169.34;
            if (valorEscolhido == 60000)
                return 233.72;
            if (valorEscolhido == 50000)
                return 208.83;
            if (valorEscolhido == 100000)
                return 299.30;
            if (valorEscolhido == 150000)
                return 446.91;
            if (valorEscolhido == 200000)
                return 601.14;
            if (valorEscolhido == 250000)
                return 792.61;
            if (valorEscolhido == 300000)
                return 948.90;
            else
                return 0;

        }

        private Produto MontaProduto(int id)
        {
            Produto Oferta;
            if (id == 1)
            {
                List<Cobertura> corb = new List<Cobertura>();
                corb.Add(RouboFurto);
                corb.Add(Guincho);
                Oferta = new Produto()
                {
                    ValorParcela = 0,
                    cobertura = corb,
                    id = id,
                    Valor = 0
                };
            }
            else if (id == 2)
            {
                List<Cobertura> corb = new List<Cobertura>();
                corb.Add(RouboFurto);
                corb.Add(Colisao);
                corb.Add(Alagamento);
                corb.Add(Guincho);

                Oferta = new Produto()
                {
                    ValorParcela = 0,
                    cobertura = corb,
                    id = id,
                    Valor = 0
                };
            }
            else
            {
                List<Cobertura> corb = new List<Cobertura>();

                corb.Add(RouboFurto);
                corb.Add(Colisao);
                corb.Add(Colisao2);
                corb.Add(Alagamento);
                corb.Add(Guincho);

                Oferta = new Produto()
                {
                    ValorParcela = 0,
                    cobertura = corb,
                    id = id,
                    Valor = 0
                };
            }

            return Oferta;
        }

    }

    public class Retorno
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Fipe_Name { get; set; }
        public int Order { get; set; }
        public string Valor { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class RetornoParalelo
    {
        public string Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoModelo { get; set; }
        public string Combustivel { get; set; }
        public string CodigoFipe { get; set; }
        public string MesReferencia { get; set; }
        public int TipoVeiculo { get; set; }
        public string SiglaCombustivel { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
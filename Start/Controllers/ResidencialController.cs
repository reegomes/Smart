using Start.Library;
using Start.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace Start.Controllers
{
    public class ResidencialController : ApiController
    {
        private readonly ContextDB db = new ContextDB();

        private readonly bool aptocasa;
        private readonly float iqre = 0;
        private readonly float ferb = 0;
        private readonly float dt = 0;
        private readonly float ppa = 0;

        public void Post(string cpf, string nome, string cEP, string numeroDaCasa, string complemento, string logradouro, string aptocasa, string iqre, string ferb, string dt, string ppa)
        {
            //iqre = Incêndio, queda de raio e explosão
            //ferb = Furto, Extorsão e Roubo de Bens
            //dt = Danos a Terceiros
            //ppa = Perda ou Pagamento de Aluguel
            //Esse post vai receber bool? idk, veremos

            if (!string.IsNullOrEmpty(cpf))
            {
                using (var ctx = new ContextDB())
                {
                    Cliente cliente = new Cliente(cpf, nome);
                    Residencial residencial = new Residencial(cEP, numeroDaCasa, complemento, logradouro, aptoCasa: bool.Parse(aptocasa), iQRE: bool.Parse(iqre), fERB: bool.Parse(ferb), dT: bool.Parse(dt), pPA: bool.Parse(ppa));
                    try
                    {
                        var BuscaCPF = ctx.Clientes.Where(c => c.CPF == cliente.CPF).FirstOrDefault();
                        if (cliente.CPF == BuscaCPF.CPF)
                        {
                            residencial.ClienteId = BuscaCPF.Id;
                            ctx.Residencials.Add(residencial);
                            ctx.SaveChanges();
                        }
                    }
                    catch (NullReferenceException)
                    {
                        ctx.Clientes.Add(cliente);
                        ctx.Residencials.Add(residencial);
                        ctx.SaveChanges();
                        return;
                    }
                }
            }
        }

        #region planos
        private const float oferta1casa = 216.15f;
        private const float oferta2casa = 272.35f;
        private const float oferta3casa = 343.16f;
        private const float oferta4casa = 432.39f;
        private const float oferta5casa = 544.81f;

        private const float oferta1ap = 172.92f;
        private const float oferta2ap = 217.88f;
        private const float oferta3ap = 274.53f;
        private const float oferta4ap = 345.91f;
        private const float oferta5ap = 435.84f;
        #endregion

        #region coberturas

        #endregion
        /*public string Get(string tipo, int plano)
        {
            if (tipo == "casa")
            {
                if (plano == 1) { return Mensalidade(oferta1casa).ToString(); }
                if (plano == 2) { return Mensalidade(oferta2casa).ToString(); }
                if (plano == 3) { return Mensalidade(oferta3casa).ToString(); }
                if (plano == 4) { return Mensalidade(oferta4casa).ToString(); }
                if (plano == 5) { return Mensalidade(oferta5casa).ToString(); }
            }
            else if (tipo == "apartamento")
            {
                if (plano == 1) { return Mensalidade(oferta1ap).ToString(); }
                if (plano == 2) { return Mensalidade(oferta2ap).ToString(); }
                if (plano == 3) { return Mensalidade(oferta3ap).ToString(); }
                if (plano == 4) { return Mensalidade(oferta4ap).ToString(); }
                if (plano == 5) { return Mensalidade(oferta5ap).ToString(); }
            }
            else
            {
                return "Error";
            }
            return null;
        }*/

        /*public float Mensalidade(float oferta)
        {
            return oferta / 12;
        }*/

        private List<Cobertura> getLstCoberturarCasa(string plano)
        {
            if (plano == "A")
            {
                List<Cobertura> corbA = new List<Cobertura>(); 
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 50.000,00  ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 50.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão - R$  50.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 5.000,00", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 3.500,00", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 2.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2.500,00", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.000,00", id = 8 };
                corbA.Add(Incendio);
                corbA.Add(Raio);
                corbA.Add(Explosao);
                corbA.Add(Vendaval);
                corbA.Add(Eletrico);
                corbA.Add(Roubo);
                corbA.Add(RCF);
                corbA.Add(Aluguel);
                return corbA;
            }
            if(plano == "B")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 100.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 100.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$  100.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 5.000,00", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 4.500,00", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 2.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2.500,00", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.000,00 ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            if(plano == "C")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 150.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 150.000,00", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 150.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 6.000,00 ", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 5.000,00 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 3.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 3.000,00", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.000,00 ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            if (plano == "D")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 300.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 300.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 300.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 6.000,00 ", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 6.500,00 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 3.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 3.500,00 ", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.500,00 ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            if (plano == "E")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 500.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 500.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 500.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 10.000,00", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 10.000,00 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 5.000,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 4.000,00 ", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 4.500,00  ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            else return new List<Cobertura>();
        }
        private List<Cobertura> getLstCoberturarAPT(string plano)
        {
            if (plano == "A")
            {
                List<Cobertura> corbA = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 50.000,00  ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 50.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão - R$  50.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 5.000,00", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 3.500,00", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 2.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2.500,00", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.000,00", id = 8 };
                corbA.Add(Incendio);
                corbA.Add(Raio);
                corbA.Add(Explosao);
                corbA.Add(Vendaval);
                corbA.Add(Eletrico);
                corbA.Add(Roubo);
                corbA.Add(RCF);
                corbA.Add(Aluguel);
                return corbA;
            }
            if (plano == "B")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 100.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 100.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$  100.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 5.000,00", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 4.500,00", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 2.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2.500,00", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.000,00 ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            if (plano == "C")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 150.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 150.000,00", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 150.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 6.000,00 ", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 5.000,00 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 3.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 3.000,00", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.000,00 ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            if (plano == "D")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 300.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 300.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 300.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 6.000,00 ", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 6.500,00 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 3.500,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 3.500,00 ", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 3.500,00 ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            if (plano == "E")
            {
                List<Cobertura> corbB = new List<Cobertura>();
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 500.000,00 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 500.000,00 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 500.000,00 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 10.000,00", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 10.000,00 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 5.000,00 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 4.000,00 ", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 4.500,00  ", id = 8 };
                corbB.Add(Incendio);
                corbB.Add(Raio);
                corbB.Add(Explosao);
                corbB.Add(Vendaval);
                corbB.Add(Eletrico);
                corbB.Add(Roubo);
                corbB.Add(RCF);
                corbB.Add(Aluguel);
                return corbB;
            }
            else return new List<Cobertura>();
        }

        [HttpGet]
        public List<Produto> GetMensalidade(string tipo)
        {
            List<Produto> produtos = new List<Produto>();
            

            if (tipo == "casa")
            {
               
                Produto oferta1 = new Produto()
                {
                    id = 1,
                    Nome = "Oferta 50",
                    ValorParcela = oferta1casa / 12,
                    Valor = oferta1casa,
                    cobertura = getLstCoberturarCasa("A")

                };
                Produto oferta2 = new Produto()
                {
                    id = 2,
                    Nome = "Oferta 100",
                    ValorParcela = oferta2casa / 12,
                    Valor = oferta2casa,
                    cobertura = getLstCoberturarCasa("B")
                };
                Produto oferta3 = new Produto()
                {
                    id = 3,
                    Nome = "Oferta 150",
                    ValorParcela = oferta3casa / 12,
                    Valor = oferta3casa,
                    cobertura = getLstCoberturarCasa("C")
                };
                Produto oferta4 = new Produto()
                {
                    id = 4,
                    Nome = "Oferta 300",
                    ValorParcela = oferta4casa / 12,
                    Valor = oferta4casa,
                    cobertura = getLstCoberturarCasa("D")
                };
                Produto oferta5 = new Produto()
                {
                    id = 5,
                    Nome = "Oferta 500",
                    ValorParcela = oferta5casa / 12,
                    Valor = oferta5casa,
                    cobertura = getLstCoberturarCasa("E")
                };

                produtos.Add(oferta1);
                produtos.Add(oferta2);
                produtos.Add(oferta3);
                produtos.Add(oferta4);
                produtos.Add(oferta5);

            }
            else if (tipo == "apartamento")
            {

                Produto oferta1 = new Produto()
                {
                    id = 1,
                    Nome = "Oferta 50",
                    ValorParcela = oferta1ap / 12,
                    Valor = oferta1ap,
                    cobertura = getLstCoberturarAPT("A")
                };
                Produto oferta2 = new Produto()
                {
                    id = 2,
                    Nome = "Oferta 100",
                    ValorParcela = oferta2ap / 12,
                    Valor = oferta2ap,
                    cobertura = getLstCoberturarAPT("B")
                };
                Produto oferta3 = new Produto()
                {
                    id = 3,
                    Nome = "Oferta 150",
                    ValorParcela = oferta3ap / 12,
                    Valor = oferta3ap,
                    cobertura = getLstCoberturarAPT("C")
                };
                Produto oferta4 = new Produto()
                {
                    id = 4,
                    Nome = "Oferta 300",
                    ValorParcela = oferta4ap / 12,
                    Valor = oferta4ap,
                    cobertura = getLstCoberturarAPT("D")
                };
                Produto oferta5 = new Produto()
                {
                    id = 5,
                    Nome = "Oferta 500",
                    ValorParcela = oferta5ap / 12,
                    Valor = oferta5ap,
                    cobertura = getLstCoberturarAPT("E")
                };

                produtos.Add(oferta1);
                produtos.Add(oferta2);
                produtos.Add(oferta3);
                produtos.Add(oferta4);
                produtos.Add(oferta5);

            }
            return produtos;
        }

        [HttpGet]
        public List<Produto> RetornList(string tipo, string ordem)
        {
            if (ordem == "id")
                return GetMensalidade(tipo).OrderBy(x => x.id).ToList();
            if (ordem == "idDec")
                return GetMensalidade(tipo).OrderByDescending(x => x.id).ToList();
            if (ordem == "valor")
                return GetMensalidade(tipo).OrderBy(x => x.Valor).ToList();
            if (ordem == "valorDec")
                return GetMensalidade(tipo).OrderByDescending(x => x.Valor).ToList();
            else
                return null;
        }
    }
}
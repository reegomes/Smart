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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 1,80 ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 1,80 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão - 1,80 ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$1,44", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 3,60", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 5,40", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$1,26", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 0,90 ", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 2,27  ", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 2,27  ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 2,27  ", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 1,82", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 4,54 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 6,81 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 1,59 ", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 1,13", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 2,86", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 2,86 ", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 2,86", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 2,29 ", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$  5,72 ", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 8,58 ", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2,00", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 1,43", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 3,60", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 3,60", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 3,60", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 2,88", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 7,21", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 10,81", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2,52", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 1,80", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 4,54", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 4,54", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 4,54", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 3,63", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 9,08", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 13,62", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 3,18", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 2,27", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 1,44", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 1,44", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão - R$ 1,44", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 1,15", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 2,88", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 4,32", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 1,01", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 0,72", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 1,82", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 1,82", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 1,82", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 1,45", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 3,63", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 5,45", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 1,27", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 0,91", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 2,29", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 2,29", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 2,29", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 1,83", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 4,58", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 6,86", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 1,60", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 1,14", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 2,88", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 2,88", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão -   R$ 2,88", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 2,31", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 5,77", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 8,65", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2,02", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 1,44", id = 8 };
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
                Cobertura Incendio = new Cobertura { nome = "Incendio - R$ 3,63", id = 1 };
                Cobertura Raio = new Cobertura { nome = "Queda de Raio - R$ 3,63", id = 2 };
                Cobertura Explosao = new Cobertura { nome = "Explosão - R$ 3,63", id = 3 };
                Cobertura Vendaval = new Cobertura { nome = "Vendaval, Furacão, Ciclone, Tornado e Granizo - R$ 2,91", id = 4 };
                Cobertura Eletrico = new Cobertura { nome = "Danos Elétricos - R$ 7,26", id = 5 };
                Cobertura Roubo = new Cobertura { nome = "Roubo de Bens - R$ 10,90", id = 6 };
                Cobertura RCF = new Cobertura { nome = "Responsabilidade Civil Familiar - R$ 2,54", id = 7 };
                Cobertura Aluguel = new Cobertura { nome = "Perda ou Pagamento de Aluguel - R$ 1,82", id = 8 };
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
                    ValorParcela = oferta1casa / 12,
                    Valor = oferta1casa,
                    cobertura = getLstCoberturarCasa("A")

                };
                Produto oferta2 = new Produto()
                {
                    id = 2,
                    ValorParcela = oferta2casa / 12,
                    Valor = oferta2casa,
                    cobertura = getLstCoberturarCasa("B")
                };
                Produto oferta3 = new Produto()
                {
                    id = 3,
                    ValorParcela = oferta3casa / 12,
                    Valor = oferta3casa,
                    cobertura = getLstCoberturarCasa("C")
                };
                Produto oferta4 = new Produto()
                {
                    id = 4,
                    ValorParcela = oferta4casa / 12,
                    Valor = oferta4casa,
                    cobertura = getLstCoberturarCasa("D")
                };
                Produto oferta5 = new Produto()
                {
                    id = 5,
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
                    ValorParcela = oferta1ap / 12,
                    Valor = oferta1ap,
                    cobertura = getLstCoberturarAPT("A")
                };
                Produto oferta2 = new Produto()
                {
                    id = 2,
                    ValorParcela = oferta2ap / 12,
                    Valor = oferta2ap,
                    cobertura = getLstCoberturarAPT("B")
                };
                Produto oferta3 = new Produto()
                {
                    id = 3,
                    ValorParcela = oferta3ap / 12,
                    Valor = oferta3ap,
                    cobertura = getLstCoberturarAPT("C")
                };
                Produto oferta4 = new Produto()
                {
                    id = 4,
                    ValorParcela = oferta4ap / 12,
                    Valor = oferta4ap,
                    cobertura = getLstCoberturarAPT("D")
                };
                Produto oferta5 = new Produto()
                {
                    id = 5,
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
using Start.Library;
using Start.Models;
using System;
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

        private const float oferta1casa = 216.15f;
        private const float oferta1ap = 172.92f;
        private const float oferta2casa = 272.35f;
        private const float oferta2ap = 217.88f;
        private const float oferta3casa = 343.16f;
        private const float oferta3ap = 274.53f;
        private const float oferta4casa = 432.39f;
        private const float oferta4ap = 345.91f;
        private const float oferta5casa = 544.81f;
        private const float oferta5ap = 435.84f;

        public string Get(string tipo, int plano)
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
        }

        public float Mensalidade(float oferta)
        {
            return oferta / 12;
        }
    }
}
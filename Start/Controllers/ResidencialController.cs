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
            // Esse post vai receber bool? idk, veremos

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
    }
}
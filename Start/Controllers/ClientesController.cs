using Start.Library;
using Start.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Start.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static readonly List<Cotacao> cotacoes = new List<Cotacao>();

        public ContextDB Banco { get; set; }


        // Consulta
        /* http://localhost:56067/Api/Clientes */
        [HttpGet]
        public ICollection<Cliente> ListarClientes()
        {
            return clientes.ToList();
        }


        /* http://localhost:56067/Api/Clientes?nome=joao&modelo=vectra&marca=gm&ano=1998 */
        public void Post(string cpf, string nome, string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                using (var ctx = new ContextDB())
                {
                    Cliente cliente = new Cliente(cpf, nome);
                    Cotacao cotacao = new Cotacao(idade, genero, marca, modelo, anoFabricacao, anoModelo);
                    try
                    {
                        var BuscaCPF = ctx.Clientes.Where(c => c.CPF == cliente.CPF).FirstOrDefault();
                        if (cliente.CPF == BuscaCPF.CPF)
                        {
                            cotacao.ClienteId = BuscaCPF.Id;
                            ctx.Cotacoes.Add(cotacao);
                            ctx.SaveChanges();
                        }
                    }
                    catch (NullReferenceException)
                    {
                        ctx.Clientes.Add(cliente);
                        ctx.Cotacoes.Add(cotacao);
                        ctx.SaveChanges();
                        return;
                    }
                }
            }
        }

        // deletar dados
        public void Delete(string nome)
        {
            //clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.Nome.Equals(nome))));
        }
    }
}

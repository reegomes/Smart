using Start.Library;
using Start.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System;

namespace Start.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static List<Cotacao> cotacoes = new List<Cotacao>();

        public ContextDB Banco { get; set; }


        // Consulta
        /* http://localhost:56067/Api/Clientes */

        public ICollection<Cliente> ListarClientes()
        {
            return null;
        }


        /* http://localhost:56067/Api/Clientes?nome=joao&modelo=vectra&marca=gm&ano=1998 */
        public void Post(string cpf, string nome, string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                using (var ctx = new ContextDB())
                {
                 
                    Cliente cliente = new Cliente(cpf, nome);
                    Cotacao cotacao = new Cotacao(cliente, cliente.ID, idade, genero, marca, modelo, anoFabricacao, anoModelo);
                    //Cotacao cotacaoAdd = new Cotacao(idade, genero, marca, modelo, anoFabricacao, anoModelo);

                    //Cliente user = ctx.Clientes.Create();
                    //Cotacao cota = ctx.Cotacoes.Create();


                        ctx.Clientes.Add(cliente);
                        ctx.Cotacoes.Add(cotacao);
                        ctx.SaveChanges();
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

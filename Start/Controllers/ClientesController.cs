using Start.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Start.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static List<Cotacao> cotacoes = new List<Cotacao>();


        //public ManagerDB.Models.Carros Db { get; set; }


        // Consulta
        /* http://localhost:56067/Api/Clientes */
        public List<Cotacao> Get()
        {
            return cotacoes;
        }

        

        // inserção de dados
        public void Post(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                clientes.Add(new Cliente(nome));
            }
        }

        /* http://localhost:56067/Api/Clientes?nome=joao&modelo=vectra&marca=gm&ano=1998 */
        public void Post(string cpf, string nome, string idade, string genero, string marca, string modelo, string anoFabricacao, string anoModelo)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                Cliente prov = new Cliente(cpf, nome);
                cotacoes.Add(new Cotacao(nome,idade,genero,marca,modelo,anoFabricacao,anoModelo, prov, prov.Id));

                //Cotacao prov = new Cotacao(nome, idade, genero, marca, modelo, anoFabricacao, anoModelo);
                //clientes.Add(new Cliente(prov, cpf, nome));
            }
        }



        // deletar dados
        public void Delete(string nome)
        {
            clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.Nome.Equals(nome))));
        }
    }
}

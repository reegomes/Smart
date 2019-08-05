using Start.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;



namespace Start.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();

        //public ManagerDB.Models.Carros Db { get; set; }


        // Consulta
        /* http://localhost:56067/Api/Clientes */
        public List<Cliente> Get()
        {
            return clientes;
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
        public void Post(string nome, string marca, string modelo, string ano, string idade, string genero)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                clientes.Add(new Cliente(nome, modelo, marca, ano, idade, genero));
            }
        }



        // deletar dados
        public void Delete(string nome)
        {
            clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.Nome.Equals(nome))));
        }
    }
}

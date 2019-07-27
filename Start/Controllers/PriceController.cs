using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Start.Controllers
{
    public class PriceController : ApiController
    {
        //Caso eu queira fazer um get preciso colocar 
        //[HttpGet] em cima do método
        /* http://localhost:56067/Api/Clientes/GetSoma?a=1&b=3 */
        [HttpGet]
        public int GetPrice(int c, int d)
        {
            return c + d;
        }
    }
}

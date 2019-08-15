using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Serialization.Xml;
using Start.Library;
using Start.Models;
using System.Xml.Serialization;

namespace Start.Controllers
{
    [Serializable()]
    public class ViagemController : ApiController
    {
        private ContextDB db = new ContextDB();

        private float[,] valores = new float[30,3];


        
        public float Valor(int dia, int plano)
        {
            if (plano == 1)
            {
                #region PlanoEconomy
                valores[3, 1] = 15;
                valores[4, 1] = 17;
                valores[5, 1] = 18;
                valores[6, 1] = 20;
                valores[7, 1] = 22;
                valores[8, 1] = 24;
                valores[9, 1] = 26;
                valores[10, 1] = 28;
                valores[11, 1] = 29;
                valores[12, 1] = 31;
                valores[13, 1] = 33;
                valores[14, 1] = 35;
                valores[15, 1] = 37;
                valores[16, 1] = 38;
                valores[17, 1] = 40;
                valores[18, 1] = 42;
                valores[19, 1] = 44;
                valores[20, 1] = 46;
                valores[21, 1] = 48;
                valores[22, 1] = 50;
                valores[23, 1] = 51;
                valores[24, 1] = 53;
                valores[25, 1] = 55;
                valores[26, 1] = 57;
                valores[27, 1] = 58;
                valores[28, 1] = 60;
                valores[29, 1] = 62;
                valores[30, 1] = 64;

                #endregion
            }
            else if (plano == 2)
            {
                #region PlanoGold
                valores[3, 2] = 29;
                valores[4, 2] = 32;
                valores[5, 2] = 34;
                valores[6, 2] = 37;
                valores[7, 2] = 40;
                valores[8, 2] = 43;
                valores[9, 2] = 46;
                valores[10, 2] = 49;
                valores[11, 2] = 52;
                valores[12, 2] = 54;
                valores[13, 2] = 58;
                valores[14, 2] = 60;
                valores[15, 2] = 63;
                valores[16, 2] = 66;
                valores[17, 2] = 69;
                valores[18, 2] = 72;
                valores[19, 2] = 75;
                valores[20, 2] = 78;
                valores[21, 2] = 80;
                valores[22, 2] = 83;
                valores[23, 2] = 86;
                valores[24, 2] = 89;
                valores[25, 2] = 92;
                valores[26, 2] = 95;
                valores[27, 2] = 98;
                valores[28, 2] = 101;
                valores[29, 2] = 104;
                valores[30, 2] = 106;
                #endregion
            }
            else if(plano == 3)
            {
                #region PlanoPremium
                valores[3, 3] = 49;
                valores[4, 3] = 52;
                valores[5, 3] = 56;
                valores[6, 3] = 60;
                valores[7, 3] = 63;
                valores[8, 3] = 67;
                valores[9, 3] = 70;
                valores[10, 3] = 74;
                valores[11, 3] = 78;
                valores[12, 3] = 81;
                valores[13, 3] = 85;
                valores[14, 3] = 88;
                valores[15, 3] = 92;
                valores[16, 3] = 96;
                valores[17, 3] = 99;
                valores[18, 3] = 103;
                valores[19, 3] = 106;
                valores[20, 3] = 110;
                valores[21, 3] = 114;
                valores[22, 3] = 117;
                valores[23, 3] = 121;
                valores[24, 3] = 124;
                valores[25, 3] = 128;
                valores[26, 3] = 132;
                valores[27, 3] = 135;
                valores[28, 3] = 139;
                valores[29, 3] = 142;
                valores[30, 3] = 146;
                #endregion
            }

            return valores[dia, plano];
        }

        //

        [HttpGet]
        public string GetDolar()
        {
            var restClient = new RestClient(string.Format("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao='{0}'", DateTime.Now.ToString("MM'-'dd'-'yyyy")));
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            var oi = restResponse.Content;

            return oi;

        }
    }
}
 
 
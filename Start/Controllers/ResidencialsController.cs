using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Start.Library;
using Start.Models;

namespace Start.Controllers
{
    public class ResidencialsController : ApiController
    {
        private ContextDB db = new ContextDB();

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
        private static Cobertura Incendio = new Cobertura
        {
            nome = "Compreensivo",
            id = 1
        };
        private static Cobertura RouboEFurto = new Cobertura
        {
            nome = "Roubo e Furto",
            id = 2
        };
        private static Cobertura PT = new Cobertura
        {
            nome = "PT Colisão e Roubo e Furto",
            id = 3
        };

        #endregion


        /* http://localhost:56067/Api/Residencials?cpf=12345678910&nome=fulano&marca=gm&ano=1998 */
        public void Post(string cpf, string nome, string cEP, string numeroDaCasa, string complemento, string tipo, string logradouro)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                using (var ctx = new ContextDB())
                {
                    Cliente cliente = new Cliente(cpf, nome);
                    Residencial cotacaoRE = new Residencial(cEP, numeroDaCasa, complemento, tipo, logradouro);
                    try
                    {
                        var BuscaCPF = ctx.Clientes.Where(c => c.CPF == cliente.CPF).FirstOrDefault();
                        if (cliente.CPF == BuscaCPF.CPF)
                        {
                            cotacaoRE.ClienteId = BuscaCPF.Id;
                            ctx.Residencials.Add(cotacaoRE);
                            ctx.SaveChanges();
                        }
                    }
                    catch (NullReferenceException)
                    {
                        ctx.Clientes.Add(cliente);
                        ctx.Residencials.Add(cotacaoRE);
                        ctx.SaveChanges();
                        return;
                    }
                }
            }
        }

        public string Get(string tipo, int plano)
        {
            if (tipo == "casa")
            {
                if (plano == 1) { return mensalidade(oferta1casa).ToString(); }
                else if (plano == 2) { return mensalidade(oferta2casa).ToString(); }
                else if (plano == 3) { return mensalidade(oferta3casa).ToString(); }
                else if (plano == 4) { return mensalidade(oferta4casa).ToString(); }
                else if (plano == 5) { return mensalidade(oferta5casa).ToString(); }
            }
            else if (tipo == "apartamento")
            {
                if (plano == 1) { return mensalidade(oferta1ap).ToString(); }
                else if (plano == 2) { return mensalidade(oferta2ap).ToString(); }
                else if (plano == 3) { return mensalidade(oferta3ap).ToString(); }
                else if (plano == 4) { return mensalidade(oferta4ap).ToString(); }
                else if (plano == 5) { return mensalidade(oferta5ap).ToString(); }
            }
            else
            {
                return "Error";
            }

            return null;
        }

        public float mensalidade(float oferta)
        {
            return oferta / 12;
        }

        // GET: api/Residencials
        public IQueryable<Residencial> GetResidencials()
        {
            return db.Residencials;
        }

        // GET: api/Residencials/5
        [ResponseType(typeof(Residencial))]
        public async Task<IHttpActionResult> GetResidencial(int id)
        {
            Residencial residencial = await db.Residencials.FindAsync(id);
            if (residencial == null)
            {
                return NotFound();
            }

            return Ok(residencial);
        }

        // PUT: api/Residencials/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResidencial(int id, Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residencial.Id)
            {
                return BadRequest();
            }

            db.Entry(residencial).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidencialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Residencials
        [ResponseType(typeof(Residencial))]
        public async Task<IHttpActionResult> PostResidencial(Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residencials.Add(residencial);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = residencial.Id }, residencial);
        }

        // DELETE: api/Residencials/5
        [ResponseType(typeof(Residencial))]
        public async Task<IHttpActionResult> DeleteResidencial(int id)
        {
            Residencial residencial = await db.Residencials.FindAsync(id);
            if (residencial == null)
            {
                return NotFound();
            }

            db.Residencials.Remove(residencial);
            await db.SaveChangesAsync();

            return Ok(residencial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidencialExists(int id)
        {
            return db.Residencials.Count(e => e.Id == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Start.Library;
using Start.Models;

namespace Start.Controllers
{
    public class ResidencialController : ApiController
    {
        private ContextDB db = new ContextDB();


        private bool aptocasa;
        private float iqre = 0;
        private float ferb = 0;
        private float dt = 0;
        private float ppa = 0;

        public void Post(string cpf, string nome, string cEP, string numeroDaCasa, string complemento, string tipo, string logradouro, bool aptocasa, string iqre, string ferb, string dt, string ppa) 
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
                    Residencial residencial = new Residencial(cEP, numeroDaCasa, complemento, tipo, logradouro);
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


        // GET: api/Residencial
        public IQueryable<Residencial> GetResidencials()
        {
            return db.Residencials;
        }

        // GET: api/Residencial/5
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult GetResidencial(int id)
        {
            Residencial residencial = db.Residencials.Find(id);
            if (residencial == null)
            {
                return NotFound();
            }

            return Ok(residencial);
        }

        // PUT: api/Residencial/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResidencial(int id, Residencial residencial)
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
                db.SaveChanges();
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

        // POST: api/Residencial
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult PostResidencial(Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residencials.Add(residencial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = residencial.Id }, residencial);
        }

        // DELETE: api/Residencial/5
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult DeleteResidencial(int id)
        {
            Residencial residencial = db.Residencials.Find(id);
            if (residencial == null)
            {
                return NotFound();
            }

            db.Residencials.Remove(residencial);
            db.SaveChanges();

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
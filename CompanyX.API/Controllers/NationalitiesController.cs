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
using System.Web.Http.ModelBinding;
using CompanyX.Data.Context;
using CompanyX.Data.Interfaces;
using CompanyX.Data.Models;
using CompanyX.Data.Services;

namespace CompanyX.API.Controllers
{
    public class NationalitiesController : ApiController
    {
        private Func<IEntityFactory> _entityFactory;
        private IUnitOfWork _unit;

        public NationalitiesController(Func<IEntityFactory> entityFactory, IUnitOfWork unit)
        {
            _entityFactory = entityFactory;
            _unit = unit;
        }
      
        // GET: api/Nationalities
        public IHttpActionResult GetNationalities()
        {
            var nationalities = _unit.NationalityRepository.Get().ToList();
            return Ok(nationalities);
        }

        // GET: api/Nationalities/5
        [ResponseType(typeof(Nationality))]
        public IHttpActionResult GetNationality(int id)
        {
            var nationality = _unit.NationalityRepository.GetByID(id);
            if (nationality == null)
            {
                return NotFound();
            }

            return Ok(nationality);
        }

        // PUT: api/Nationalities/5
        [ResponseType(typeof(void))]
        public  IHttpActionResult PutNationality(int id, Nationality nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nationality.NationalityId)
            {
                return BadRequest();
            }         
            try
            {
                _unit.NationalityRepository.Update(nationality);
                _unit.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalityExists(id))
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

        // POST: api/Nationalities
        [ResponseType(typeof(Nationality))]
        public  IHttpActionResult PostNationality(Nationality nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unit.NationalityRepository.Insert(nationality);
            _unit.Save();

            return CreatedAtRoute("DefaultApi", new { id = nationality.NationalityId }, nationality);
        }

        // DELETE: api/Nationalities/5
        [ResponseType(typeof(Nationality))]
        public  IHttpActionResult DeleteNationality(int id)
        {
            Nationality nationality = _unit.NationalityRepository.GetByID(id);
            if (nationality == null)
            {
                return NotFound();
            }

            _unit.NationalityRepository.Delete(id);
            _unit.Save();

            return Ok(nationality);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NationalityExists(int id)
        {
            return _unit.NationalityRepository.Get().Count(e=>e.NationalityId == id) > 0;
        }
    }
}
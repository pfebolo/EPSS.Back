using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;
using Microsoft.EntityFrameworkCore;


namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class GruposController : Controller
    {
        private IRepository<Grupos> _repo;
        
        public GruposController(IRepository<Grupos> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Grupos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetGrupos")]
        public IActionResult GetById(int id)
        {
            var item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Grupos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetGrupos", new { controller = "Grupos", id = item.CarreraId }, item);
        }

		[HttpDelete("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/{AlumnoId}")]
		public IActionResult Delete(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId, int AlumnoId)
		{
			try
			{
				var item = _repo.Find(CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId, AlumnoId);
				if (item == null)
				{
					return NoContent(); //Sin error por que DELETE es Idempotente.
				}
				_repo.Remove(item); ;
				return NoContent();
			}
			catch (Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
			{
				return Utils.ResponseConfict(ex);
			}
			catch (System.Exception ex)
			{
				return Utils.ResponseInternalError(ex);
			}
		}
    }
}
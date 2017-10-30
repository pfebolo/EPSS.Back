using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;
using Microsoft.EntityFrameworkCore;


namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class DivisionesController : BaseController<Divisiones>
    {

		public DivisionesController(IRepository<Divisiones> repo) : base (repo){}

		[HttpGet("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}", Name = "GetDivisiones")]
		public IActionResult GetById(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId)
		{
			var item = _repo.Find(CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

        [HttpPost]
        public override IActionResult Create([FromBody] Divisiones item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetDivisiones", new { controller = "Divisiones", id = item.CarreraId }, item);
        }

		// PUT api/Divisiones
		[HttpPut]
		public override IActionResult Put([FromBody] Divisiones item)
		{
			try
			{
				if (item == null)
					return BadRequest();

				var division = _repo.Find(item.CarreraId,item.ModoId,item.AnioInicio,item.MesInicio,item.AnioLectivo,item.NmestreLectivo,item.TurnoId,item.DivisionId);

				if (division == null)
					return NotFound();

				_repo.Update(item);
				return NoContent();
			}
			catch (Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
			{
				return Utils.ResponseConfict(ex);
			}
			catch (Exception ex)
			{
				return Utils.ResponseInternalError(ex);
			}
		}


		[HttpDelete("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}")]
		public IActionResult Delete(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId)
		{
			return base.Delete(new Object[] {CarreraId,ModoId,AnioInicio,MesInicio,AnioLectivo,NmestreLectivo,TurnoId,DivisionId});
		}
    }
}
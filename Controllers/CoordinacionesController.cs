using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class CoordinacionesController : BaseController<Coordinaciones>
	{
		public CoordinacionesController(IRepository<Coordinaciones> repo) : base (repo){}


		[HttpGet("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/{CoordinadorId}", Name = "GetCoordinaciones")]
		public IActionResult GetById(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId, int CoordinadorId)
		{
			var item = _repo.Find(CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId, CoordinadorId);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public override IActionResult Create([FromBody] Coordinaciones item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			_repo.Add(item);
			return CreatedAtRoute("GetCoordinaciones", new { controller = "Coordinaciones", CarreraId = item.CarreraId, ModoId = item.ModoId, AnioInicio = item.AnioInicio, MesInicio = item.MesInicio, AnioLectivo = item.AnioLectivo, NmestreLectivo = item.NmestreLectivo, TurnoId = item.TurnoId, DivisionId = item.DivisionId, CoordinadorId = item.CoordinadorId }, item);
		}


		// PUT api/Coordinaciones
		[HttpPut]
		public override IActionResult Put([FromBody] Coordinaciones item)
		{
			try
			{
				if (item == null)
					return BadRequest();

				var coordinacion = _repo.Find(item.CarreraId, item.ModoId, item.AnioInicio, item.MesInicio, item.AnioLectivo, item.NmestreLectivo, item.TurnoId, item.DivisionId, item.CoordinadorId);

				if (coordinacion == null)
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

		[HttpDelete("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/{CoordinadorId}")]
		public IActionResult Delete(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId, int CoordinadorId)
		{
			return base.Delete(new Object[] {CarreraId,ModoId,AnioInicio,MesInicio,AnioLectivo,NmestreLectivo,TurnoId,DivisionId,CoordinadorId});
		}

	}
}

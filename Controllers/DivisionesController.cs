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
		protected IDivisionesRepository _repoExt;

		public DivisionesController(IRepository<Divisiones> repo) : base(repo) { 
			_repoExt = (IDivisionesRepository)_repo; //Se asigna con el CAST necesario para acceder a los métodos extendidos.
		}

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
			try
			{
				if (item == null)
				{
					return BadRequest();
				}
				_repo.Add(item);
				// return CreatedAtRoute("GetDivisiones", new
				// {
				// 	controller = "Divisiones",
				// 	CarreraId = item.CarreraId,
				// 	ModoId = item.ModoId,
				// 	AnioInicio = item.AnioInicio,
				// 	MesInicio = item.MesInicio,
				// 	AnioLectivo = item.AnioLectivo,
				// 	NmestreLectvo = item.NmestreLectivo,
				// 	TurnoId = item.TurnoId,
				// 	DivisionId = item.DivisionId,
				// }, item);
				return Utils.ResponseCreated(); //No devuelve la ruta
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

		// PUT api/Divisiones
		[HttpPut]
		public override IActionResult Put([FromBody] Divisiones item)
		{
			try
			{
				if (item == null)
					return BadRequest();

				var division = _repo.Find(item.CarreraId, item.ModoId, item.AnioInicio, item.MesInicio, item.AnioLectivo, item.NmestreLectivo, item.TurnoId, item.DivisionId);

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


		// POST api/Divisiones/.../Promocion
		[HttpPost("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/Promocion")]
		public IActionResult Promover(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId, [FromBody] Divisiones divisionDestino)
		{
			try
			{
				if (divisionDestino == null)
					return BadRequest();

				var existeDestino = _repoExt.Find(divisionDestino.CarreraId, divisionDestino.ModoId, divisionDestino.AnioInicio, divisionDestino.MesInicio, divisionDestino.AnioLectivo, divisionDestino.NmestreLectivo, divisionDestino.TurnoId, divisionDestino.DivisionId);
				var divisionOrigen = _repoExt.Find(CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId);

				if (existeDestino==null || divisionOrigen==null)
					return NotFound();

				_repoExt.Promover(divisionOrigen, divisionDestino);
				return NoContent();
			}
			catch (Exception ex) when (ex is DbUpdateException)
			{
				return Utils.ResponseConfict(ex);
			}
			catch (Exception ex)
			{
				return Utils.ResponseInternalError(ex);
			}
		}

		// PUT api/Divisiones/.../Egreso
		[HttpPost("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/Egreso")]
		public IActionResult Egresar(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId)
		{
			try
			{
				var division = _repoExt.Find(CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId);

				if (division==null)
					return NotFound();

				_repoExt.Egresar(division);
				return NoContent();
			}
			catch (Exception ex) when (ex is DbUpdateException)
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
			return base.Delete(new Object[] { CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId });
		}
	}
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;
using Microsoft.EntityFrameworkCore;


namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class GruposController : BaseController<Grupos>
	{
		//Para acceder a los métodos extendidos de la Interface extendida
		protected IGruposRepository _repoExt;
		//Se injecta la Interface extendida
		public GruposController(IGruposRepository repo) : base(repo)
		{
			_repoExt = (IGruposRepository)_repo; //Se asigna con el CAST necesario para acceder a los métodos extendidos.
		}

		[HttpGet("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/{AlumnoId}", Name = "GetGrupos")]
		public IActionResult GetById(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId, int AlumnoId)
		{
			var item = _repo.Find(CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId, AlumnoId);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpGet("byAlumno/{AlumnoId}", Name = "GetGruposByAlumno")]
		public IEnumerable<Grupos> GetByAlumnoId(int AlumnoId)
		{
			return _repoExt.FindByAlumnoId(AlumnoId);
		}

		[HttpPost]
		public override IActionResult Create([FromBody] Grupos item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			_repo.Add(item);
			// return CreatedAtRoute("GetGrupos", new
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
			// 	AlumnoId = item.AlumnoId,
			// }, item);
			return Utils.ResponseCreated(); //No devuelve la ruta
		}

        [HttpPost("Coleccion", Name = "MasiveCreate")]
		public IActionResult MasiveCreate([FromBody] Grupos[] items)
		{
			if (items == null)
			{
				return BadRequest();
			}
			try
			{
				if (items.Length > 0)
					_repoExt.MasiveAdd(items);
			}
			catch (Exception ex) when (ex is DbUpdateException)
			{
				return Utils.ResponseConfict(ex);
			}
			catch (Exception ex)
			{
				return Utils.ResponseInternalError(ex);
			}
			return Utils.ResponseCreated();
		}




		[HttpDelete("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/{AlumnoId}")]
		public IActionResult Delete(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId, int AlumnoId)
		{
			return base.Delete(new Object[] { CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId, AlumnoId });
		}
	}
}
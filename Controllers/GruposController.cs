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
		public GruposController(IRepository<Grupos> repo) : base(repo) { }

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

		[HttpDelete("{CarreraId}/{ModoId}/{AnioInicio}/{MesInicio}/{AnioLectivo}/{NmestreLectivo}/{TurnoId}/{DivisionId}/{AlumnoId}")]
		public IActionResult Delete(int CarreraId, string ModoId, int AnioInicio, int MesInicio, int AnioLectivo, int NmestreLectivo, string TurnoId, string DivisionId, int AlumnoId)
		{
            return base.Delete(new Object[] { CarreraId, ModoId, AnioInicio, MesInicio, AnioLectivo, NmestreLectivo, TurnoId, DivisionId, AlumnoId});
		}
    }
}
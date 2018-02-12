using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;

namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class InteraccionesController : BaseController<Interacciones>
	{
		protected IIntereaccionesRepository _repoExt;
		public InteraccionesController(IRepository<Interacciones> repo) : base(repo) { 
			_repoExt = (IIntereaccionesRepository)_repo; //Se asigna con el CAST necesario para acceder a los métodos extendidos.
		}

		[HttpGet("{AlumnoId}/{InteraccionId}", Name = "GetInteraccionXId")]
		public IActionResult GetById(int AlumnoId, int InteraccionId)
		{
            return base.GetById(new Object[] { AlumnoId, InteraccionId });
		}

        [HttpDelete("{AlumnoId}/{InteraccionId}")]
		public IActionResult Delete(int AlumnoId, int InteraccionId)
		{
			return base.Delete(new Object[] { AlumnoId, InteraccionId });
		}

		[HttpGet("byAlumno/{AlumnoId}", Name = "GetIntereaccionesByAlumno")]
		public IEnumerable<Interacciones> GetByAlumnoId(int AlumnoId)
		{
			return _repoExt.FindByAlumnoId(AlumnoId);
		}

	}
}
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
		protected IInteraccionesRepository _repoExt;
		public InteraccionesController(IRepository<Interacciones> repo) : base(repo) { 
			_repoExt = (IInteraccionesRepository)_repo; //Se asigna con el CAST necesario para acceder a los métodos extendidos.
		}

		[HttpGet("byAlumno/{AlumnoId}", Name = "GetInteraccionesByAlumno")]
		public IEnumerable<Interacciones> GetByAlumnoId(int AlumnoId)
		{
			return _repoExt.FindByAlumnoId(AlumnoId);
		}

	}
}
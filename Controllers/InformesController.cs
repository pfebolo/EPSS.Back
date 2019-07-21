using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;


namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class InformesController : BaseController<Informes>
	{
		protected IInformesRepository _repoExt;
		public InformesController(IRepository<Informes> repo) : base(repo) { 
			_repoExt = (IInformesRepository)_repo; //Se asigna con el CAST necesario para acceder a los métodos extendidos.
		}

		[HttpGet("byAlumno/{AlumnoId}", Name = "GetInformesByAlumno")]
		public IEnumerable<Informes> GetByAlumnoId(int AlumnoId)
		{
			return _repoExt.FindByAlumnoId(AlumnoId);
		}

	}
}
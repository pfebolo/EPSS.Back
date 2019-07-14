using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;

namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class InteraccionesInteresadosController : BaseController<InteraccionesInteresados>
	{

		protected IInteraccionesInteresadosRepository _repoExt;
		public InteraccionesInteresadosController(IRepository<InteraccionesInteresados> repo) : base(repo)
		{
			_repoExt = (IInteraccionesInteresadosRepository)_repo; //Se asigna con el CAST necesario para acceder a los métodos extendidos.
		}

		[HttpGet("byInteresado/{InteresadoId}", Name = "GetInteraccionesByInteresado")]
		public IEnumerable<InteraccionesInteresados> GetByInteresadoId(int InteresadoId)
		{
			return _repoExt.FindByInteresadoId(InteresadoId);
		}

	}
}
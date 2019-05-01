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

		[HttpGet("{InteresadoId}/{InteraccionInteresadoId}", Name = "GetInteraccionInteresadoXId")]
		public IActionResult GetById(int InteresadoId, int InteraccionInteresadoId)
		{
			return base.GetById(new Object[] { InteresadoId, InteraccionInteresadoId });
		}

		[HttpDelete("{InteresadoId}/{InteraccionInteresadoId}")]
		public IActionResult Delete(int InteresadoId, int InteraccionInteresadoId)
		{
			return base.Delete(new Object[] { InteresadoId, InteraccionInteresadoId });
		}

		[HttpGet("byInteresado/{InteresadoId}", Name = "GetInteraccionesByInteresado")]
		public IEnumerable<InteraccionesInteresados> GetByInteresadoId(int InteresadoId)
		{
			return _repoExt.FindByInteresadoId(InteresadoId);
		}

	}
}
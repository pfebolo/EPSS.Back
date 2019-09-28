using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

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

		[HttpGet("ByInforme/{AlumnoId}/{CoordinadoraId}/{AnioLectivo}", Name = "FindByInforme")]
		public IActionResult FindByInforme(int AlumnoId,int CoordinadoraId, int AnioLectivo)
		{
			try
			{
				var item = _repoExt.FindByInforme(AlumnoId,CoordinadoraId,AnioLectivo);
				if (item == null)
				{
					return NotFound();
				}
				return new ObjectResult(item);
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
	}
	
}
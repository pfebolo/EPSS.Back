using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class InteraccionesInteresadosController : BaseController<InteraccionesInteresados>
	{
		public InteraccionesInteresadosController(IRepository<InteraccionesInteresados> repo) : base(repo) { }
	}
}
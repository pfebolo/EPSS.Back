using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class CoordinadoresController : BaseController<Coordinadores>
	{
		public CoordinadoresController(IRepository<Coordinadores> repo) : base (repo){}
	}
}
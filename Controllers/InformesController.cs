using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class InformesController : BaseController<Informes>
	{
		public InformesController(IRepository<Informes> repo) : base (repo){}
	}
}
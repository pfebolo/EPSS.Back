using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class EstadosDivisionController : BaseController<EstadosDivision>
    {
       public EstadosDivisionController(IRepository<EstadosDivision> repo) : base (repo){}
    }
}
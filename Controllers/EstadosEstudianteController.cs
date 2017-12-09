using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class EstadosEstudianteController : BaseController<EstadosEstudiante>
    {
       public EstadosEstudianteController(IRepository<EstadosEstudiante> repo) : base (repo){}
    }
}
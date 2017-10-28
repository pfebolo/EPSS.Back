using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class DispositivosController : BaseController<Dispositivos>
    {
       public DispositivosController(IRepository<Dispositivos> repo) : base (repo){}
    }
}
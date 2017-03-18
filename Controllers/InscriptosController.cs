using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.DTOs;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class InscriptosController : Controller
    {
        private IInscriptosRepository _repo;
        
        public InscriptosController(IInscriptosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Inscriptos> GetAll()
        {
            return _repo.GetAll();
        }


        // PUT api/Inscriptos
        [HttpPut]
        public IActionResult Put([FromBody] IEnumerable<Inscriptos> item)
        {
            if (item == null)
                return BadRequest();

            // var Modo = _repo.Find(item.InscriptoId);

            // if (Modo == null)
            //     return NotFound();

            // _repo.Update(item);

            return NoContent();
        }


    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class EstadosCursosController : Controller
    {
        private IEstadosCursosRepository _repo;
        
        public EstadosCursosController(IEstadosCursosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<EstadosCurso> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetEstadosCurso")]
        public IActionResult GetById(int id)
        {
            var item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EstadosCurso item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetEstadosCursos", new { controller = "EstadosCursos", PaisId = item.EstadoCursoId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
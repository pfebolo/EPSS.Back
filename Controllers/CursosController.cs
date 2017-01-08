using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class CursosController : Controller
    {
        private ICursosRepository _repo;
        
        public CursosController(ICursosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Cursos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCursos")]
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
        public IActionResult Create([FromBody] Cursos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetCursos", new { controller = "Cursos", CursoId = item.CursoId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
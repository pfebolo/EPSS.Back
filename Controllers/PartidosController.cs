using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using EPSS.Repositories;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class PartidosController : Controller
    {
        private IPartidosRepository _repo;
        
        public PartidosController(IPartidosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Partidos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetPartidos")]
        public IActionResult GetById(string id)
        {
            var item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Partidos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetPartidos", new { controller = "Partidos", PartidoId = item.PartidoId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repo.Remove(id);
        }
    }
}
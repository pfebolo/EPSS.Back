using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private IEventosRepository _repo;
        
        public EventosController(IEventosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Eventos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetEventos")]
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
        public IActionResult Create([FromBody] Eventos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetEventos", new { controller = "Eventos", EventoId = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
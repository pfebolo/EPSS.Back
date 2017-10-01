using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class TurnosController : Controller
    {
        private IRepository<Turnos> _repo;
        
        public TurnosController(IRepository<Turnos> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Turnos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetTurnos")]
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
        public IActionResult Create([FromBody] Turnos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetTurnos", new { controller = "Turnos", id = item.TurnoId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
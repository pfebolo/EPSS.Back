using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class LugaresController : Controller
    {
        private ILugaresRepository _repo;
        
        public LugaresController(ILugaresRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Lugares> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetLugares")]
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
        public IActionResult Create([FromBody] Lugares item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetLugares", new { controller = "Lugares", LugarId = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
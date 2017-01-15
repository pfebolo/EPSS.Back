using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using EPSS.Repositories;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class LegajosController : Controller
    {
        private ILegajosRepository _repo;
        
        public LegajosController(ILegajosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Legajos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetLegajos")]
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
        public IActionResult Create([FromBody] Legajos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetLegajos", new { controller = "Legajos", AlumnoId = item.AlumnoId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
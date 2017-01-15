using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class PaisesController : Controller
    {
        private IPaisesRepository _repo;
        
        public PaisesController(IPaisesRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Paises> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetPaises")]
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
        public IActionResult Create([FromBody] Paises item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetPaises", new { controller = "Paises", PaisId = item.PaisId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repo.Remove(id);
        }
    }
}
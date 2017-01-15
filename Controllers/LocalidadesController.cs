using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class LocalidadesController : Controller
    {
        private ILocalidadesRepository _repo;
        
        public LocalidadesController(ILocalidadesRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Localidades> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetLocalidades")]
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
        public IActionResult Create([FromBody] Localidades item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetLocalidades", new { controller = "Localidades", LocalidadId = item.LocalidadId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class ModalidadesController : Controller
    {
        private IModalidadesRepository _repo;
        
        public ModalidadesController(IModalidadesRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Modalidades> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetModalidades")]
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
        public IActionResult Create([FromBody] Modalidades item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetModalidades", new { controller = "Modalidades", ModalidadId = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
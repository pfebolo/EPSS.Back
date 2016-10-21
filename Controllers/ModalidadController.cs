using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.API.Models;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class ModalidadController : Controller
    {
        private IModalidadRepository _repo;
        
        public ModalidadController(IModalidadRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Modalidad> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetModalidad")]
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
        public IActionResult Create([FromBody] Modalidad item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            // return CreatedAtRoute("GetModalidad", new { controller = "Modalidad", ModalidadId = item.ModalidadId }, item);
            return CreatedAtRoute("GetModalidad", new { controller = "Modalidad", modalidad_id = item.modalidad_id }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
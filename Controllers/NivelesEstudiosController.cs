using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class NivelesEstudiosController : Controller
    {
        private INivelesEstudiosRepository _repo;
        
        public NivelesEstudiosController(INivelesEstudiosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<NivelesEstudios> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetNivelesEstudios")]
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
        public IActionResult Create([FromBody] NivelesEstudios item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetNivelesEstudios", new { controller = "NivelesEstudios", NivelEstudioId = item.NivelEstudioId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repo.Remove(id);
        }
    }
}
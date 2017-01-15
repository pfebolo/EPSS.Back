using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.API.Models;
using EPSS.Repositories;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class BasicoController : Controller
    {
        private IBasicoRepository _repo;
        
        public BasicoController(IBasicoRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Basico> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetBasico")]
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
        public IActionResult Create([FromBody] Basico item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            // return CreatedAtRoute("GetBasico", new { controller = "Basico", BasicoId = item.BasicoId }, item);
            return CreatedAtRoute("GetBasico", new { controller = "Basico", Basico_id = item.Basico_id }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
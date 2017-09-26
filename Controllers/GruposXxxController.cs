using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class GruposXxxController : Controller
    {
        private IRepository<GruposXxx> _repo;
        
        public GruposXxxController(IRepository<GruposXxx> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<GruposXxx> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetGruposXxx")]
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
        public IActionResult Create([FromBody] GruposXxx item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetGruposXxx", new { controller = "GruposXxx", id = item.CarreraId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
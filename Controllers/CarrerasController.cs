using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class CarrerasController : Controller
    {
        private IRepository<Carreras> _repo;
        
        public CarrerasController(IRepository<Carreras> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Carreras> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCarreras")]
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
        public IActionResult Create([FromBody] Carreras item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetCarreras", new { controller = "Carreras", id = item.CarreraId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
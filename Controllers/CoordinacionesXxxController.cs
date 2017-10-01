using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class CoordinacionesController : Controller
    {
        private IRepository<Coordinaciones> _repo;
        
        public CoordinacionesController(IRepository<Coordinaciones> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Coordinaciones> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCoordinaciones")]
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
        public IActionResult Create([FromBody] Coordinaciones item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetCoordinaciones", new { controller = "Coordinaciones", id = item.CarreraId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
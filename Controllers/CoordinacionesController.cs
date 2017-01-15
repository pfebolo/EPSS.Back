using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class CoordinacionesController : Controller
    {
        private ICoordinacionesRepository _repo;
        
        public CoordinacionesController(ICoordinacionesRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Coordinacion> GetAll()
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
        public IActionResult Create([FromBody] Coordinacion item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetCoordinaciones", new { controller = "Coordinaciones", PromocionId = item.PromocionId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
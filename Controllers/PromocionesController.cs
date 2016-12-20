using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class PromocionesController : Controller
    {
        private IPromocionesRepository _repo;
        
        public PromocionesController(IPromocionesRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Promociones> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetPromociones")]
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
        public IActionResult Create([FromBody] Promociones item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetPromociones", new { controller = "Promociones", PromocionId = item.PromocionId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using EPSS.Repositories;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class ProvinciasController : Controller
    {
        private IProvinciasRepository _repo;
        
        public ProvinciasController(IProvinciasRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Provincias> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetProvincias")]
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
        public IActionResult Create([FromBody] Provincias item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetProvincias", new { controller = "Provincias", ProvinciaId = item.ProvinciaId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repo.Remove(id);
        }
    }
}
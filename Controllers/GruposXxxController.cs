using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class GruposController : Controller
    {
        private IRepository<Grupos> _repo;
        
        public GruposController(IRepository<Grupos> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Grupos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetGrupos")]
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
        public IActionResult Create([FromBody] Grupos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetGrupos", new { controller = "Grupos", id = item.CarreraId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //_repo.Remove(id);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class ModosController : Controller
    {
        private IModosRepository _repo;

        public ModosController(IModosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Modos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetModos")]
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
        public IActionResult Create([FromBody] Modos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            
            var x = CreatedAtRoute("GetModos", new { controller = "Modos", id = "Nuevo" }, item);
            return x;
        }

        // PUT api/modos
        [HttpPut]
        public IActionResult Put([FromBody] Modos item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var Modo = _repo.Find(item.ModoId);


            if (Modo == null)
            {
                return NotFound();
            }

            _repo.Update(item);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repo.Remove(id);
        }
    }
}
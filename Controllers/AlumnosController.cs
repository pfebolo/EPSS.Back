using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class AlumnosController : Controller
    {
        private IAlumnosRepository _repo;
        
        public AlumnosController(IAlumnosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Alumnos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetAlumnos")]
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
        public IActionResult Create([FromBody] Alumnos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetAlumnos", new { controller = "Alumnos", AlumnoId = item.AlumnoId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
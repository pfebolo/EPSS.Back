using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.API.Models;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class AlumnoController : Controller
    {
        private IAlumnoRepository _repo;
        
        public AlumnoController(IAlumnoRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Alumno> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetAlumno")]
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
        public IActionResult Create([FromBody] Alumno item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetAlumno", new { controller = "Alumno", AlumnoId = item.id }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
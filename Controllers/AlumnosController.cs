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
            try
            {
                _repo.Add(item);
                return CreatedAtRoute("GetAlumnos", new { controller = "Alumnos", Id = item.AlumnoId }, item);
            }
            catch (System.Exception ex)
            {
                return Utils.ResponseInternalError(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Alumnos item )
        {
            if (item == null)
                return BadRequest();

            var Modo = _repo.Find(item.AlumnoId);

            if (Modo == null)
                return NoContent(); //Sin error por que DELETE es Idempotente.

            try
            {
                _repo.Remove(item);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return Utils.ResponseInternalError(ex);
            }


        }

        // PUT api/alumnos
        [HttpPut]
        public IActionResult Put([FromBody] Alumnos item)
        {
            if (item == null)
                return BadRequest();

            var Modo = _repo.Find(item.AlumnoId);

            if (Modo == null)
                return NotFound();

            _repo.Update(item);

            return NoContent();
        }


    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class InteresadosEventosController : Controller
    {
        private IInteresadosEventosRepository _repo;

        public InteresadosEventosController(IInteresadosEventosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new ObjectResult(_repo.GetAll());
            }
            catch (System.Exception ex)
            {
                return Utils.ResponseInternalError(ex);
            }
        }

        [HttpGet("{id}", Name = "GetInteresadosEventos")]
        public IActionResult GetById(int id)
        {
            var item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("eventos/{eventoId}", Name = "GetInteresadosEventosXEvento")]
        public IActionResult GetByEventoId(int eventoId)
        {
            var item = _repo.FindByEventoId(eventoId);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] InteresadosEventos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetInteresadosEventos", new { controller = "InteresadosEventos", InteresadoEventoId = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _repo.Find(id);
                if (item == null)
                {
                    return NoContent(); //Sin error por que DELETE es Idempotente.
                }
                _repo.Remove(item);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return Utils.ResponseInternalError(ex);
            }
        }
    }
}
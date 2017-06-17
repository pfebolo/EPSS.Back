using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private IEventosRepository _repo;
        
        public EventosController(IEventosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Eventos> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetEventos")]
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
        public IActionResult Create([FromBody] Eventos item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            try
            {
                _repo.Add(item);
                return CreatedAtRoute("GetEventos", new { controller = "Eventos", Id = item.Id }, item);
            }
            catch (System.Exception ex)
            {
                return Utils.ResponseInternalError(ex);
            }
        }

        // PUT api/Eventos
        [HttpPut]
        public IActionResult Put([FromBody] Eventos item)
        {
            if (item == null)
                return BadRequest();

            var Modo = _repo.Find(item.Id);

            if (Modo == null)
                return NotFound();
            try
            {
                _repo.Update(item);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return Utils.ResponseInternalError(ex);
            }

        }





        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
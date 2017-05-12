using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;


namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class InteresadosController : Controller
    {
        private IInteresadosRepository _repo;
        
        public InteresadosController(IInteresadosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet("{fechaFIN}", Name = "GetUltimosInteresados")]
        public IEnumerable<Interesados> GetAll(DateTime fechaFIN)
        {
            return _repo.GetAll(fechaFIN);
        }

        [HttpGet("{id}", Name = "GetInteresados")]
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
        public IActionResult Create([FromBody] Interesados item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetInteresados", new { controller = "Interesados", InteresadoId = item.InteresadoId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }

        // PUT api/Interesados
        [HttpPut]
        public IActionResult Put([FromBody] Interesados item)
        {
            if (item == null)
                return BadRequest();

            var Modo = _repo.Find(item.InteresadoId);

            if (Modo == null)
                return NotFound();

            _repo.Update(item);

            return NoContent();
        }


    }
}
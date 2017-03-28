using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.DTOs;
using EPSS.Repositories;
using System;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class InscriptosController : Controller
    {
        private IInscriptosRepository _repo;

        public InscriptosController(IInscriptosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Inscriptos> GetAll()
        {
            return _repo.GetAll();
        }


        // PUT api/Inscriptos
        [HttpPut]
        public IActionResult Put([FromBody] IEnumerable<Inscriptos> items)
        {
            if (items == null)
                return BadRequest();

            try
            {
                _repo.Update(items);
                Console.WriteLine("PUT Inscriptos");
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return Utils.ResponseConfict(ex);
            }
        }


    }
}
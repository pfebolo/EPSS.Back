using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class CodigosPostalesController : Controller
    {
        private ICodigosPostalesRepository _repo;
        
        public CodigosPostalesController(ICodigosPostalesRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<CodigosPostales> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCodigosPostales")]
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
        public IActionResult Create([FromBody] CodigosPostales item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetCodigosPostales", new { controller = "CodigosPostales", CodigoPostalId = item.CodigoPostalId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class CursosXxxController : Controller
    {
        private IRepository<CursosXxx> _repo;
        
        public CursosXxxController(IRepository<CursosXxx> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<CursosXxx> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCursosXxx")]
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
        public IActionResult Create([FromBody] CursosXxx item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetCursosXxx", new { controller = "CursosXxx", id = item.CarreraId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}
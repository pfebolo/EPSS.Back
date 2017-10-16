using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;

namespace EPSS.Controllers
{
	public class BaseController<Model> : Controller where Model : class
	{
		private IRepository<Model> _repo;

		public BaseController(IRepository<Model> repo)
		{
			this._repo = repo;
		}


		[HttpGet]
		public IEnumerable<Model> GetAll()
		{
			return _repo.GetAll();
		}

		[HttpGet("{id}", Name = "GetModel")]
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
		public IActionResult Create([FromBody] Model item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			_repo.Add(item);
			return CreatedAtRoute("GetModel", new { controller = "Model", id = 1 }, item);
		}

		//[HttpDelete("{id}")]
		public IActionResult Delete(params Object[] KeyValues)
		{
			try
			{
				var item = _repo.Find(KeyValues);
				if (item == null)
				{
					return NoContent(); //Sin error por que DELETE es Idempotente.
				}
				_repo.Remove(item); ;
				return NoContent();
			}
			catch (System.Exception ex)
			{
				return Utils.ResponseInternalError(ex);
			}
		}
	}
}
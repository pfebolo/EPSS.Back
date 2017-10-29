using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Controllers
{
	public class BaseController<Model> : Controller where Model : class
	{
		protected IRepository<Model> _repo;

		public BaseController(IRepository<Model> repo)
		{
			this._repo = repo;
		}


		[HttpGet]
		public IEnumerable<Model> GetAll()
		{
			return _repo.GetAll();
		}

		//[HttpGet("{id}", Name = "GetModel")]
		public IActionResult GetById(params Object[] KeyValues)
		{
			var item = _repo.Find(KeyValues);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public virtual IActionResult Create([FromBody] Model item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			_repo.Add(item);
			//TODO: Crear un resultado con la ruta (route path) generico
			//return CreatedAtRoute("GetModel", new { controller = "Model", id = 1 }, item);
			return Utils.ResponseCreated(); //No devuelve la ruta
		}

		[HttpPut]
		public virtual IActionResult Put([FromBody] Model item)
		{
			try
			{
				if (item == null)
					return BadRequest();

				_repo.Update(item);
				return NoContent();
			}
			catch (Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
			{
				return Utils.ResponseConfict(ex);
			}
			catch (Exception ex)
			{
				return Utils.ResponseInternalError(ex);
			}
		}



		//[HttpDelete]
		public virtual IActionResult Delete(params Object[] KeyValues)
		{
			try
			{
				_repo.Remove(KeyValues);
				return NoContent();
			}
			catch (Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
			{
				return Utils.ResponseConfict(ex);
			}
			catch (System.Exception ex)
			{
				return Utils.ResponseInternalError(ex);
			}			
		}
	}
}
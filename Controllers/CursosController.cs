using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Controllers
{
	[Route("api/[controller]")]
	public class CursosController : Controller
	{
		private IRepository<Cursos> _repo;

		public CursosController(IRepository<Cursos> repo)
		{
			this._repo = repo;
		}


		[HttpGet]
		public IEnumerable<Cursos> GetAll()
		{
			return _repo.GetAll();
		}

		[HttpGet("{id}", Name = "GetCursos")]
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
		public IActionResult Create([FromBody] Cursos item)
		{
			try
			{
				if (item == null)
					return BadRequest();
				_repo.Add(item);
				return CreatedAtRoute("GetEventos", new { controller = "Eventos", Id = item.CursoId }, item);
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

		// PUT api/Cursos
		[HttpPut]
		public IActionResult Put([FromBody] Cursos item)
		{
			try
			{
				if (item == null)
					return BadRequest();

				var curso = _repo.Find(item.CarreraId,item.ModoId,item.CursoId);

				if (curso == null)
					return NotFound();

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

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			//_repo.Remove(id);
		}
	}
}
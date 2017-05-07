using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface ICursosRepository
    {
        IEnumerable<Cursos> GetAll();
        Cursos Find(int id);
        void Add(Cursos item);
        void Remove(int id);
        Cursos FindActivebyEstudiante(int estudianteLegajo);


    }
    public class CursosRepository: BaseRepository,ICursosRepository
    {
        private List<Cursos> _list;

        public CursosRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Cursos>();
        }

        public void Add(Cursos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Cursos Find(int id)
        {
            // return _list.Find(n=>n.CursosId==id);
            return _list.Find(n => n.CursoId == id);
        }

        public IEnumerable<Cursos> GetAll()
        {
            _list.Clear();
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    foreach (var Curso in db.Cursos.Include(a => a.EstadoCurso))
                    {
                        _list.Add(Curso);
                    }
                    _logger.LogInformation("Buscar Cursos --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }

        #region Busquedas específicas
        public Cursos FindActivebyEstudiante(int estudianteLegajo)
        {
            Cursos CursoActivo=null;

            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    //Curso = db.Cursos.Include(a => a.Grupos).Where(b => b.Grupos.Contains(c => c.Legajo.LegajoNro==estudianteLegajo));
                    //Curso = CursoList.where(a => a.Legajo==estudianteLegajo);

                    var Curso = from Cur in db.Cursos
                            join Gru in db.Grupos
                            on new { P = Cur.PromocionId, C = Cur.CuatrimestreId, M = Cur.ModoId, T = Cur.TurnoId, D = Cur.CursoId }
                                        equals new { P = Gru.PromocionId, C = Gru.CuatrimestreId, M = Gru.ModoId, T = Gru.TurnoId, D = Gru.CursoId }
                            where Gru.Legajo.LegajoNro == estudianteLegajo
                            select Cur;

                    CursoActivo = Curso.Single();

                    _logger.LogInformation("Buscar Curso  Activo por Estudiante(" + estudianteLegajo.ToString() + ") --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }


            return CursoActivo;
        }

        #endregion
    }
}
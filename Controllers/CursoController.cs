using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;
using apiUniversidade.Context;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ILogger<CursoController> _Logger;

        private readonly apiUniversidadeContext _context;

        public CursoController(ILogger<CursoController> logger, apiUniversidadeContext context){
            _Logger = logger;
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Curso>> Get()
        {
            var cursos = _context.Cursos.ToList();
            if(cursos is null)
                return NotFound();
                
            return cursos;
        }

        [HttpGet("{id:int}", Name = "GetCurso")]

        public ActionResult<Curso> Get(int id)
        {
            var cursos = _context.Cursos.FirstOrDefault(p => p.ID == id);
            if(cursos is null)
                return NotFound("Curso não encontrado");
                
            return cursos;
        }

        [HttpPost]

        public ActionResult Post(Curso curso){
            _context.Cursos.Add(curso);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCurso",
                new{ id = curso.ID},
                curso);
        }
    }
}
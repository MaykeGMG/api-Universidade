using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Model;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly Ilogger<CursoController> _Logger;

        private readonly apiUniversidade _context;

        public CursoController(ILogger<CursoController> Logger, apiUniversidadeContext context){
            _Logger = logger;
            _context = context;
        }

        [HttpGet]

        public ActionResult<Enumerable<Curso>> Get()
        {
            var cursos = _context.Curso.ToList();
            if(cursos is null)
                return NotFound();
                
            return cursos;
        }
    }
}
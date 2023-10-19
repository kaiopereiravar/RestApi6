using Azure.Core;
using CriandoApi6.Application.aluno;
using CriandoApi6.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CriandoApi6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService service)
        {
            _alunoService = service;
        }

        [HttpGet]
        public IActionResult BuscarAlunos()
        {
            //var alunosService = new AlunosService(_context);
            var alunos = _alunoService.BuscarAlunos();
            if(alunos == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(alunos);
            }
        }

        [HttpPost]
        public IActionResult InserirAlunos([FromBody] AlunosRequest request)
        {
            //var alunosService = new AlunosService(_context);
            var alunos = _alunoService.InserirAlunos(request);
            if(alunos.status == false)
            {
                return BadRequest(alunos);
            }
            else
            {
                return Ok(alunos);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarAlunos([FromBody] AlunosRequest request, [FromRoute] int id)
        {
            //var alunosService = new AlunosService(_context);
            var alunos = _alunoService.AtualizarAlunos(request, id);
            if(alunos == false)
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarAlunos([FromRoute] int id)
        {
            //var alunosService = new AlunosService(_context);
            var alunos = _alunoService.DeletarAlunos(id);
            if(alunos == false)
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
        }
    }
}

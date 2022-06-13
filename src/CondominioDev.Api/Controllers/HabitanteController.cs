using CondominioDev.Core.Entities;
using CondominioDev.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondominioDev.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HabitanteController : ControllerBase
    {
        private readonly IHabitanteService _habitanteService;
        public HabitanteController(IHabitanteService habitanteService)
        {
            _habitanteService = habitanteService;
        }
        
        [HttpGet]
        public ActionResult<List<Habitante>> ObterTodosHabitantes()
        {
            var habitantes = _habitanteService.ObterTodosHabitantes();
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();

            return Ok(habitantes);
        }

        [HttpGet("/GetNome/{nome}")]
        public ActionResult<List<Habitante>> ObterHabitantePorNome(string nome)
        {
            var habitantes = _habitanteService.ObterHabitantePorNome(nome);
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();

            return Ok(habitantes);
        }

        [HttpGet("/GetId/{id}")]
        public ActionResult<Habitante> ObterHabitantePorId(int id)
        {
            var habitante = _habitanteService.ObterHabitantePorId(id);
            if (habitante == null)
                return NotFound();

            return Ok(habitante);
        }

        [HttpPost]
        public ActionResult<int> CadastrarHabitante(Habitante habitante)
        {
            var id = _habitanteService.CadastrarHabitante(habitante);
            if (id == -1)
                return Conflict();
            return CreatedAtAction(nameof(ObterHabitantePorId), new { Id = id }, id);
        }
        
        [HttpPut("{id}")]
        public ActionResult AtualizarUmHabitante(Habitante habitante, int id)
        {
            var habitanteOriginal = _habitanteService.ObterHabitantePorId(id);
            if (habitanteOriginal == null)
                return NotFound();
            _habitanteService.AtualizarHabitante(habitanteOriginal, habitante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarUmHabitante(int id)
        {
            var habitante = _habitanteService.ObterHabitantePorId(id);
            if (habitante == null)
                return NotFound();
            _habitanteService.DeletarHabitante(id);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeletarTodosHabitantes()
        {
            _habitanteService.DeletarTodosHabitantes();
            return NoContent();
        }

        [HttpGet("/GetMes/{mes}")]
        public ActionResult<List<Habitante>> ObterHabitantePorMesDeNascimento(int mes)
        {
            var habitantes = _habitanteService.ObterHabitantePorMesDeNascimento(mes);
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();

            return Ok(habitantes);
        }

        [HttpGet("/Idade/{idade}")]
        public ActionResult<List<Habitante>> ObterHabitanteComIdadeMaiorQue(int idade)
        {
            var habitantes = _habitanteService.ObterHabitanteComIdadeMaiorQue(idade);
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();

            return Ok(habitantes);
        }

        [HttpGet("/RendaTotal")]
        public ActionResult<decimal> ObterRendaTotal()
        {
            var habitantes = _habitanteService.ObterTodosHabitantes();
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();
            var rendaTotal = _habitanteService.ObterRendaTotal();
            return Ok(rendaTotal);
        }

        [HttpGet("/MaiorRenda")]
        public ActionResult<Habitante> ObterHabitanteComMaiorRenda()
        {
            var habitante = _habitanteService.ObterHabitanteComMaiorRenda();
            if (habitante == null)
                return NotFound();

            return Ok(habitante);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ms_filmes.Data;
using ms_filmes.Interfaces;
using ms_filmes.Model;
using ms_filmes.Model.Dto;

namespace ms_filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {

        private readonly IFilmes _interfaces;

        public FilmesController(IFilmes interfaces)
        {
            _interfaces = interfaces;
        }
        [HttpPost]
        public IActionResult CadastrarFilme([FromForm]AddFilmeDto dto)
        {
            var filme = _interfaces.CadastrarFilme(dto);
            if (filme != null)
            {
                return Ok(filme);
            }

            return BadRequest("Não foi possível cadastrar o Filme");

        }

        [HttpGet]
        public IActionResult BuscarFilmes()
        {
            IEnumerable<ReadFilmeDto> Filmes = _interfaces.BuscarTodos();
            if(Filmes == null){
                return NoContent();
            } 
            return Ok(Filmes);
        }

        [HttpGet("{id}")]

        public IActionResult BuscarFilmePorId(int id)
        {
            ReadFilmeDto dto = _interfaces.BuscarPorId(id);
            if(dto == null){
                return BadRequest("Não foi possível encontrar o filme com id" + id);
            }
            return Ok(dto);
        }

        [HttpPut("{id}")]

        public IActionResult AtualizarFilme(int id,[FromForm] UpdateFilmeDto dto )
        {
            ReadFilmeDto readDto = _interfaces.Editar(id, dto);
            if(dto == null){
                return BadRequest("Não foi possível editar o filme com id" + id);
            }
            return Ok(dto);
        }

        [HttpDelete("{id}")]

        public IActionResult DeletarFilme(int id)
        {
            bool deletado = _interfaces.excluir(id);
            if(deletado == true){
                return Ok();
            }
            return BadRequest("Não foi possível excluir o filme com id" + id);
           
        }
    }
}
    

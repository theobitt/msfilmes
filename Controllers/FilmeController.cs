using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ms_filmes.Data;
using ms_filmes.Model;
using ms_filmes.Model.Dto;

namespace ms_filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetById(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> Get()
        {
            return await _context.Filmes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Add([FromForm] AddFilmeDto addFilmeDto)
        {
            var filme = new Filme
            {
                Titulo = addFilmeDto.Titulo,
                Genero = addFilmeDto.Genero,
                DataLancamento = addFilmeDto.DataLancamento
            };

            if (addFilmeDto.Imagem != null)
            {
                filme.Imagem = new byte[addFilmeDto.Imagem.Length];

                using (var stream = addFilmeDto.Imagem.OpenReadStream())
                {
                    await stream.ReadAsync(filme.Imagem);
                }
            }

            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

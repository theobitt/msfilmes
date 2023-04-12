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
        public IActionResult CadastrarFilme(AddFilmeDto dto, IFormFile imageFile)
        {
            var filme = _interfaces.CadastrarFilme(dto, imageFile);
            if (filme != null)
            {
                return Ok(filme);
            }

            return BadRequest("Não foi possível cadastrar o Filme");

        }

         [HttpPost("/imagem")]
        public IActionResult UploadImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    imageFile.CopyTo(stream);
                    byte[] imageBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return Ok(new { base64Image = base64String });
                }
            }
            else
            {
                return BadRequest("No image file provided.");
            }
        }
    }
}
    

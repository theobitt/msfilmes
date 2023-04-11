using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace ms_filmes.Model.Dto
{
    public class UpdateFilmeDto
    {

        public string Titulo { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Genero { get; set; }
        
        public IFormFile Imagem { get; set; }

    }
}
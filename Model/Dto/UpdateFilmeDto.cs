using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ms_filmes.Model.Dto
{
    public class UpdateFilmeDto
    {
        // [Required]
        public string Titulo { get; set; } = null!;

        // [Required]
        public DateTime? DataLancamento { get; set; } = null!;

        // [Required]
        public string Genero { get; set; }  = null!;
        
        // [BindNever]
        public byte[] Imagem { get; set; }

    }
}
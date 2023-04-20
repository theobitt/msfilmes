using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ms_filmes.Model.Dto
{
    public class AddFilmeDto
    {

        public string Titulo { get; set; } = null!;

        public DateTime? DataLancamento { get; set; } = null!;

        public string Genero { get; set; } = null!;
        
        //  [BindNever]
        public IFormFile ImagemData { get; set; } // Added property for image data

        

    }
}
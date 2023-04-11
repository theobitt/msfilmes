using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms_filmes.Model.Dto;

namespace ms_filmes.Interfaces
{
    public interface IFilmes : IBaseInt<AddFilmeDto, ReadFilmeDto>, IUpdate<UpdateFilmeDto, ReadFilmeDto>
    {
        
    }
}
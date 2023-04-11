using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ms_filmes.Model;
using ms_filmes.Model.Dto;

namespace ms_filmes.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile(){
            CreateMap<AddFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
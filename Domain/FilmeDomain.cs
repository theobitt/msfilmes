using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ms_filmes.Data;
using ms_filmes.Interfaces;
using ms_filmes.Model;
using ms_filmes.Model.Dto;

namespace ms_filmes.Domain
{
    public class FilmeDomain : IFilmes
    {

        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public FilmeDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public ReadFilmeDto Adicionar(AddFilmeDto dto)
        {
            Filme filme = _mapper.Map<Filme>(dto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return filmeDto;
        }

        public ReadFilmeDto BuscarPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            ReadFilmeDto readDto = _mapper.Map<ReadFilmeDto>(filme);
            return readDto;
        }

        public IEnumerable<ReadFilmeDto> BuscarTodos()
        {
            var listaFilmes = _context.Filmes.ToList();
            IEnumerable<ReadFilmeDto> readFilmeDtos = _mapper.Map<List<ReadFilmeDto>>(listaFilmes);
            return readFilmeDtos;
        }

        public ReadFilmeDto Editar(int id, UpdateFilmeDto dto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                _mapper.Map(dto, filme);
                ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
                _context.SaveChanges();
                return readFilmeDto;
            }
            return null;
        }

        public bool excluir(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ReadFilmeDto CadastrarFilme(AddFilmeDto dto, IFormFile imageFile)
        {
            ReadFilmeDto? Adicionado = null; 
            if (imageFile != null && imageFile.Length > 0 && dto != null)
            {
                using (var stream = new MemoryStream())
                {
                    imageFile.CopyTo(stream);
                    byte[] imageBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    dto.ImagemData = base64String;
                    Adicionado = Adicionar(dto); 
                }
            }
                    return Adicionado;
        }
    }
}

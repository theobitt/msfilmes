using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_filmes.Interfaces
{
    public interface IBaseInt<in T, out A>
    {
        A Adicionar(T obj);
        IEnumerable<A>BuscarTodos();
        A BuscarPorId(int id);

        bool excluir(int id);
 
    }
}
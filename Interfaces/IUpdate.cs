using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_filmes.Interfaces
{
    public interface IUpdate<in T, out A>
    {
      A Editar(int id, T obj);

      
    }
}
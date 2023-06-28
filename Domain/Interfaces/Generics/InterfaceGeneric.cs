using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    //Onde o T é qualquer classe
    public interface InterfaceGeneric<T> where T : class 
    {
        //Metodos
        Task Add(T Objeto);
        Task Update(T Objeto);
        Task Delete(T Objeto);
        Task<T> GetEntityById(int id);
        Task<List<T>> List();
    }
}

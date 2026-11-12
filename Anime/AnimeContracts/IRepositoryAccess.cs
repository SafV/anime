using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeContracts
{
    public interface IRepositoryAccess<T>
    {
        void Add(T item);
        void Delete(int id);
        List<T> ReadAll();
        T ReadById(int id);
        void Update(T item);
    }
}

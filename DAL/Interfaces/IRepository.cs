using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Create(T obj);
        public void Update(T obj);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Delete(T obj);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class 
    {
        public Task<List<TEntity>> GetAll();
        public TEntity GetById(int id);
        public Task<bool> Add(TEntity entity);
        public bool Remove(TEntity entity);
        public bool Update(TEntity entity);
    }
}

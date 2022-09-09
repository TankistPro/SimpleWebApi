using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private DataBaseContext _context;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        } 

        public bool Add(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<TEntity>> GetAll()
        {
            try
            {
                var entity =_dbSet.ToListAsync();
                return entity;
            } 
            catch
            {
                return null;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

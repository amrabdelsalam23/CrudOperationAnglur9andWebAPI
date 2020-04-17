using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using DALInvemtory.Models;

namespace Dsmart.Repository.Sql
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        
        private InventoryDBContext _context = null;
        protected DbSet<TEntity> _dbSet;
        public BaseRepository(InventoryDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public BaseRepository()
        {
            _context = new InventorydbContext();
            _dbSet = _context.Set<TEntity>();
        }
      

        //--------------------------------------
        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<TEntity> GetByAll()
        {
            return _dbSet.ToList<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);//.Entity;  //on .net core change 
            //EntityEntry < TEntity >
            //return _dbSet.Add(entity);
        }
        //public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entity)
        //{
        //    return _dbSet.AddRange(entity);
        //}
        public TEntity Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }
        public void RemoveById(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }
        public void Remove(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            _dbSet.RemoveRange(entity);
        }
      
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

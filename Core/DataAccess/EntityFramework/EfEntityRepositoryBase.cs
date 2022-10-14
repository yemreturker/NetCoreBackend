using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext _dbcontext = new TContext())
            {
                var addedEntity = _dbcontext.Entry(entity);
                addedEntity.State = EntityState.Added;
                _dbcontext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext _dbcontext = new TContext())
            {
                var deletedEntity = _dbcontext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _dbcontext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext _dbcontext = new TContext())
            {
                return _dbcontext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext _dbcontext = new TContext())
            {
                return filter == null
                    ? _dbcontext.Set<TEntity>().ToList()
                    : _dbcontext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext _dbcontext = new TContext())
            {
                var updatedEntity = _dbcontext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _dbcontext.SaveChanges();
            }
        }
    }
}
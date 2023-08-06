using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Data.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly BuildingDbContext _dbContext;
        public GenericRepository(BuildingDbContext dbContext) 
        { 
            this._dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Delete(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _dbContext.Set<Entity>().Find(id);
            Delete(entity);
        }

        public List<Entity> GetAll()
        {
            return _dbContext.Set<Entity>().AsNoTracking().ToList();
        }

        public IQueryable<Entity> GetAllAsQueryable()
        {
            return _dbContext.Set<Entity>().AsQueryable();
        }

        public List<Entity> GetAllWithInclude(params string[] includes)
        {
            var q = _dbContext.Set<Entity>().AsQueryable();
            q = includes.Aggregate(q, (current, inc) => current.Include(inc));
            return q.ToList();
        }

        public Entity GetByID(int id)
        {
            var entity = _dbContext.Set<Entity>().Find(id);
            return entity;
        }

        public Entity GetByIdWithInclude(int id, params string[] includes)
        {
            var q = _dbContext.Set<Entity>().AsQueryable();
            q = includes.Aggregate(q,(current,inc) => current.Include(inc));
            return q.FirstOrDefault();
        }

        public void Insert(Entity entity)
        {
            _dbContext.Set<Entity>().Add(entity);
        }

       
        public void Update(Entity entity)
        {
            _dbContext.Set<Entity>().Update(entity);
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression)
        {
           return _dbContext.Set<Entity>().Where(expression).AsQueryable();
        }

        public IEnumerable<Entity> WhereWithInclude(Expression<Func<Entity, bool>> expression, params string[] includes)
        {
            var q = _dbContext.Set<Entity>().AsQueryable();
            q.Where(expression);
            q=includes.Aggregate(q,(current,inc) => current.Include(inc));
            return q.ToList();
        }
    }
}

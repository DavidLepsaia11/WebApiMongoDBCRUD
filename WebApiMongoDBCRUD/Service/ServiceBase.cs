using System.Linq.Expressions;
using WebApiMongoDBCRUD.Models;
using WebApiMongoDBCRUD.Repository;

namespace WebApiMongoDBCRUD.Service
{
    public class ServiceBase<TEntity, TRepository> : IQueryService<TEntity>, ICommandService<TEntity>
        where TEntity : IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public TEntity Create(TEntity entity)
        {
            return _repository.Create(entity);
        }

        public ICollection<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Filter(predicate);
        }

        public ICollection<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(string id)
        {
            return _repository.GetById(id);    
        }

        public void Remove(string id)
        {
            _repository.Remove(id);
        }

        public void Update(string id, TEntity entity)
        {
            _repository.Update(id, entity);
        }
    }
}

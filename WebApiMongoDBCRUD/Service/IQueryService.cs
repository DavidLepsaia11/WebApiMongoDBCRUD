using System.Linq.Expressions;

namespace WebApiMongoDBCRUD.Service
{
    public interface IQueryService<TEntity>
    {
        ICollection<TEntity> GetAll();
        ICollection<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(string id);
    }
}

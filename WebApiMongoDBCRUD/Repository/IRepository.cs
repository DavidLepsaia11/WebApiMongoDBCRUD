using System.Linq.Expressions;
using WebApiMongoDBCRUD.Models;

namespace WebApiMongoDBCRUD.Repository
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        ICollection<TEntity> GetAll();
        ICollection<TEntity> Filter(Expression<Func<TEntity ,bool>> predicate);
        TEntity GetById(string id);
        TEntity Create(TEntity student);
        void Update(string id, TEntity student);
        void Remove(string id);
    }
}

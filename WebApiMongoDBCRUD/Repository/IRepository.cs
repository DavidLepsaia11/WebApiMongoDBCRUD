using WebApiMongoDBCRUD.Models;

namespace WebApiMongoDBCRUD.Repository
{
    public interface IRepository<T>
        where T : IEntity
    {
        IList<T> GetAll();
        T GetById(string id);
        T Create(T student);
        void Update(string id, T student);
        void Remove(string id);
    }
}

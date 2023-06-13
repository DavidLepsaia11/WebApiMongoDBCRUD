using WebApiMongoDBCRUD.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace WebApiMongoDBCRUD.Repository
{
    public class Repository<T> : IRepository<T>
        where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;

        private string CollectionName => $"{typeof(T).Name.ToLower()}s";

        public Repository(IDatabaseSettings databaseSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            var raime = typeof(T).Name.ToLower();
            _collection = database.GetCollection<T>(CollectionName);
        }

        public T Create(T entity)
        {
            _collection.InsertOne(entity);
            return entity;  
        }

        public ICollection<T> GetAll()
        {
           return  _collection.Find(entities => true).ToList();
        }

        public T GetById(string id)
        {
            return _collection.Find(entity => entity.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(id);
        }

        public void Update(string id, T entity)
        {
            _collection.ReplaceOne(entity => entity.Id == id , entity);
        }

        public ICollection<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _collection.Find(predicate).ToList();
        }
    }
}

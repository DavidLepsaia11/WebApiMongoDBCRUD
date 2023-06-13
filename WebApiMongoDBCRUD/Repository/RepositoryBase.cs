using WebApiMongoDBCRUD.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace WebApiMongoDBCRUD.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        private string CollectionName => $"{typeof(TEntity).Name.ToLower()}s";

        public RepositoryBase(IDatabaseSettings databaseSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            var raime = typeof(TEntity).Name.ToLower();
            _collection = database.GetCollection<TEntity>(CollectionName);
        }

        public TEntity Create(TEntity entity)
        {
            _collection.InsertOne(entity);
            return entity;  
        }

        public ICollection<TEntity> GetAll()
        {
           return  _collection.Find(entities => true).ToList();
        }

        public TEntity GetById(string id)
        {
            return _collection.Find(entity => entity.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(id);
        }

        public void Update(string id, TEntity entity)
        {
            _collection.ReplaceOne(entity => entity.Id == id , entity);
        }

        public ICollection<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToList();
        }
    }
}

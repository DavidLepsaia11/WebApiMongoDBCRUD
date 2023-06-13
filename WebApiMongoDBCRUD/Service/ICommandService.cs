namespace WebApiMongoDBCRUD.Service
{
    public interface ICommandService<TEntity>
    {
        TEntity Create(TEntity entity);
        void Update(string id, TEntity entity);
        void Remove(string id);
    }
}

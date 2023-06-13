namespace WebApiMongoDBCRUD.Service
{
    public interface ICommandService<TEntity>
    {
        TEntity Create(TEntity student);
        void Update(string id, TEntity student);
        void Remove(string id);
    }
}

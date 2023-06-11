namespace WebApiMongoDBCRUD.Models
{
    public interface IDatabaseSettings
    {
        public string StudentCollectionName { get; set; }

        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }

    }
}

using MongoDB.Driver;
using WebApiMongoDBCRUD.Models;

namespace WebApiMongoDBCRUD.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IDatabaseSettings databaseSettings, IMongoClient mongoClient) : base(databaseSettings, mongoClient)
        {
        }
    }
}

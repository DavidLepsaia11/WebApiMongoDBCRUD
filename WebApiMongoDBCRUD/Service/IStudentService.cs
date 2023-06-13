using WebApiMongoDBCRUD.Models;

namespace WebApiMongoDBCRUD.Service
{
    public interface IStudentService : ICommandService<Student>, IQueryService<Student>
    {

    }
}

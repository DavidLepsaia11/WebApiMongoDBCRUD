using WebApiMongoDBCRUD.Models;
using WebApiMongoDBCRUD.Repository;

namespace WebApiMongoDBCRUD.Service
{
    public class StudentService : ServiceBase<Student, IStudentRepository>, IStudentService
    {
        public StudentService(IStudentRepository repository) : base(repository)
        {

        }
    }
}

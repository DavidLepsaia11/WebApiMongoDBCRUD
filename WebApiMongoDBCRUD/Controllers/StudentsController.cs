using Microsoft.AspNetCore.Mvc;
using WebApiMongoDBCRUD.Models;
using WebApiMongoDBCRUD.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiMongoDBCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _repository;

        public StudentsController(IRepository<Student> repository)
        {
            _repository = repository;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _repository.GetById(id);

            if (student == null) return NotFound($"Such student , with id = {id} not found");

            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student>  Post([FromBody] Student student)
        {
             _repository.Create(student);
             return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = _repository.GetById(id);
            if (existingStudent == null) return NotFound($"Such student , with id = {id} not found");

            _repository.Update(id, student);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStudent = _repository.GetById(id);
            if (existingStudent == null) return NotFound($"Such student , with id = {id} not found");

            _repository.Remove(id);

            return Ok($"Student with id - {id} Deleted");
        }
    }
}

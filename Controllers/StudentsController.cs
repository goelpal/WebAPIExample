using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIExample.Models;

namespace WebAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        /*
        [HttpGet]
        public string Get()
        {
            return "test";
        }
        */

        static List<Student> students = new List<Student>()
            {
            new Student{ Id = 1, Name= "John"},
            new Student{ Id = 2, Name = "Jack" },
            new Student { Id = 3, Name = "Lara" }
            };

        [HttpGet("GetAllStudents")]
        public List<Student> Get()
        {
            /*var students = new List<Student>();
            students.Add(new Student{ Id = 1, Name= "John"});
            students.Add(new Student{ Id = 2, Name = "Jack" });
            students.Add(new Student { Id = 3, Name = "Lara" });*/
            return students;
        }

        [HttpGet("GetStudent/{id}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost("CreateStudent")]
        public Student Post(Student student) 
        {
            students.Add(student);
            return student;
        }

        [HttpDelete("DeleteStudent")]
        public List<Student> Delete(int id)
        {
            var Student = students.FirstOrDefault(s => s.Id == id);
            students.Remove(Student); 
            return students;
        }


        [HttpDelete("DeleteStudentt")]
        public IActionResult Delete1(int id)
        {
            var Student = students.FirstOrDefault(s => s.Id == id);
            students.Remove(Student);
            return Ok(students);
        }

        [HttpPut("UpdateStudents")]
        public List<Student> Update(Student request)
        {
            var student = students.Find(s => s.Id == request.Id);
            //student.Id = request.Id;
            student.Name = request.Name;
            return students;
        }

        [HttpPut]
        [Route("UpdateStudentts")]
        public IActionResult Updatte(Student request)
        {
            var student = students.Find(s => s.Id == request.Id);
            student.Id = request.Id;
            student.Name = request.Name;
            return Ok(students);
        }

    }
}

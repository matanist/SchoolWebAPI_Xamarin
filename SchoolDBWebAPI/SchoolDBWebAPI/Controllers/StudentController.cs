using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolDBData.Models;

namespace SchoolDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly SchoolDBContext _context;
        public StudentController(SchoolDBContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Student.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _context.Student.FirstOrDefault(s => s.Id == id);
        }

        // POST api/values
        [HttpPost]
        public Student Post([FromBody]Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
            return student;
        }

        // PUT api/values/5
        [HttpPut]
        public Student Put([FromBody]Student student)
        {
            _context.Student.Update(student);
            _context.SaveChanges();
            return student;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleted = _context.Student.FirstOrDefault(s => s.Id == id);
            _context.Student.Remove(deleted);
            _context.SaveChanges();
        }
    }
}
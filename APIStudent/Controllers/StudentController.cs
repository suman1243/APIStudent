using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIStudent.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var list = _context.Students.ToList();
            return Ok(list);
        }
       

    }
}

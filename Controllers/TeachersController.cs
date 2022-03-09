using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myAPI.teacher;

namespace myAPI.Controllers
{
    [Route("getTeachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        [HttpGet("getAllTeachers")]
        public List<Teacher> GetAllTeachers()
        {
            var t = new Teacher();
            return t.GetAllTeachers();
        }

        [HttpPost("addTeacher")]
        public void addTeacher(Teacher t)
        {
            t.addTeacher(t);
        }
    }
}

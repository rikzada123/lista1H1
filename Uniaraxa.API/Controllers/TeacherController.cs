using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Domain.Entities;
using Uniaraxa.Service.Services;

namespace Uniaraxa.API.Controllers
{
    public class TeacherController: ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
            
        }


        [HttpGet]
        [Route("api/teacher")]
        public IActionResult GetAllTeachers()
        {
            var teachers = _teacherService.GetAllTeachers();
            if(teachers is null || !teachers.Any())
            {
                return NotFound("No teachers found.");
            }
            return Ok(teachers);
        }

        [HttpGet]
        [Route("api/teacher/{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if(teacher is null)
            {
                return NotFound("Teacher not found.");
            }
            return Ok(teacher);
        }

        [HttpPost]
        [Route("api/teacher")]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            _teacherService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }
            , teacher);
        }

        [HttpPut]
        [Route("api/teacher")]
        public IActionResult UpdateTeacher([FromBody] Teacher teacher)
        {
            _teacherService.UpdateTeacher(teacher);
            return Ok(teacher);
        }

        [HttpDelete]
        [Route("api/teacher/{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            _teacherService.DeleteTeacher(id);
            return NoContent();
        }

    }
}

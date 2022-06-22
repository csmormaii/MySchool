using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.Models;
using MySchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TeachersController : ControllerBase
    {
        private ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Teacher>>> GetTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetTeachers();
                return Ok(teachers);
            }
            catch
            {
                //return BadRequest("Request invalido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting teachers");
            }
        }

        [HttpGet("TeachersByName")]
        public async Task<ActionResult<IAsyncEnumerable<Teacher>>> GetTeachersByName([FromQuery] string nome)
        {
            try
            {
                var teachers = await _teacherService.GetTeachersByName(nome);
                return Ok(teachers);
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }

        [HttpGet("{id:int}", Name="GetTeacher")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            try
            {
                var teachers = await _teacherService.GetTeacher(id);
                if (teachers == null)
                    return NotFound($"There is no teacher with id = {id}");
                return Ok(teachers);
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Teacher teacher)
        {
            try
            {
                await _teacherService.CreateTeacher(teacher);
                return CreatedAtRoute(nameof(GetTeacher), new { id = teacher.IdTeacher }, teacher);
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Teacher teacher)
        {
            try
            {
                if(teacher.IdTeacher == id)
                {
                    await _teacherService.UpdateTeacher(teacher);
                    return Ok($"Teacher with id = {id} has been successfully updated.");
                }
                else
                {
                    return BadRequest("Inconsistent data");
                }
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var teacher = await _teacherService.GetTeacher(id);
                if (teacher != null)
                {
                    await _teacherService.DeleteTeacher(teacher);
                    return Ok($"Teacher Id = {id} was successfully deleted.");
                }
                else
                {
                    return NotFound($"Teacher with Id = {id} not found");
                }
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }
    }
}

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
    public class CoursesController : ControllerBase
    {
        private ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Course>>> GetCourses()
        {
            try
            {
                var courses = await _courseService.GetCourses();
                return Ok(courses);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting courses");
            }
        }

        [HttpGet("{id:int}", Name= "GetCourse")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            try
            {
                var courses = await _courseService.GetCourse(id);
                if (courses == null)
                    return NotFound($"There is no course with id = {id}");
                return Ok(courses);
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Course course)
        {
            try
            {
                await _courseService.CreateCourse(course);
                return CreatedAtRoute(nameof(GetCourse), new { id = course.IdCourse }, course);
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Course course)
        {
            try
            {
                if(course.IdCourse == id)
                {
                    await _courseService.UpdateCourse(course);
                    return Ok($"Course with id = {id} has been successfully updated.");
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
                var course = await _courseService.GetCourse(id);
                if (course != null)
                {
                    await _courseService.DeleteCourse(course);
                    return Ok($"Course Id = {id} was successfully deleted.");
                }
                else
                {
                    return NotFound($"Course with Id = {id} not found");
                }
            }
            catch
            {
                return BadRequest("Request invalid");
            }
        }
    }
}

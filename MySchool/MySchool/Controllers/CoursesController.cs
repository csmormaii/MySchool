using Microsoft.AspNetCore.Mvc;
using MySchool.Services;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySchool.Api;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySchool.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly SchoolServices service;

        public CoursesController(SchoolServices service)
        {
            this.service = service;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var model = service.GetCourses();
            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{id}", Name = "GetCourse")]
        public IActionResult Get(int id)
        {
            var model = service.GetCourse(id);
            if(model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        private object ToOutputModel(Teacher model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create([FromBody]CourseInputModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();
            var model = ToDomainModel(inputModel);
            service.AddCourse(model);
            var outputModel = ToOutputModel(model);
            return CreatedAtRoute("GetCourse", new { id = outputModel.Id }, outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CourseInputModel inputModel)
        {
            if (inputModel == null || id != inputModel.Id)
                return BadRequest();
            if (!service.CourseExists(id))
                return NotFound();
            var model = ToDomainModel(inputModel);
            service.UpdateCourse(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.CourseExists(id))
                return NotFound();
            service.DeleteCourse(id);
            return NoContent();
        }

        private CourseOutputModel ToOutputModel(Course model)
        {
            return new CourseOutputModel
            {
                Id = model.id,
                Registration = model.registration,
                Course = model.course,
                Classes = model.classes,
                Horary = model.horary
            };
        }
        private List<CourseOutputModel> ToOutputModel(List<Course> model)
        {
            return model.Select(item => ToOutputModel(item)).ToList();
        }
        private Course ToDomainModel(CourseInputModel inputModel)
        {
            return new Course
            {
                //Id = inputModel.id,
                Registration = inputModel.registration,
                Course = inputModel.course,
                Classes = inputModel.classes,
                Horary = inputModel.horary
            };
        }
        private CourseInputModel ToInputModel(Course model)
        {
            return new CourseInputModel
            {
                //Id = model.id,
                Registration = model.registration,
                Course = model.course,
                Classes = model.classes,
                Horary = model.horary
            };
        }
    }
}

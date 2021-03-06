using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevOps.Data;
using DevOps.Models;
using DevOps.Services.CoursesManagement;
using DevOps.ViewModels.Courses;

namespace DevOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesServices _courses;
        public CoursesController(CoursesServices courses)
        {
            _courses = courses; 
        }

        // GET: Courses
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _courses.GetALllCourses());
        }

        // GET: Courses/Details/5
        [HttpGet("details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _courses.GetSpecificCourses(id.Value);

            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }


        // POST: Courses/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CreateCourseViewModel courses)
        {
            if (!ModelState.IsValid)
                return Ok(courses);

            var result = await _courses.CreateCourse(courses);

            if (result == null)
            {
                return BadRequest(courses);
            }

            return Ok(courses);
        }


        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return NotFound();
            
            var cours = await _courses.GetSpecificCourses(id.Value);

            if (cours is null)
                return NotFound();

            var model = new EditCourseViewModel()
            {
                Id = cours.Id,
                Detatils = cours.Detatils,
                OldImage = cours.ImageName,
                Name = cours.Name,
                Title   = cours.Title,
            };

            return Ok(model);
        }

        // POST: Courses/Edit/{id}
        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCourseViewModel courses)
        {
            if (id != courses.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(courses);

           var model =  await _courses.EditCourse(courses);

            if(model is null ) return BadRequest(model);

            return RedirectToAction(nameof(Index));
        }


        // POST: Courses/Delete/5
        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucess = await _courses.DeleteCourse(id);

            if (!sucess)
                return NotFound(id);

            return Ok();
        }


    }
}

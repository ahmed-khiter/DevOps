using DevOps.Data;
using DevOps.Helper;
using DevOps.ViewModels.Courses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps.Services.CoursesManagement
{
    public class CoursesServices
    {
        private readonly AppDbContext _context;
        private readonly FileManager _fileManager;
        public CoursesServices(AppDbContext context, FileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<List<Models.Courses>> GetALllCourses()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses;
        }

        public async Task<Models.Courses> GetSpecificCourses(int id)
        {
            var courses = await _context.Courses.Where(m => m.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if(courses == null)
                return null;
            
            return courses;
        }

        public async Task<Models.Courses> CreateCourse(CreateCourseViewModel model)
        {
            string imageName = "";

            if(model.Image != null)
            {
                imageName = _fileManager.Upload(model.Image);
            }

            var course = new Models.Courses()
            {
                Detatils = model.Detatils,
                ImageName = imageName,
                Name = model.Name,
                Title = model.Title,
            };

            _context.Add(course);
            try
            {
                await _context.SaveChangesAsync();

                return course;

            }
            catch 
            {
                return null;
            }

        }

        public async Task<EditCourseViewModel> EditCourse(EditCourseViewModel model)
        {
            var getCourse = await GetSpecificCourses(model.Id);

            if (getCourse == null) return null;

            string imageName = getCourse.ImageName;

            if(model.Image !=null)
            {
                _fileManager.Delete(imageName);
                imageName = _fileManager.Upload(model.Image);

            }

            getCourse.Detatils = model.Detatils;
            getCourse.ImageName = imageName;
            getCourse.Name = model.Name;
            getCourse.Title = model.Title;

            _context.Update(getCourse);

            try
            {
                await _context.SaveChangesAsync();

                model.OldImage = imageName;

                return model;
            }
            catch
            {

                return null;
            }



        }    
   
    
    
        public async Task<bool> DeleteCourse(int id)
        {
            var courses = await _context.Courses.FindAsync(id); 
                if (courses == null) return false;

            _context.Courses.Remove(courses);

            try
            {
                await _context.SaveChangesAsync();
                return true;

            }
            catch 
            {
                return false;
            }
            
        }

    }
}

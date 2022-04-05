using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DevOps.ViewModels.Courses
{
    public class CreateCourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Detatils { get; set; }
        
        [Required]
        public IFormFile Image { get; set; }

    }
}

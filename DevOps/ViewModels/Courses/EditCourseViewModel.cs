using Microsoft.AspNetCore.Http;

namespace DevOps.ViewModels.Courses
{
    public class EditCourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Detatils { get; set; }

        public string OldImage { get; set; }
        public IFormFile Image { get; set; }
    }
}

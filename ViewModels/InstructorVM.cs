using ITIFullProject.Models;

namespace ITIFullProject.ViewModels
{
    public class InstructorVM
    {
        public string Name { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public List<int> coursesid { get; set; } = new List<int>();
        public int DeptId { get; set; }
        public List<Department> DeptList { get; set; } = new List<Department>();
        public List<Course> CoursesList { get; set; } = new List<Course>();
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ITIFullProject.Models
{
	public class Instructor
	{
		public int Id { get; set; }
		public string Name { get; set; }=string.Empty;
		public string Image { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

		public Account Account { get; set; }

		public int DeptId { get; set; }
		public Department Department { get; set; }
		public List<CourseInstructor> CoursesInstructors {  get; set; }


	}
}

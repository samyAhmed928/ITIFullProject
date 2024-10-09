namespace ITIFullProject.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public float Degree { get; set; }
		public float MinDegree { get; set; }

		public int DeptId { get; set; }
		public Department Department { get; set; }
		public List<CourseResult>CourseResults { get; set; }
		public List<CourseInstructor> CourseInstructors { get; set; }
	}
}

namespace ITIFullProject.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string MangerName { get; set; } = string.Empty;
		public List<Instructor> Instructors { get; set; }
		public List<Trainee> Trainees { get; set; }
		public List<Course> Courses { get; set; }

	}
}

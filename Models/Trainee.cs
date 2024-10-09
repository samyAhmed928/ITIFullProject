namespace ITIFullProject.Models
{
	public class Trainee
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public int Grade {  get; set; }

		public int DeptId {  get; set; }
		public Department Department { get; set; }
		public List<CourseResult> CourseResults { get; set; }

	}
}

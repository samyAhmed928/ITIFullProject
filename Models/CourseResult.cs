namespace ITIFullProject.Models
{
	public class CourseResult
	{
		public int CourseId { get; set; }
		public Course Course { get; set; }
		public int TraineeId { get; set; }
		public Trainee Trainee { get; set; }
		public float Degree { get; set; }

	}
}

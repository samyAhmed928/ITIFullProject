namespace ITIFullProject.Models
{
	public class Account
	{
        public int Id { get; set; }
		public string UserName { get; set; }=string.Empty;
		public string Password { get; set; } = string.Empty;

		public int InstructorId { get; set; }
		public Instructor Instructor { get; set;}
    }
}

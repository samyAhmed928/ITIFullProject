using Microsoft.EntityFrameworkCore;
using ITIFullProject.Models;
namespace ITIFullProject.Data
{
	public class AppDbContext:DbContext
	{
        public DbSet<Department> Departments { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Account> Accounts { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CoursesResults { get; set; }
        public DbSet<CourseInstructor> CoursesInstructors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\LocalDBDemo;Initial Catalog=ITIFullProject;Integrated Security=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}

using ITIFullProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITIFullProject.Data.Configs
{
	public class CourseInstructorConfig : IEntityTypeConfiguration<CourseInstructor>
	{
		public void Configure(EntityTypeBuilder<CourseInstructor> builder)
		{
			builder.HasKey(ci => new { ci.CourseId ,ci.InstructorId});

			builder.HasOne(ci => ci.Course)
				.WithMany(c => c.CourseInstructors)
				.HasForeignKey(ci => ci.CourseId)
				.OnDelete(DeleteBehavior.Restrict);


			builder.HasOne(ci => ci.Instructor)
				.WithMany(i => i.CoursesInstructors)
				.HasForeignKey(ci => ci.InstructorId)
				.OnDelete(DeleteBehavior.Restrict);


		}
	}
}

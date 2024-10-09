using ITIFullProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITIFullProject.Data.Configs
{
	public class CourseResultConfig : IEntityTypeConfiguration<CourseResult>
	{
		public void Configure(EntityTypeBuilder<CourseResult> builder)
		{
			builder.Property(cr => cr.Degree).IsRequired().HasColumnType("decimal(3,2)");

			builder.HasKey(cr => new {cr.TraineeId, cr.CourseId});

			builder.HasOne<Trainee>(cr => cr.Trainee)
				.WithMany(t => t.CourseResults)
				.HasForeignKey(cr => cr.TraineeId)
				.OnDelete(DeleteBehavior.Restrict);



			builder.HasOne<Course>(cr => cr.Course)
				.WithMany(c => c.CourseResults)
				.HasForeignKey(cr => cr.CourseId)
				.OnDelete(DeleteBehavior.Restrict);



		}
	}
}

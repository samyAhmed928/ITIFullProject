using ITIFullProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITIFullProject.Data.Configs
{
	public class CourseConfig : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c=>c.Name).IsRequired().HasMaxLength(50);
			builder.HasIndex(c => c.Name).IsUnique();
			builder.Property(c=>c.Degree).IsRequired().HasColumnType("decimal(3,2)");
			builder.Property(c => c.MinDegree).IsRequired().HasColumnType("decimal(3,2)");

			//Dept has many course
			builder.HasOne<Department>(c=>c.Department)
				.WithMany(d=>d.Courses)
				.HasForeignKey(c=>c.DeptId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}

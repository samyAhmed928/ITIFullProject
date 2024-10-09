using ITIFullProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITIFullProject.Data.Configs
{
	public class InstructorConfig : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.HasKey(i => i.Id);
			builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
			builder.Property(i => i.Image).IsRequired();
			builder.Property(i => i.Address).IsRequired().HasMaxLength(250);

			//Dept has many insructors
			builder.HasOne(i => i.Department)
				.WithMany(d => d.Instructors)
				.HasForeignKey(i => i.DeptId)
				.OnDelete(DeleteBehavior.Restrict);


		}
	}
}

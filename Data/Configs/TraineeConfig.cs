using ITIFullProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITIFullProject.Data.Configs
{
	public class TraineeConfig : IEntityTypeConfiguration<Trainee>
	{
		public void Configure(EntityTypeBuilder<Trainee> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
			builder.Property(t => t.Image).IsRequired();
			builder.Property(t => t.Address).IsRequired().HasMaxLength(250);
			builder.Property(t => t.Grade).IsRequired();

			//Dept has many trainee
			builder.HasOne<Department>(t => t.Department)
				.WithMany(d => d.Trainees)
				.HasForeignKey(t => t.DeptId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}

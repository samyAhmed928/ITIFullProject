using ITIFullProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITIFullProject.Data.Configs
{
	public class DepartmentConfig : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.HasKey(d => d.Id);
			builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
			builder.Property(d => d.MangerName).IsRequired().HasMaxLength(50);
		}
	}
}

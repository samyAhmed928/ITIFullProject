using ITIFullProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITIFullProject.Data.Configs
{
	public class AccountConfig : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.HasKey(a => a.Id);
			builder.Property(a=>a.UserName).IsRequired().HasMaxLength(250);
			builder.HasIndex(a => a.UserName).IsUnique();
			builder.Property(a=>a.Password).IsRequired().HasMaxLength(250);

			//Acoount has one instructor
			builder.HasOne<Instructor>(a => a.Instructor)
				.WithOne(i => i.Account)
				.HasForeignKey<Account>(a => a.InstructorId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

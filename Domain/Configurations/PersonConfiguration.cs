using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Domain.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(o => o.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(o => o.LastName).IsRequired().HasMaxLength(100);
            builder.Property(o => o.FatherName).HasMaxLength(100);
            builder.Property(o => o.NationalCode).IsRequired().HasMaxLength(10);
            builder.HasIndex(o => o.NationalCode).IsUnique();
        }
    }
}

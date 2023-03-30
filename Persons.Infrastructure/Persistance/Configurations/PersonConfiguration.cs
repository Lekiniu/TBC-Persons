using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Infrastructure.Persistance.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50); 
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PersonalNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.FileUrl);
            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(x => x.City)
                    .WithMany(x => x.Persons)
                    .HasForeignKey(x => x.CityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PhoneNumbers)
                    .WithOne(x => x.Person)
                    .HasForeignKey(x => x.PersonId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.RelativePersons)
                    .WithOne(y => y.MainPerson)
                    .HasForeignKey(x => x.MainPersonId)
                    .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(x => x.MainPersons)
                    .WithOne(y => y.RelatedPerson)
                    .HasForeignKey(x => x.RelatedPersonId)
                    .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}

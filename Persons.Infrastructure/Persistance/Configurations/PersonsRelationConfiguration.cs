using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Domain.AggregateModels.PersonAggregate;

namespace Persons.Infrastructure.Persistance.Configurations
{
    public class PersonsRelationConfiguration : IEntityTypeConfiguration<PersonsRelation>
    { 
        public void Configure(EntityTypeBuilder<PersonsRelation> builder)
        {
            builder.ToTable("PersonsRelations");
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.RelationType).IsRequired();
            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            //builder.HasOne(x => x.MainPerson)
            //      .WithMany(x => x.RelativePersons)
            //      .HasForeignKey(x => x.MainPersonId)
            //      .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(x => x.RelatedPerson)
            //         .WithMany(x => x.MainPersons)
            //         .HasForeignKey(x => x.RelatedPersonId)
            //         .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

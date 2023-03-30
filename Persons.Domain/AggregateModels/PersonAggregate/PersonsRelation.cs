using Persons.Application.Common.Base;
using Persons.Domain.Enums;

namespace Persons.Domain.AggregateModels.PersonAggregate
{
    public class PersonsRelation : BaseEntity<int>
    {
        public PersonsRelation(int mainPersonId, int relatedPersonId, RelationTypes relationType)
        {
            MainPersonId = mainPersonId;
            RelatedPersonId = relatedPersonId;
            RelationType = relationType;
        }

        public int MainPersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public virtual Person MainPerson { get; set; }
        public virtual Person RelatedPerson { get; set; }
        public virtual RelationTypes RelationType { get; set; }


        public static PersonsRelation Create(int mainPersonId, int relatedPersonId, RelationTypes relationType)
                            => new PersonsRelation(mainPersonId, relatedPersonId, relationType);
    }
}

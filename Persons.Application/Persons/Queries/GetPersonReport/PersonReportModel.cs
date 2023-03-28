using Persons.Domain.Enums;

namespace Persons.Application.Persons.Queries.GetPersonReport
{
    public class PersonReportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<RelationModel> Relates { get; set; }
    }

    public class RelationModel
    {
        public RelationTypes RelationType { get; set; }
        public int Count { get; set; }
    }

}

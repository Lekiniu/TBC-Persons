using Persons.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderTypes Gender { get; set; }

        [StringLength(13, ErrorMessage = "not correct Personal Number length")]
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
    }
}

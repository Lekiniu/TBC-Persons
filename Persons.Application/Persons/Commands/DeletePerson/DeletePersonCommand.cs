using MediatR;

namespace Persons.Application.Persons.Commands.CreatePerson
{
    public class DeletePersonCommand :  IRequest<Unit>
    {
        public int Id { get; set; }
      
    }
}

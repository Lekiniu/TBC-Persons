using MediatR;

namespace Persons.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand :  IRequest<Unit>
    {
        public int Id { get; set; }
      
    }
}

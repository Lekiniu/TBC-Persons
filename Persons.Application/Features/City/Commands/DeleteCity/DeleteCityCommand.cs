using MediatR;

namespace Persons.Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

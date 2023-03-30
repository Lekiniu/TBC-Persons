using MediatR;
using Persons.Application.Common.Mappings;

namespace Persons.Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommand : MapFrom<UpdateCityModel>, IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

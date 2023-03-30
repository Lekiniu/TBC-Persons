using MediatR;
using Persons.Application.Common.Mappings;

namespace Persons.Application.Features.City.Commands.CreateCity
{
    public class CreateCityCommand : MapFrom<CreateCityModel>, IRequest<int>
    {
        public string Name { get; set; }
    }

}

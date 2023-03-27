using AutoMapper;

namespace Persons.Application.Common.Mappings
{
    public class MapFrom<T> : IMapFrom<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

        public interface IRequest
        {
        }
    }
}

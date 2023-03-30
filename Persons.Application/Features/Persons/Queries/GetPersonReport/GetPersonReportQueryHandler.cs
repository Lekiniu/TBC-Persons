using MediatR;
using Persons.Application.Interfaces;
using Persons.Domain.AggregateModels.PersonAggregate;
using System.Linq.Expressions;

namespace Persons.Application.Features.Persons.Queries.GetPersonReport
{
    public class GetPersonReportQueryHandler : IRequestHandler<GetPersonReportQuery, IEnumerable<PersonReportModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonReportModel>> Handle(GetPersonReportQuery request, CancellationToken cancellationToken)
        {
            var persons =  _unitOfWork.PersonRepository.GetAllIncluding(new Expression<Func<Person, object>>[] { x => x.RelativePersons });

              var result = persons.Select(x => 
                  new PersonReportModel { Id = x.Id, Name = x.Name, Surname = x.Surname, Relates = x.RelativePersons
                  .GroupBy(r => r.RelationType)
                  .Select(y => new RelationModel { RelationType = y.Key, Count = y.Count() }) });
            return result;
        }
    }

}

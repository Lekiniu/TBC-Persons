using MediatR;
using Persons.Application.Interfaces;

namespace Persons.Application.Persons.Queries.GetPersonReport
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
            var persons = await _unitOfWork.PersonRepository.GetAllAsync(cancellationToken);

              var result = persons.Select(x => 
                  new PersonReportModel { Id = x.Id, Name = x.Name, Surname = x.Surname, Relates = x.RelativePersons
                  .GroupBy(r => r.RelationType)
                  .Select(y => new RelationModel { RelationType = y.Key, Count = y.Count() }) });
            return result;
        }
    }

}

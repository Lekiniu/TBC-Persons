using MediatR;
using System.Collections.Generic;

namespace Persons.Application.Persons.Queries.GetPersonReport
{
    public class GetPersonReportQuery : IRequest<IEnumerable<PersonReportModel>>
    {
    }
}

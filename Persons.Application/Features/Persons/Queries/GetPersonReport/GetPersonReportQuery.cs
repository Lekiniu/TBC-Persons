using MediatR;
using System.Collections.Generic;

namespace Persons.Application.Features.Persons.Queries.GetPersonReport
{
    public class GetPersonReportQuery : IRequest<IEnumerable<PersonReportModel>>
    {
    }
}

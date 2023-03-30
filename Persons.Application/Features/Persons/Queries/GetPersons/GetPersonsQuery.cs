﻿using AutoMapper;
using MediatR;
using Persons.Application.Common.PagedList;

namespace Persons.Application.Features.Persons.Queries.GetPersons
{
    public class GetPersonsQuery :  IRequest<PagedList<PersonModel>>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PersonalNumber { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? ExtendedSeachQuery { get; set; }

    }
}
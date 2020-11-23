using MediatR;
using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.IssueTypes.Queries.GetAll
{
    public class GetAllIssueTypesQuery : IRequest<List<IssueTypesDto>>
    {
    }
}
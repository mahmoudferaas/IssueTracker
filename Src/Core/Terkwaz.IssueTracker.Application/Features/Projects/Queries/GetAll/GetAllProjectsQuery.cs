using MediatR;
using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Queries.GetAll
{
    public class GetAllProjectsQuery : IRequest<List<ProjectDto>>
    {
    }
}
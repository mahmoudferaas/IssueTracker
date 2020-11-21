using MediatR;
using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<List<UserOutput>>
    {

    }
}